using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model
{
    public class Graph
    {
        public IList<Edge> Edges { get; set; }
        public IList<Vertex> Vertexes { get; set; }

        public Graph()
        {
            this.Edges = new List<Edge>();
            this.Vertexes = new List<Vertex>();
        }
    }
}
