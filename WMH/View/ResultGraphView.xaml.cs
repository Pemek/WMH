using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WMH.Model;

namespace WMH.View
{
    /// <summary>
    /// Interaction logic for ResultGraphView.xaml
    /// </summary>
    public partial class ResultGraphView : Window
    {
        private Graph Graph1;
        private Graph Graph2;
        private IList<Edge> resultEdges;
        private double Width;
        private double Height;


        public ResultGraphView(Graph _graph1, Graph _graph2, IList<Edge> _resultEdges)
        {
            InitializeComponent();
            Graph1 = _graph1;
            Graph2 = _graph2;
            resultEdges = _resultEdges;

            Height = canvasBackground.Height;
            Width = canvasBackground.Width;
            drawResult();
        }

        private void drawResult()
        {
            try
            {
                double x1 = Graph1.findBiggestX();
                double y1 = Graph1.findBiggestY();
                double x2 = Graph2.findBiggestX();
                double y2 = Graph2.findBiggestY();

                double maxX = 100;// (x1 > x2 ? x1 : x2);// x1 + x2;
                double maxY = 100;// (y1 > y2 ? y1 : y2);

                drawVertexs(Graph1, maxX, maxY, 0, Brushes.Blue);
                drawVertexs(Graph2, maxX, maxY, 0/*2 * (Width / 3)*/, Brushes.Red);
                drawResultEdges(resultEdges, maxX, maxY, 0/*2 * (Width / 3)*/);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void drawVertexs(Graph graph, double biggestX, double biggestY, double shiftX, SolidColorBrush brush)
        {
            try
            {
                foreach (Vertex vert in graph.Vertexes)
                {
                    Point point = new Point(vert.X, vert.Y, Height, Width, biggestX, biggestY);
                    Rectangle rect = new Rectangle { Stroke = brush, StrokeThickness = point.size };
                    Canvas.SetLeft(rect, point.positionX + shiftX);
                    Canvas.SetTop(rect, point.positionY);
                    canvasBackground.Children.Add(rect);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void drawResultEdges(IList<Edge> result, double biggestX, double biggestY, double shiftX)
        {
            try
            {
                foreach (WMH.Model.Edge ed in result)
                {
                    Point startPoint = new Point(ed.Start.X, ed.Start.Y, Height, Width, biggestX, biggestY);
                    Point endPoint = new Point(ed.End.X, ed.End.Y, Height, Width, biggestX, biggestY);

                    Line line = new Line { Stroke = Brushes.Green, StrokeThickness = 2, X1 = startPoint.positionX + shiftX, Y1 = startPoint.positionY, Y2 = endPoint.positionY, X2 = endPoint.positionX };
                    canvasBackground.Children.Add(line);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
