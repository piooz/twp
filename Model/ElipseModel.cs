using System;
using System.Collections.Generic;
using System.Text;
using Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class ElipseModel : IElipse, INotifyPropertyChanged
    {
        //public double radius;
        //public double posx;
        //public double posy;

        public double CenterTransform { get => -1 * Radius; }
        public double Diameter { get => 2 * Radius; }

        public event PropertyChangedEventHandler PropertyChanged;


        public ElipseModel(BallConnector ball)
        {
            ball.PropertyChanged += BallPropertyChanged;
            this.Radius = ball.R;
            this.posx = ball.X;
            this.posy = ball.Y;
        }

        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                RaisePropertyChanged(nameof(Radius));
            }

        }
        public double Posx
        {
            get
            {
                return this.posx;
            }
            set
            {
                this.posx = value;
               RaisePropertyChanged(nameof(Posx));
            }
        }
        public double Posy
        {
            get
            {
                return this.posy;
            }
            set
            {
                this.posy = value;
                RaisePropertyChanged(nameof(Posy));
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BallPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BallConnector b = (BallConnector)sender;

            Posx = b.X;
            Posy = b.Y;
        }
    }
}
