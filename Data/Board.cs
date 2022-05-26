using System;
using System.Collections.Generic;

namespace Data
{
    public class Board
    {
        
        private readonly int _width;
        private readonly int _height;

        private readonly List<Ball> _balls;

        public Board(int h, int w)
        {
            _balls = new List<Ball>();
            if (h <= 0 || w <= 0)
                throw new ArgumentException();

            _width = w;
            _height = h;
        }

        public int Width { get => _width; }
        public int Height { get => _height; }

        public void AddBall(Ball ball)
        {
            _balls.Add(ball);
        }

        public List<Ball> GetBalls()
        {
            return _balls;
        }
    }
}
