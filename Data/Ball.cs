using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.Json.Serialization;


namespace Data
{
    public class Ball : INotifyPropertyChanged, IBall
    {
        public Ball(double x, double y, double radius, double mass, int id)
        {
            _id = id;
            _x = x;
            _y = y;
            _r = radius;
            _m = mass;

            Random r = new Random();

            if (r.Next(2) == 0)
            {
                _velX = r.NextDouble() * -1;
            }
            else
            {
                _velX = r.NextDouble() * 1;
            }


            if (r.Next(2) == 0)
                _velY = Math.Sqrt(1 - (_velX * _velX));
            else
                _velY = Math.Sqrt(1 - (_velX * _velX)) * -1;

        }

        private int _id;
        private double _x;
        private double _y;
        private double _r;
        private double _m;
        private double _velX;
        private double _velY;

        public void Move()
        {
            X += VelX;
            Y += VelY;
            RaisePropertyChanged("Position");
        }

        public int ID
        {
            get { return _id; }
        }
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                RaisePropertyChanged("X");
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                RaisePropertyChanged("Y");
            }

        }
        [JsonIgnore]
        public double R
        {
            get => _r;
            set
            {
                if (value > 0)
                {
                    _r = value;
                }

                else
                {
                    throw new ArgumentException();
                }

            }
        }
        [JsonIgnore]
        public double mass
        {
            get => _m;
            set
            {
                _m = value;
            }
        }

        public double VelX
        {
            get => _velX;
            set
            {
                _velX = value;
            }
        }

        public double VelY
        {
            get => _velY;
            set
            {
                _velY = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
