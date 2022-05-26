using System;
using System.Collections.Generic;

namespace Data
{
    public class Board
    {

        private readonly int size;
        private readonly List<Ball> balls;

        public Board(int s)
        {
            if (s <= 0 )
                throw new ArgumentException();
            size = s;
            balls = new List<Ball>();
        }
        //i tak potzrebujemy jako osobne te kulki
/*        public void AddRandomBalls(int ballsAmount)
        {
            Random rand = new Random();

            for (int i = 0; i < ballsAmount; i++)
            {
                int r = 5;
                int m = 1;
                int x = rand.Next(r, this.size - r);
                int y = rand.Next(r, this.size - r);

                int vx = rand.Next(1, 5);
                int vy = rand.Next(1, 5);

                balls.Add(new Ball(x, y, r, vx, vy, m));
            }
       
        public Ball AddRandomBall(int size)
        {
            Random rand = new Random();


            int r = 5;
            int m = 1;
            int x = rand.Next(r, this.size - r);
            int y = rand.Next(r, this.size - r);

            int vx = rand.Next(1, 15);
            int vy = rand.Next(1, 15);
            Ball Bally = new Ball(x, y, r, vx, vy, m);
            balls.Add(new Ball(x, y, r, vx, vy, m));
            return Bally;
        }

      public void MoveBalls()
        {
            foreach (Ball ball in balls)
            {
                ball.simulateMove(size);
            }
        }*/

        public int GetSize() { return size; }

        public List<Ball> GetBalls()
        {
            return balls;
        }
        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }
    }
}
