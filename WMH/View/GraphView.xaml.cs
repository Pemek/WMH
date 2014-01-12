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
using WMH.Resources;
using WMH.Model.GraphGenerator;

namespace WMH.View
{
    /// <summary>
    /// Interaction logic for GraphView.xaml
    /// </summary>
    public partial class GraphView : Window
    {
        private double Height = 0;
        private double Width = 0;
        public Graph newGraph;
        public GraphView(ref Graph graphToGenerate)
        {
            InitializeComponent();
            newGraph = graphToGenerate;
        }

        public void drawGraph(WMH.Model.Graph graph)
        {
            try
            {
                canvasBackground.Children.Clear();
                Height = canvasBackground.Height;
                Width = canvasBackground.Width;
                double biggestX = graph.findBiggestX();
                double biggestY = graph.findBiggestY();

                drawEdges(graph, biggestX, biggestY);
                drawVertexs(graph, biggestX, biggestY);
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void generateGraph(object sender, EventArgs e)
        {
            try
            {
                int numberOfVertex;
                string vertex = textBoxVertex.Text;
                if (Int32.TryParse(vertex, out numberOfVertex))
                {
                    newGraph = GraphGenerator.generateGraph(numberOfVertex);
                }
                else
                {
                    string message = Resource.ResourceManager.GetString("IncorrectValue");
                    MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void drawVertexs(Graph graph, double biggestX, double biggestY)
        {
            try
            {
                foreach (Vertex vert in graph.Vertexes)
                {
                    Point point = new Point(vert.X, vert.Y, canvasBackground.Height, canvasBackground.Width, biggestX, biggestY);
                    Rectangle rect = new Rectangle { Stroke = Brushes.Red, StrokeThickness = point.size };
                    Canvas.SetLeft(rect, point.positionX);
                    Canvas.SetTop(rect, point.positionY);
                    canvasBackground.Children.Add(rect); 

                }
            }
            catch (Exception)
            { 
                throw;
            }
        }
        private void drawEdges(Graph graph, double biggestX, double biggestY)
        {
            try
            {
                foreach (WMH.Model.Edge ed in graph.Edges)
                {
                    Point startPoint = new Point(ed.Start.X, ed.Start.Y, Height, Width, biggestX, biggestY);
                    Point endPoint = new Point(ed.End.X, ed.End.Y, Height, Width, biggestX, biggestY);

                    Line line = new Line { Stroke = Brushes.Green, StrokeThickness = 2, X1 = startPoint.positionX, Y1 = startPoint.positionY, Y2 = endPoint.positionY, X2 = endPoint.positionX };
                    canvasBackground.Children.Add(line);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void showGraph(object sender, EventArgs e)
        {
            drawGraph(newGraph);
        }
    }
}
