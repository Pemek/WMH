using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMH.Model;

namespace WMH.View
{
    public class Calculations
    {
        private WMH.Model.Graph graph;
        private double Height=0;
        private double Width=0;
        private double biggestX=0;
        private double biggestY=0;
        public List<Point> PointToDraw { get; set; }
        public Calculations(WMH.Model.Graph _graph, double _width, double _height)
        {
            graph = _graph;
            biggestX = graph.findBiggestX();
            biggestY = graph.findBiggestY();

            Width = _width;
            Height = _height;
            
            
        }

        public void getElementToDraw()
        {
            getPointToDraw();
        }
        private void getPointToDraw()
        {
            try
            {
                PointToDraw = new List<Point>();
                foreach (Vertex vert in graph.Vertexes)
                {
                    Point point = new Point(vert.X, vert.Y, Height, Width, biggestX, biggestY);
                    PointToDraw.Add(point);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void getEdgesToDraw()
        {
        }

        public void drawEdges()
        {
        }
    }
}
