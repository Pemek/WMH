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
    /// Interaction logic for GraphView.xaml
    /// </summary>
    public partial class GraphView : Window
    {
        private double Height = 0;
        private double Width = 0;
        public GraphView(ref Graph graphToGenerate)
        {
            InitializeComponent();
        }

        public void drawGraph(WMH.Model.Graph graph)
        {
            try
            {
                Height = gridView.Height;
                Width = gridView.Width;
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        private void generateGraph(object sender, EventArgs e)
        {

            //WMH.Model.GraphGenerator.GraphGenerator.generateGraph(
        }
    }
}
