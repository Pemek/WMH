using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMH.Model;

namespace WMH.TabuSearch
{
    public class Neighbour
    {
        public IList<Edge> NewSolution { get; set; }
        public double Cost { get; set; }
        public EdgesAdded AddedEdges { get; set; }
    }

    public interface INeighbourFinder
    {
        /// <summary>
        /// Finds neighbours of given solution.
        /// </summary>
        /// <param name="solution">Solution to find neighbours of.</param>
        /// <returns></returns>
        /// 
        // TODO Remember to take long ter memory into account, when computing neighbour cost.
        IList<Neighbour> FindNeighbours(IList<Edge> solution);
    }
}
