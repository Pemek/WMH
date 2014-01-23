using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.TabuSearch.Implementation
{
    public class NoChangesStopCriteria : IStopCriteria
    {
        public int ActualNoChanges { get; private set; }
        public int MaxNoChanges { get; private set; }

        public NoChangesStopCriteria(int maxNoChanges)
        {
            this.MaxNoChanges = maxNoChanges;
            this.ActualNoChanges = 0;
        }

        public bool IsCriteriaMeet()
        {
            return this.ActualNoChanges >= MaxNoChanges;
        }


        public void FoundNextSolution(IList<Model.Edge> solution)
        {
            this.ActualNoChanges++;
        }

        public void InitialSolution(IList<Model.Edge> solution)
        {
            this.ActualNoChanges = 0;
        }

        public int CurrentCritera()
        {
            return this.ActualNoChanges;
        }
    }
}
