using System;
using System.Collections.Generic;

namespace Data
{
    public class Board
    {
        
        private readonly int _width;
        private readonly int _height;

        private readonly List<IBall> _balls;

        public Board(int h, int w)
        {
            _balls = new List<IBall>();
            if (h <= 0 || w <= 0)
                throw new ArgumentException();

            _width = w;
            _height = h;
        }

        public int Width { get => _width; }
        public int Height { get => _height; }

        public void AddBall(IBall ball)
        {
            _balls.Add(ball);
        }

        public List<IBall> GetBalls()
        {
            return _balls;
        }
    }
}
