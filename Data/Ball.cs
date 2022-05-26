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
            this.mass = _mass;

            Random ran = new Random();

            if (ran.Next(2) == 0)
            {
                VelX = ran.NextDouble() * -1;
            }
            else
            {
                VelX = ran.NextDouble() * 1;
            }


            if (ran.Next(2) == 0)
                VelY = Math.Sqrt(1 - (VelX * VelX));
            else
                VelY = Math.Sqrt(1 - (VelX * VelX)) * -1;

        }
        public double GetX() { return X; }
        public double GetY() { return Y; }
        public double GetVelX() { return VelX; }
        public double GetVelY() { return VelY; }
        public double GetR() { return R; }
        public double GetMass() { return mass; }
        public void SetMass(double mass ) { this.mass = mass; }
        public void SetX(double x) { X = x; RaisePropertyChanged(nameof(X)); }
        public void SetY(double y) { Y = y; RaisePropertyChanged(nameof(Y)); }
        public void SetVX(double vx) { VelX = vx; }
        public void SetVY(double vy) { VelY = vy; }
        public void SetR(int r) { R = r; }


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
