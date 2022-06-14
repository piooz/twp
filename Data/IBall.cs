using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IBall
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double VelX { get; set; }
        public double VelY { get; set; }

        public double mass { get; set; }
        public double R { get; set; }
    }
}
