using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMH.Model;

namespace WMH.TabuSearch
{
    /// <summary>
    /// Interface for checking whenever aspiration criteria are met.
    /// </summary>
    public interface IAspirationCriteria
    {
        /// <summary>
        /// Checks if given new solution meets the aspiration criteria.
        /// 
        /// NOTE[Łukasz]: Propably this would be better cost than best solution.
        /// </summary>
        /// <param name="neighbour">Neighbour to check aspiration criteria for.</param>
        /// <param name="bestSolution">Best solution to compare cost.</param>
        /// <returns>True if given solution meets aspiration criteria.</returns>
        bool IsCriteriaMeet(Neighbour neighbour, IList<Edge> bestSolution);
    }
}
