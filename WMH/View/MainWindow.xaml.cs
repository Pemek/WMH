using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Graph Graph1;
        public Graph Graph2;
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
            gv.ShowDialog();
            Graph1 = gv.newGraph;
        }
        private void buttonGraph2Click(object sender, EventArgs e)
        {
            GraphView gv = new GraphView(ref Graph2);
            gv.ShowDialog();
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
                else if(Graph1.Vertexes.Count != Graph2.Vertexes.Count)
                    MessageBox.Show("Grafy są różnych rozmiarów");
                else
                {
                    buttonResult.IsEnabled = false;
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.WorkerReportsProgress = true;
                    bw.DoWork += BackgroundWorkerDoWork;
                    bw.ProgressChanged += BackgroundWorkerProgress;
                    bw.RunWorkerCompleted += BackgroundWorkerComplete;

                    bw.RunWorkerAsync();
                    //WMH.TabuSearch.CostFinder cf = new TabuSearch.CostFinder();
                    //WMH.TabuSearch.NeighbourFinder nf = new TabuSearch.NeighbourFinder(cf, ltm);
                    //WMH.TabuSearch.Implementation.AspirationCriteria ac = new TabuSearch.Implementation.AspirationCriteria(cf);
                    //WMH.TabuSearch.TabuSearch alg = new TabuSearch.TabuSearch(nf, tl, ltm, cf, ac, isc);
                    //result = alg.FindSolution(Graph1, Graph2);
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
            
            //WMH.TabuSearch.CostFinder cf = new TabuSearch.CostFinder();
            //WMH.TabuSearch.NeighbourFinder nf = new TabuSearch.NeighbourFinder(cf, ltm);
            //WMH.TabuSearch.Implementation.AspirationCriteria ac = new TabuSearch.Implementation.AspirationCriteria(cf);
            //WMH.TabuSearch.TabuSearch alg = new TabuSearch.TabuSearch(nf, tl, ltm, cf, ac, isc);
            //result = alg.FindSolution(Graph1, Graph2);
        }

        private void BackgroundWorkerDoWork(object sender, EventArgs e)
        {
            WMH.TabuSearch.CostFinder cf = new TabuSearch.CostFinder();
            WMH.TabuSearch.NeighbourFinder nf = new TabuSearch.NeighbourFinder(cf, ltm);
            WMH.TabuSearch.Implementation.AspirationCriteria ac = new TabuSearch.Implementation.AspirationCriteria(cf);
            WMH.TabuSearch.TabuSearch alg = new TabuSearch.TabuSearch(nf, tl, ltm, cf, ac, isc);
            result = alg.FindSolution(Graph1, Graph2);
        }
        private void BackgroundWorkerProgress(object sender, EventArgs e)
        {
        }
        private void BackgroundWorkerComplete(object sender, EventArgs e)
        {
            buttonResult.IsEnabled = true;
        }

    }
}
