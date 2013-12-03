using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model
{
    public class Edge
    {
        public Vertex Start { get; private set; }
        public Vertex End { get; private set; }

        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.End.X - this.Start.X, 2) + Math.Pow(this.End.Y - this.Start.Y, 2));
            }
        }

        public Edge(Vertex start, Vertex end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
