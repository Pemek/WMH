using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.TabuSearch.Implementation
{
    class CostStopCriteria : IStopCriteria
    {
        public double ActualCost { get; private set; }
        public double LimitCost { get; private set; }

        public CostStopCriteria(double costLimit)
        {
            this.LimitCost = costLimit;
        }
        public bool IsCriteriaMeet()
        {
            return this.ActualCost <= this.LimitCost;
        }

        public void FoundNextSolution(IList<Model.Edge> solution)
        {
            CostFinder cf = new CostFinder();
            this.ActualCost = cf.GetCost(solution);
        }

        public void InitialSolution(IList<Model.Edge> solution)
        {
            CostFinder cf = new CostFinder();
            this.ActualCost = cf.GetCost(solution);
        }

        public int CurrentCritera()
        {
            throw new NotImplementedException();
        }
        public double GetCurrentCritera()
        {
            return ActualCost;
        }
    }
}
