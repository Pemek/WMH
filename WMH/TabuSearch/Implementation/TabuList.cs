using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMH.Model;
using WMH.Model.Comparators;

namespace WMH.TabuSearch
{
    public class TabuList : ITabuList
    {
        private IList<EdgesAdded> tabuList = new List<EdgesAdded>();

        private int maxSize;

        /// <summary>
        /// Creates new tabu list.
        /// </summary>
        /// <param name="maxSize">Maximal size of tabu list.</param>
        public TabuList(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public bool IsOntabuList(EdgesAdded addedEdges)
        {
            foreach (var element in tabuList)
            {
                if (element.AreEqual(addedEdges))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddChange(EdgesAdded addedEdges)
        {
            // NOTICE: elements in addedEdges should be unique.

            tabuList.Add(addedEdges);
            if (tabuList.Count > this.maxSize)
            {
                tabuList.RemoveAt(0);
            }
        }
    }
}
