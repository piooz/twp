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
                    UpdateVelocity(b);
                }

            }

            private void UpdateVelocity(Ball ball)
            {
                BorderCollsion(ball, DataLayer.GetBoard());
                Ball collided = CheckCollisions(ball);
                if (collided != null)
                {
                    double XDiff = ball.X - collided.X;
                    double YDiff = ball.Y - collided.Y;


                    if (XDiff * (collided.VelX - ball.VelX) + YDiff * (collided.VelY - ball.VelY) > 0)
                    {
                        double V1X = ball.VelX;
                        double V1Y = ball.VelY;

                        double tmp = 2 * (XDiff * (V1X - collided.VelX) +
                                          YDiff * (V1Y - collided.VelY)) /
                                         (XDiff * XDiff + YDiff * YDiff) /
                                         (ball.mass + collided.mass);

                        ball.VelX -= collided.mass * XDiff * tmp;
                        ball.VelY -= collided.mass * YDiff * tmp;

                        collided.VelX += ball.mass * XDiff * tmp;
                        collided.VelY += ball.mass * YDiff * tmp;
                    }

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
