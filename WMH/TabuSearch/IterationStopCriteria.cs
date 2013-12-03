using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.TabuSearch
{
    /// <summary>
    /// Stop criteria for number of iterations.
    /// </summary>
    public class IterationStopCriteria : IStopCriteria
    {
        public int ActualIteration { get; private set; }

        public int MaxIterations { get; private set; }

        public IterationStopCriteria(int maxIterations)
        {
            this.MaxIterations = maxIterations;
        }

        public bool IsCriteriaMeet()
        {
            return this.ActualIteration > MaxIterations;
        }

        public void FoundNextSolution(IList<Model.Edge> solution)
        {
            this.ActualIteration++;
        }

        public void InitialSolution(IList<Model.Edge> solution)
        {
            this.ActualIteration = 0;
        }
    }
}
