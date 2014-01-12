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
        public double findBiggestX()
        {
            try
            {
                double result = 0;
                foreach (Vertex vertex in Vertexes)
                {
                    if (vertex.X > result)
                        result = vertex.X;
                }
                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        public double findBiggestY()
        {
            try
            {
                double result = 0;
                foreach (Vertex vertex in Vertexes)
                {
                    if (vertex.Y > result)
                        result = vertex.Y;
                }
                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
