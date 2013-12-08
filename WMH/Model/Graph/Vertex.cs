using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model
{
    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vertex()
            : this(0, 0)
        {
        }

        public Vertex(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
