﻿using System;
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
        Queue<Guid> EdgeList;
        Guid GuidOfOldestEdge;
        //int MaxNumbersOfEdge;

        public ShortTermMemory(int numberOfEdgesInShortMemory)
        {
            //EdgeList = new Dictionary<Guid, bool>(numberOfEdgesInShortMemory);
            EdgeList = new Queue<Guid>(numberOfEdgesInShortMemory);
            //MaxNumbersOfEdge = numberOfEdgesInShortMemory;
        }

        public void addEdge(Edge edge)
        {
            if(!EdgeList.Contains(edge.edgeGuid))
                EdgeList.Enqueue(edge.edgeGuid);
        }
        //private void deleteEdge(Edge edge)
        //{
        //    EdgeList.Remove(edge.edgeGuid);
        //}
    }
}
