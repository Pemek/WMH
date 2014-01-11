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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WMH.Model;

namespace WMH.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        private Graph Graph1;
        private Graph Graph2;
        public MainWindow()
        {
            InitializeComponent();

            Graph1 = WMH.Model.GraphGenerator.GraphGenerator.generateGraph(10);
            Graph2 = WMH.Model.GraphGenerator.GraphGenerator.generateGraph(10);
            
            WMH.TabuSearch.CostFinder cf = new TabuSearch.CostFinder();
            WMH.TabuSearch.LongTermMemory ltm = new TabuSearch.LongTermMemory(10);
            WMH.TabuSearch.NeighbourFinder nf = new TabuSearch.NeighbourFinder(cf,ltm); 
            WMH.TabuSearch.TabuList tl = new TabuSearch.TabuList(10);
            WMH.TabuSearch.IterationStopCriteria isc = new TabuSearch.IterationStopCriteria(100);
            WMH.TabuSearch.Implementation.AspirationCriteria ac = new TabuSearch.Implementation.AspirationCriteria(cf);

            WMH.TabuSearch.TabuSearch alg = new TabuSearch.TabuSearch(nf, tl, ltm, cf, ac, isc);
            IList<Model.Edge> result = alg.FindSolution(Graph1, Graph2);
            string s;
            s = "";
        }

        private void buttonGraph1Click(object sender, EventArgs e)
        {
            GraphView gv = new GraphView(ref Graph1);
            gv.ShowDialog();
        }
        private void buttonGraph2Click(object sender, EventArgs e)
        {
            GraphView gv = new GraphView(ref Graph2);
            gv.ShowDialog();
        }
    }
}
