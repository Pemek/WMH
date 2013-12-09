using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model.Memory.short_term_memory
{
    public class ShortTermMemory
    {
        //hold last n edges
        //IDictionary<Guid, bool> EdgeList;
        Queue<string> EdgeList;
        Guid GuidOfOldestEdge;
        int MaxNumbersOfEdge;

        public ShortTermMemory(int numberOfEdgesInShortMemory)
        {
            //EdgeList = new Dictionary<Guid, bool>(numberOfEdgesInShortMemory);
            EdgeList = new Queue<string>(numberOfEdgesInShortMemory);
            MaxNumbersOfEdge = numberOfEdgesInShortMemory;
        }

        public void addEdge(Edge edge)
        {
            if (EdgeList.Contains(edge.edgeGuid))
                return;
            if (EdgeList.Count >= MaxNumbersOfEdge)
                EdgeList.Dequeue();
            EdgeList.Enqueue(edge.edgeGuid);
        }
        public bool searchEdge(Edge edge)
        {
            return EdgeList.Contains(edge.edgeGuid);
        }
        public int count()
        {
            return EdgeList.Count;
        }
    }
}
