using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WMH.Model;
using WMH.Model.GraphGenerator;
using WMH.TabuSearch;

namespace WMH
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //System.Threading.Thread.Sleep(1000 * 10);
            //no arguments start with main window
            if (e.Args == null || e.Args.Length == 0)
            {
                View.MainWindow mw = new View.MainWindow();
                mw.Show();
            }
            else if(e.Args.Length == 4)
            {
                int vertexNumber, ltmLenght, stmLenght, endCryt;
                if(!Int32.TryParse(e.Args[0], out vertexNumber) || !Int32.TryParse(e.Args[1], out stmLenght) || !Int32.TryParse(e.Args[2], out ltmLenght) || !Int32.TryParse(e.Args[3], out endCryt))
                {
                    Console.WriteLine("Podane parametry nie sa poprawne. Aplikacja zostanie zamknieta.");
                    Console.ReadLine();
                    Application.Current.Shutdown();
                }
                else
                {
                    Graph Graph1 = GraphGenerator.generateGraph(vertexNumber);
                    Graph Graph2 = GraphGenerator.generateGraph(vertexNumber);

                    LongTermMemory ltm = new LongTermMemory(ltmLenght);
                    TabuList tl = new TabuList(stmLenght);
                    IterationStopCriteria isc = new IterationStopCriteria(endCryt);
                    WMH.TabuSearch.CostFinder cf = new TabuSearch.CostFinder();
                    WMH.TabuSearch.NeighbourFinder nf = new TabuSearch.NeighbourFinder(cf, ltm);
                    WMH.TabuSearch.Implementation.AspirationCriteria ac = new TabuSearch.Implementation.AspirationCriteria(cf);
                    WMH.TabuSearch.TabuSearch alg = new TabuSearch.TabuSearch(nf, tl, ltm, cf, ac, isc);
                    IList<Edge> result = alg.FindSolution(Graph1, Graph2);

                    Application.Current.Shutdown();
                }
            }
            else
            {
                Console.WriteLine("Podane parametry nie sa poprawne. Aplikacja zostanie zamknieta.");
                Application.Current.Shutdown();
            }
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
        }

    }

    
}
