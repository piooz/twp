using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Data
{
    public abstract class DataApi
    {
            public static DataApi Create()
            {
                return new DataLayer();
            }

        public abstract void CreateBoard(int height, int width, int ballsAmount, int radius);
        public abstract bool CanCreateBallHere(double x, double y, double radius);

        public abstract void AddBall(double x, double y, double radius, double mass, int id);

        public abstract void SimulateMoving();

        public abstract void StopMoving();

        public abstract Board GetBoard();

        public abstract List<IBall> GetBalls();





        internal class DataLayer : DataApi
        {
            internal DataLayer()
            {

            }
            private List<Thread> threads;

            private Board board;

            private bool moving = false;

            private object _lock = new object();
            Logger logger;


            public override void CreateBoard(int height, int width, int ballsAmount, int radius )
            {
                board = new Board(height, width);

                threads = new List<Thread>();

                Random rand = new Random();

                for (int i = 0; i < ballsAmount; i++)
                {
                    double x;
                    double y;
                    double mass = 5;
                    do
                    {
                        x = rand.NextDouble() * (height - 2 - 2 * radius) + radius + 1;
                        y = rand.NextDouble() * (height - 2 - 2 * radius) + radius + 1;

                    } while (!CanCreateBallHere(x, y, radius));

                    AddBall(x, y, radius, mass, i);

                }

            }


            public override bool CanCreateBallHere(double x, double y, double radius)
            {
                foreach (IBall other in GetBalls())
                {
                    double distance = Math.Sqrt((x - other.X) * (x - other.X) + (y - other.Y) * (y - other.Y));
                    if (distance <= radius + other.R + 1)
                        return false;
                }
                return true;
            }

            public override void AddBall(double x, double y, double radius, double mass,int id)
            {
                Ball ball = new Ball(x, y, radius, mass, id);
                board.AddBall(ball);

                Thread t = new Thread(() =>
                {

                    while (moving)
                    {

                        lock (_lock)
                        {
                            ball.Move();
                        }

                        Thread.Sleep(1);
                    }

                });
                t.IsBackground = true;

                threads.Add(t);
            }

            public override List<IBall> GetBalls()
            {
                return board.GetBalls();
            }

            public override Board GetBoard()
            {
                return board;
            }

            public override void SimulateMoving()
            {
                moving = true;
                foreach (Thread thread in threads)
                {
                    thread.Start();
                }

                logger = new Logger(GetBalls());
            }

            public override void StopMoving()
            {
                moving = false;
                if (logger != null)
                {
                    logger.StopLogging();
                }
            }
        }

    }
}
