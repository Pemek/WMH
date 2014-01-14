using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMH.Model;

namespace WMH.TabuSearch
{
    public interface IStopCriteria
    {
        /// <summary>
        /// Checks whenever algorithm has meet the stop criteria.
        /// </summary>
        /// <returns>True if algorith has meet the stop criteria.</returns>
        bool IsCriteriaMeet();

        /// <summary>
        /// Informs stop criteria, that next solution has been found.
        /// </summary>
        /// <param name="solution">Solution found.</param>
        void FoundNextSolution(IList<Edge> solution);

        /// <summary>
        /// Informs stop criteria about initial solution.
        /// </summary>
        /// <param name="solution">Initial solution.</param>
        void InitialSolution(IList<Edge> solution);

        int CurrentCritera();
    }
}
