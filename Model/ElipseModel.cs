using System;
using System.Collections.Generic;
using System.Text;
using Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class ElipseModel : INotifyPropertyChanged
    {
        public int Radius { get; set; }
        public int posx;
        public int posy;

        public event PropertyChangedEventHandler PropertyChanged;

        public ElipseModel(Ball ball)
        {
            this.Radius = ball.R;
            this.posx = ball.X;
            this.posy = ball.Y;
        }

        public int Posx
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
        public int Posy
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


    }
}
