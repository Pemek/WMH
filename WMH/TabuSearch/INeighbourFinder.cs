using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMH.Model;

namespace WMH.TabuSearch
{
    public class Change
    {
        // They should have only 2 elements
        public IList<Edge> AddedEdges { get; set; }
        // TODO check if it's necessary
        public IList<Edge> DeletedEdges { get; set; }
    }

    public class Neighbour
    {
        // TODO check if it's necessary
        public IList<Edge> NewSolution { get; set; }
        public double Cost { get; set; }
        public Change ChangeMade { get; set; }
    }

    public interface INeighbourFinder
    {
        /// <summary>
        /// Finds neighbours of given solution.
        /// </summary>
        /// <param name="solution">Solution to find neighbours of.</param>
        /// <param name="firstGraph">One of the graphs.</param>
        /// <param name="secondGraph">Second of graphs.</param>
        /// <returns></returns>
        IList<Neighbour> FindNeighbours(IList<Edge> solution, Graph firstGraph, Graph secondGraph);
    }
}
