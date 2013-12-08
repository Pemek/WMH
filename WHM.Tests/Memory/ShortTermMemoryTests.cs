using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMH.Model;
using WMH.Model.Memory.short_term_memory;

namespace WHM.Tests.Memory
{
    [TestFixture]
    class ShortTermMemoryTests
    {
        //Edge number in graph (n(n-1)) /2
        [TestCase(5, Result = true)]
        public bool shortMemoryTests(int maxSize)
        {
            ShortTermMemory stm = new ShortTermMemory(maxSize);
            Graph graph = WMH.Model.GraphGenerator.GraphGenerator.generateGraph(maxSize);

            for(int i=0; i<maxSize; i++)
            {
                stm.addEdge(graph.Edges[i]);
            }
            for(int i=0; i<maxSize; i++)
            {
                if (!stm.searchEdge(graph.Edges[i]))
                    return false;
            }

            stm.addEdge(graph.Edges[0]);
            if (stm.count() != maxSize)
                return false;

            stm.addEdge(graph.Edges[maxSize]);
            if (stm.count() != maxSize)
                return false;

            for (int i = 1; i < maxSize+1; i++)
            {
                if (!stm.searchEdge(graph.Edges[i]))
                    return false;
            }

            return true;
        }
    }
}
