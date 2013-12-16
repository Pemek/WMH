using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.TabuSearch.Implementation
{
    /// <summary>
    /// Aspiration criteria implementation. This criteria is met, when cost of actual solution is less than cost of actual best solution.
    /// </summary>
    public class AspirationCriteria : IAspirationCriteria
    {
        private readonly ICostFinder costFinder;

        public AspirationCriteria(ICostFinder costFinder)
        {
            this.costFinder = costFinder;
        }

        public bool IsCriteriaMeet(Neighbour neighbour, IList<Model.Edge> bestSolution)
        {
            return this.costFinder.GetCost(bestSolution) > neighbour.Cost;
        }
    }
}
