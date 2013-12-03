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
        private IList<IList<Edge>> tabuList = new List<IList<Edge>>();

        private int maxSize;

        /// <summary>
        /// Creates new tabu list.
        /// </summary>
        /// <param name="maxSize">Maximal size of tabu list.</param>
        public TabuList(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public bool IsOntabuList(IList<Model.Edge> addedEdges)
        {
            foreach (var subList in tabuList)
            {
                if (this.CompareLists(subList, addedEdges))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CompareLists(IList<Edge> subList, IList<Edge> addedEdges)
        {
            if (subList.Count != addedEdges.Count)
            {
                return false;
            }

            foreach (var edge in addedEdges)
            {
                var foundEdge = subList.FirstOrDefault(e => e.AreEqual(edge));

                //  NOTICE: elements in added edge should be unique
                if (foundEdge == null)
                {
                    return false;
                }
            }

            return true;
        }

        public void AddChange(IList<Model.Edge> addedEdges)
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
