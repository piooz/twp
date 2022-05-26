using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Data;

namespace Logic
{
    public class BallConnector: INotifyPropertyChanged
    {
        public BallConnector(Ball ball)
        {
            _ball = ball;
            ball.PropertyChanged += DataBallChanged;
        }

        public void DataBallChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("Coordinates");
        }

        public double X
        {
            get => _ball.X;
            set
            {
                _ball.X = value;
                RaisePropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get => _ball.Y;
            set
            {
                _ball.Y = value;
                RaisePropertyChanged(nameof(Y));
            }

        }

        public double R
        {
            get => _ball.R;
            set
            {
                if (value > 0)
                {
                    _ball.R = value;
                }

                else
                {
                    throw new ArgumentException();
                }

            }
        }

        public double xStep
        {
            get => _ball.VelX;
            set
            {
                _ball.VelX = value;
            }
        }

        public double yStep
        {
            get => _ball.VelY;
            set
            {
                _ball.VelY= value;
            }
        }

        public double M
        {
            get
            {
                return _ball.mass;
            }
        }

        public Ball Ball { get => _ball; }

        private readonly Ball _ball;

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
