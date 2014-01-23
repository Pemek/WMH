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
using WMH.TabuSearch.Implementation;

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
        private NoChangesStopCriteria ncsc;
        private CostStopCriteria csc;
        private IList<Edge> result;
        private WMH.TabuSearch.TabuSearch alg;

        BackgroundWorker progressWorker;
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
                    WMH.TabuSearch.CostFinder cf = new TabuSearch.CostFinder();
                    WMH.TabuSearch.NeighbourFinder nf = new TabuSearch.NeighbourFinder(cf, ltm);
                    WMH.TabuSearch.Implementation.AspirationCriteria ac = new TabuSearch.Implementation.AspirationCriteria(cf);
                    /*WMH.TabuSearch.TabuSearch*/ alg = new TabuSearch.TabuSearch(nf, tl, ltm, cf, ac, isc, ncsc, csc);

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = isc.MaxIterations;

                    buttonResult.IsEnabled = false;
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.WorkerReportsProgress = true;
                    bw.DoWork += BackgroundWorkerDoWork;
                    bw.RunWorkerCompleted += BackgroundWorkerComplete;

                    /*BackgroundWorker*/ progressWorker = new BackgroundWorker();
                    progressWorker.WorkerReportsProgress = true;
                    progressWorker.WorkerSupportsCancellation = true;
                    progressWorker.DoWork += ProgressWorkerDoWork;
                    progressWorker.ProgressChanged += ProgressWorkerProgress;
                    
                    progressWorker.RunWorkerAsync();
                    int t = 0;
                    bw.RunWorkerAsync();
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    t = alg.test;
                    //    System.Threading.Thread.Sleep(1000);
                    //}
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
                ncsc = new NoChangesStopCriteria(apv.NoChangeStopCrit);
                csc = new CostStopCriteria(apv.CostCrit);
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
            ncsc = new NoChangesStopCriteria(10);
            csc = new CostStopCriteria(1000);
        }

        private void BackgroundWorkerDoWork(object sender, EventArgs e)
        {
            result = alg.FindSolution(Graph1, Graph2);
        }
        private void BackgroundWorkerComplete(object sender, EventArgs e)
        {
            buttonResult.IsEnabled = true;
            progressBar1.Value = progressBar1.Maximum;
            progressWorker.CancelAsync();
        }

        private void ProgressWorkerDoWork(object sender, EventArgs e)
        {
            while (true)
            {
                BackgroundWorker b = sender as BackgroundWorker;
                if (b.CancellationPending)
                {
                    return;
                }
                b.ReportProgress(alg.progress);
                System.Threading.Thread.Sleep(1000);
            }
        }
        private void ProgressWorkerProgress(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = alg.progress;
        }

    }
}
