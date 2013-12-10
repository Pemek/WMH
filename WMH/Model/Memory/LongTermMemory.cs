using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMH.Model.Comparators;
using WMH.TabuSearch;

namespace WMH.Model.Memory
{
    public class LongTermMemory : ILongTermMemory
    {
        //number of occurrences all edge in application
        public int MaxNumberOfEdge { get; set; }
        private IList<EdgesAdded> ChangesList;
        public LongTermMemory(int maxNumberOfEdge)
        {
            MaxNumberOfEdge = maxNumberOfEdge;
            ChangesList = new List<EdgesAdded>();
        }
        public bool isOnTheList(EdgesAdded edges)
        {
            return ChangesList.Contains(edges);
        }
        public void AddChange(EdgesAdded addedEdges)
        {
            if (ChangesList.Count >= MaxNumberOfEdge)
                ChangesList.RemoveAt(0);
            ChangesList.Add(addedEdges);
        }
        public int Count()
        {
            if (ChangesList != null)
                return 0;
            return ChangesList.Count;
        }
        public int numberRecurrences(EdgesAdded edges)
        {
            return  ChangesList.Count(s => s.AreEqual(edges));
        }
    }
}
