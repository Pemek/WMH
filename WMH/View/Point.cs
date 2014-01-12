using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.View
{
    public class Point
    {
        public double positionX { get; set; }
        public double positionY { get; set; }
        public double size { get; set; }
        //public double canHeight { get; set; }
        //public double canWidth { get; set; }
        //public double biggestValueX { get; set; }
        //public double biggestValueY { get; set; }

        public Point(double _positionX, double _positionY, double _canHeight, double _canWidth, double _biggestX, double _biggestY)
        {
            //positionX = _positionX;
            //positionY = _positionY;
            //canHeight = _canHeight;
            //canWidth = _canWidth;
            //biggestValueX = _biggestX;
            //biggestValueY = _biggestY;
            size = 5;
            positionX = scalePosiotion(_positionX, _canWidth, _biggestX);
            positionY = scalePosiotion(_positionY, _canHeight, _biggestY);
        }

        private double scalePosiotion(double position, double can, double biggest)
        {
            try
            {
                return (can * position) / biggest;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
