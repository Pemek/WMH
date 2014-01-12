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
using WMH.TabuSearch;

namespace WMH.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        private Graph Graph1;
        private Graph Graph2;
        private Graph resultGraph;
        private LongTermMemory ltm;
        private TabuList tl;
        private IterationStopCriteria isc;
        IList<Edge> result;
        public MainWindow()
        {
            InitializeComponent();
            test();
        }

        private void buttonGraph1Click(object sender, EventArgs e)
        {
            GraphView gv = new GraphView(ref Graph1);
            gv.Show();
            Graph1 = gv.newGraph;
        }
        private void buttonGraph2Click(object sender, EventArgs e)
        {
            GraphView gv = new GraphView(ref Graph2);
            gv.Show();
            Graph2 = gv.newGraph;
        }

        private void startAlg(object sender, EventArgs e)
        {
            try
            {
                if (Graph1 == null || Graph2 == null)
                {
                    MessageBox.Show("Dane wejsciowe zawieraja bledy");
                }
                else
                {
                    WMH.TabuSearch.CostFinder cf = new TabuSearch.CostFinder();
                    WMH.TabuSearch.NeighbourFinder nf = new TabuSearch.NeighbourFinder(cf, ltm);
                    WMH.TabuSearch.Implementation.AspirationCriteria ac = new TabuSearch.Implementation.AspirationCriteria(cf);
                    WMH.TabuSearch.TabuSearch alg = new TabuSearch.TabuSearch(nf, tl, ltm, cf, ac, isc);
                    result = alg.FindSolution(Graph1, Graph2);

                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        private void parametersAlg(object sender, EventArgs e)
        {
            try
            {
                AlgorithmParametersView apv = new AlgorithmParametersView();
                apv.ShowDialog();
                ltm = new LongTermMemory(apv.longTermMemory);
                tl = new TabuList(apv.tabuList);
                isc = new IterationStopCriteria(apv.IterationStopCrit);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void showResultGraph(object sender, EventArgs e)
        {
            try
            {
                test();
                ResultGraphView rgv = new ResultGraphView(Graph1, Graph2, result);
                rgv.Show();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void test()
        {
            Graph1 = WMH.Model.GraphGenerator.GraphGenerator.generateGraph(4);
            Graph2 = WMH.Model.GraphGenerator.GraphGenerator.generateGraph(4);

            ltm = new LongTermMemory(10);
            tl = new TabuList(10);
            isc = new IterationStopCriteria(100);
            
            WMH.TabuSearch.CostFinder cf = new TabuSearch.CostFinder();
            WMH.TabuSearch.NeighbourFinder nf = new TabuSearch.NeighbourFinder(cf, ltm);
            WMH.TabuSearch.Implementation.AspirationCriteria ac = new TabuSearch.Implementation.AspirationCriteria(cf);
            WMH.TabuSearch.TabuSearch alg = new TabuSearch.TabuSearch(nf, tl, ltm, cf, ac, isc);
            result = alg.FindSolution(Graph1, Graph2);
        }
    }
}
