using System;
using System.Collections.Generic;
using Data;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Logic
{
    public abstract class logic
    {
        
        public static logic CreateLayer(DataApi data = default)
        {
            return new BusinessLogic(data ?? DataApi.Create());
        }


        public abstract void CreateBoard(int height, int width, int numberOfBalls, int radiusOfBalls);
        public abstract void StartMovingBalls();
        public abstract void DestroyThreads();
        public abstract List<BallConnector> GetBalls();

        private List<BallConnector> ballOperators;

        private class BusinessLogic : logic
        {
            internal BusinessLogic(DataApi data)
            {
                DataLayer = data;
            }
            public override void CreateBoard(int height, int width, int numberOfBalls, int radiusOfBalls)
            {
                ballOperators = new List<BallConnector>();
                DataLayer.CreateBoard(height, width, numberOfBalls, radiusOfBalls);

                foreach (Ball bal in DataLayer.GetBalls())
                {
                    ballOperators.Add(new BallConnector(bal));
                    bal.PropertyChanged += CheckMovement;
                }

            }

            public void CheckMovement(object sender, PropertyChangedEventArgs e)
            {
                Ball b = (Ball)sender;
                if (e.PropertyName == "Position")
                {
                    UpdateVelocity(DataLayer.GetBoard().Height, DataLayer.GetBoard().Width, b.R, b);
                }

            }

            private void UpdateVelocity(int boardHeight, int boardWidth, double radius, Ball ball)
            {
                BorderCollsion(ball, DataLayer.GetBoard());
                Ball collided = CheckCollisions(ball);
                if (collided != null)
                {
                    double newX1, newX2, newY1, newY2;

                    newX1 = (ball.VelX * (ball.mass - collided.mass) / (ball.mass + collided.mass) + (2 * collided.mass * collided.VelX) / (ball.mass + collided.mass));
                    newY1 = (ball.VelY * (ball.mass - collided.mass) / (ball.mass + collided.mass) + (2 * collided.mass* collided.VelY) / (ball.mass + collided.mass));

                    newX2 = (collided.VelX * (collided.mass - ball.mass) / (ball.mass + collided.mass) + (2 * ball.mass * ball.VelX) / (ball.mass + collided.mass));
                    newY2 = (collided.VelY * (collided.mass - ball.mass) / (ball.mass + collided.mass) + (2 * ball.mass * ball.VelY) / (ball.mass + collided.mass));

                    ball.VelX = newX1;
                    ball.VelY = newY1;

                    collided.VelX = newX2;
                    collided.VelY = newY2;

                }

            }

            private void BorderCollsion(Ball ball, Board board)
            {
                if (!(ball.X >= ball.R && ball.X <= board.Width - ball.R))
                {
                    if (ball.VelX > 0)
                        ball.X = board.Width - ball.R;
                    else
                        ball.X = ball.R;

                    ball.VelX *= -1;
                }


                if (!(ball.Y >= ball.R && ball.Y <= board.Height - ball.R))
                {
                    if (ball.VelY > 0)
                        ball.Y = board.Height - ball.R;
                    else
                        ball.Y = ball.R;

                    ball.VelY *= -1;
                }
            }

            private Ball CheckCollisions(Ball ball)
            {
                foreach (Ball other in DataLayer.GetBalls())
                {
                    if (other == ball)
                        continue;

                    double distance = Math.Sqrt((ball.X - other.X) * (ball.X - other.X) +
                                                (ball.Y - other.Y) * (ball.Y - other.Y));

                    if (distance <= ball.R + other.R)
                        return other;
                }

                return null;

            }


            public override void StartMovingBalls()
            {
                DataLayer.SimulateMoving();
            }

            public override void DestroyThreads()
            {
                DataLayer.StopMoving();
            }

            public override List<BallConnector> GetBalls()
            {
                return ballOperators;
            }

            private readonly DataApi DataLayer;
        }

    }
}
