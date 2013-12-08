using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model.Memory.long_term_memory
{
    public class LongTermMemory
    {
        //number of occurrences all edge in application
        IDictionary<Guid, int> EdgeList;
        public LongTermMemory()
        {
            EdgeList = new Dictionary<Guid, int>();
        }
        public void addEdge(Edge edge)
        {
            EdgeAppeared edgeAppeared = new EdgeAppeared(edge.edgeGuid);
            if (EdgeList.ContainsKey(edge.edgeGuid))
                EdgeList[edge.edgeGuid]++;
            else
                EdgeList.Add(edge.edgeGuid, 1);
        }
        public bool ifEdgeIsOnTheList(Edge edge)
        {
            return EdgeList.ContainsKey(edge.edgeGuid);
        }

        public void clearMemory()
        {
            EdgeList.Clear();
        }
    }
}
