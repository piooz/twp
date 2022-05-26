using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {

        public double X;
        public double Y;
        public double R;

        public double VelX;
        public double VelY;
        public double mass;

        public Ball(double x, double y, double r, double _mass)
        {
            this.X = x;
            this.Y = y;
            this.R = r;
/*            this.VelX = vx;
            this.VelY = vy;*/
            this.mass = _mass;
        }
        public double GetX() { return X; }
        public double GetY() { return Y; }
        public double GetVelX() { return VelX; }
        public double GetVelY() { return VelY; }
        public double GetR() { return R; }
        public double GetMass() { return mass; }
        public void SetX(double x) { X = x; }
        public void SetY(double y) { Y = y; }
        public void SetVX(double vx) { VelX = vx; }
        public void SetVY(double vy) { VelY = vy; }
        public void SetR(int r) { R = r; }


        /*      public void simulateMove(int size)
              {

                  int newx = X + VelX;
                  int newy = Y + VelY;

                  if (newx > size || newx < 0)
                  {
                      VelX *= -1;
                  }
                  if (newy > size || newy < 0)
                  {
                      VelY *= -1;
                  }

                  X += VelX;
                  Y += VelY;
              }*/
        public void Move()
        {
            X += VelX;
            Y += VelY;
            RaisePropertyChanged("Position");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
