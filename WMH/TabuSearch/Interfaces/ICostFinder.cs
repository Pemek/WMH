using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMH.Model;

namespace WMH.TabuSearch
{
    /// <summary>
    /// Interface for computing cost of colution.
    /// </summary>
    public interface ICostFinder
    {
        /// <summary>
        /// Computes cost of given solution.
        /// </summary>
        /// <param name="solution">Solution to compute cost for.</param>
        /// <returns>Cost of given solution.</returns>
        double GetCost(IList<Edge> solution);
    }
}
