using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    
    public class Board
    {
        public int Size { get; private set; }
        public List<Ball>? Balls { get; private set; }

        public Board(int size)
        {
            this.Size = size;
            this.Balls = new List<Ball>();
        }

        public void AddRandomBalls(int ballsAmount)
        {
            Random rand = new Random();

            for (int i = 0; i < ballsAmount; i++)
            {
                int r = 5;
                int x = rand.Next(r, this.Size - r);
                int y = rand.Next (r, this.Size - r);

                int vx = rand.Next(1,5);
                int vy = rand.Next(1,5);

                Balls.Add( new Ball(x, y, r, vx, vy) );
            }
        }

        public void MoveBalls()
        {
            foreach (Ball ball in Balls)
            {
                ball.simulateMove(Size);
            }
        }

    }
}
