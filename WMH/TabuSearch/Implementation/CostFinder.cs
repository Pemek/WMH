using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.TabuSearch
{
    /// <summary>
    /// Class for computing cost of solution.
    /// </summary>
    public class CostFinder : ICostFinder
    {
        /// <summary>
        /// Computes cost of given solution.
        /// </summary>
        /// <param name="solution">Solution to compute cost for.</param>
        /// <returns>Cost of given solution.</returns>
        public double GetCost(IList<Model.Edge> solution)
        {
            var result = 0.0;
            foreach (var edge in solution)
            {
                result += edge.Length;
            }

            // TODO add penalty from long term memory.
            return result;
        }
    }
}
