using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMH.Model;

namespace WMH.TabuSearch
{
    public class TabuSearch
    {
        private INeighbourFinder neighbourFinder;
        private ITabuList tabuList;
        private ILongTermMemory longTermMemory;
        private ICostFinder costFinder;
        private IAspirationCriteria aspirationCriteria;
        private IStopCriteria stopCriteria;
        public int progress=0;

        public TabuSearch(INeighbourFinder neighbourFinder, ITabuList tabuList, ILongTermMemory longTermMemory, ICostFinder costFinder, IAspirationCriteria aspirationCriteria, IStopCriteria stopCriteria)
        {
            this.neighbourFinder = neighbourFinder;
            this.tabuList = tabuList;
            this.longTermMemory = longTermMemory;
            this.costFinder = costFinder;
            this.aspirationCriteria = aspirationCriteria;
            this.stopCriteria = stopCriteria;
        }

        /// <summary>
        /// Algorithm main method. It generally finds cheapest connections from each verticle from first graph to each verticle from second one.
        /// Each verticle must be used, and also only once.
        /// </summary>
        /// <param name="firstGraph">First graph.</param>
        /// <param name="secondGraph">Second graph.</param>
        /// <returns>List of edges between each graphs.</returns>
        public IList<Edge> FindSolution(Graph firstGraph, Graph secondGraph)
        {
            IList<Edge> actualSolution = this.GenerateInitialSolution(firstGraph, secondGraph);
            IList<Edge> bestSolution = actualSolution;

            this.stopCriteria.InitialSolution(actualSolution);

            Neighbour selectedNeighbour = null;
            while (!this.stopCriteria.IsCriteriaMeet())
            {
                selectedNeighbour = this.FindBestNeighbour(actualSolution, bestSolution);
                if (selectedNeighbour == null)
                {
                    throw new Exception("No best neighbour found");
                }
                this.tabuList.AddChange(selectedNeighbour.AddedEdges);
                
                this.longTermMemory.AddChange(selectedNeighbour.AddedEdges);
                actualSolution = selectedNeighbour.NewSolution;
                if (this.costFinder.GetCost(actualSolution) < this.costFinder.GetCost(bestSolution))
                {
                    bestSolution = actualSolution;
                }
                this.stopCriteria.FoundNextSolution(actualSolution);
                this.progress = stopCriteria.CurrentCritera();
            }

            return bestSolution;
        }

        /// <summary>
        /// Finds best neighbour of actual solution.
        /// </summary>
        /// <param name="actualSolution">Actual solution to find neighbours of.</param>
        /// <param name="bestSolution">Best found solution so far.</param>
        /// <returns>Best found neighbour</returns>
        private Neighbour FindBestNeighbour(IList<Edge> actualSolution, IList<Edge> bestSolution)
        {
            var neighbours = this.neighbourFinder.FindNeighbours(actualSolution);

            // Order by descending cost ensures, that nighbours will be checked from best to the worst. 
            foreach (var neighbour in neighbours.OrderByDescending(n => n.Cost))
            {
                // is on tabu, but meets aspiration criteria, or is not on tabu list.
                if ((this.tabuList.IsOntabuList(neighbour.AddedEdges) && this.aspirationCriteria.IsCriteriaMeet(neighbour, bestSolution))
                    || !this.tabuList.IsOntabuList(neighbour.AddedEdges))
                {
                    return neighbour;
                }
            }
            return null;
        }

        /// <summary>
        /// Generates initial solution. This means, that it connects first vertex from first graph to first vertex from second graph, second to secong third to third etc.
        /// </summary>
        /// <param name="firstGraph">First graph</param>
        /// <param name="secondGraph">Second graph</param>
        /// <returns>List of edges from first graph to second graph.</returns>
        private IList<Edge> GenerateInitialSolution(Graph firstGraph, Graph secondGraph)
        {
            if (firstGraph.Vertexes.Count != secondGraph.Vertexes.Count)
            {
                throw new ArgumentException("Number of vertexes in each graph should be the same");
            }
            var result = new List<Edge>();
            for (int i = 0; i < firstGraph.Vertexes.Count; i++)
            {
                result.Add(new Edge(firstGraph.Vertexes[i], secondGraph.Vertexes[i]));
            }
            return result;
        }
    }
}
