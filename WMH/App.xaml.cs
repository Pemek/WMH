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
using WMH.TabuSearch.Implementation;

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
                //numberOfVertexes, shortTermMemory,LongTermMemory,IterationCryteria, NoChangesCryteria, costLimitCryteria
            else if(e.Args.Length == 6)
            {
                int vertexNumber, ltmLenght, stmLenght, endCryt, noChageCryt, costLimit;
                if(!Int32.TryParse(e.Args[0], out vertexNumber) || !Int32.TryParse(e.Args[1], out stmLenght) 
                    || !Int32.TryParse(e.Args[2], out ltmLenght) || !Int32.TryParse(e.Args[3], out endCryt)
                    || !Int32.TryParse(e.Args[4], out noChageCryt) || !Int32.TryParse(e.Args[5], out costLimit))
                {
                    Console.WriteLine("Podane parametry nie sa poprawne. Aplikacja zostanie zamknieta.");
                    Console.ReadLine();
                    Application.Current.Shutdown();
                }
                else
                {
                    StartAlgorithm(vertexNumber, ltmLenght, stmLenght, endCryt, noChageCryt, costLimit, null);
                    Application.Current.Shutdown();
                }
            }
            //numberOfVertexes, shortTermMemory,LongTermMemory,IterationCryteria, NoChangesCryteria, costLimitCryteria, numberOfLoops
            else if (e.Args.Length == 7)
            {
                int vertexNumber, ltmLenght, stmLenght, endCryt, noChangeCryt, numberOfTest, costLimit;
                if (!Int32.TryParse(e.Args[0], out vertexNumber) || !Int32.TryParse(e.Args[1], out stmLenght) 
                    || !Int32.TryParse(e.Args[2], out ltmLenght) || !Int32.TryParse(e.Args[3], out endCryt)
                    || !Int32.TryParse(e.Args[4], out noChangeCryt) || !Int32.TryParse(e.Args[5], out costLimit)
                    || !Int32.TryParse(e.Args[6], out numberOfTest))
                {
                    Console.WriteLine("Podane parametry nie sa poprawne. Aplikacja zostanie zamknieta.");
                    Console.ReadLine();
                    Application.Current.Shutdown();
                }
                else
                {
                    for (int i = 1; i <= numberOfTest; i++)
                    {
                        StartAlgorithm(vertexNumber, ltmLenght, stmLenght, endCryt, noChangeCryt, costLimit, i);
                        Console.WriteLine("Proba nr " + i + " zakonczona");
                    }
                    
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

        private void StartAlgorithm(int vertexNumber, int ltmLenght, int stmLenght, int endCryt, int noChangeFor, double costLessThan, int? numberOfLoop)
        {
            string currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pathG1, pathG2, pathResult;
            if (numberOfLoop != null)
            {
                pathG1 = currentDir + "\\g1\\graph"+numberOfLoop;
                pathG2 = currentDir + "\\g2\\graph"+numberOfLoop;
                pathResult = currentDir + "\\result\\res"+numberOfLoop;
            }
            else
            {
                pathG1 = currentDir + "\\g1\\graph";
                pathG2 = currentDir + "\\g2\\graph";
                pathResult = currentDir + "\\result\\res";
            }
            Graph Graph1 = GraphGenerator.generateGraph(vertexNumber);
            WMH.Model.FileOperation.FileOperationGraph.SaveToFile(pathG1, Graph1.Vertexes);
            Graph Graph2 = GraphGenerator.generateGraph(vertexNumber);
            WMH.Model.FileOperation.FileOperationGraph.SaveToFile(pathG2, Graph2.Vertexes);

            LongTermMemory ltm = new LongTermMemory(ltmLenght);
            TabuList tl = new TabuList(stmLenght);
            IterationStopCriteria isc = new IterationStopCriteria(endCryt);
            NoChangesStopCriteria ncsc = new NoChangesStopCriteria(noChangeFor);
            CostStopCriteria csc = new CostStopCriteria(costLessThan);
            WMH.TabuSearch.CostFinder cf = new TabuSearch.CostFinder();
            WMH.TabuSearch.NeighbourFinder nf = new TabuSearch.NeighbourFinder(cf, ltm);
            WMH.TabuSearch.Implementation.AspirationCriteria ac = new TabuSearch.Implementation.AspirationCriteria(cf);
            WMH.TabuSearch.TabuSearch alg = new TabuSearch.TabuSearch(nf, tl, ltm, cf, ac, isc, ncsc, csc);
            
            System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            IList<Edge> result = alg.FindSolution(Graph1, Graph2);
            stopWatch.Stop();

            
            WMH.Model.FileOperation.FileOperationResult.SaveResultToFile(result, pathResult, stopWatch);
            
        }

    }

    
}
