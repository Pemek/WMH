using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WHM.Tests.Memory
{
    [TestFixture]
    class LongTermMemoryTests
    {
        [TestCase(10000, Result = 10000)]
        [TestCase(100, Result=100)]
        public int EdgeCount(int numEdge1)
        {
            WMH.Model.Vertex vertex1 = new WMH.Model.Vertex(100, 100);
            WMH.Model.Vertex vertex2 = new WMH.Model.Vertex(200, 200);

            WMH.Model.Edge edge1 = new WMH.Model.Edge(vertex1, vertex2);
            WMH.Model.Edge edge2 = new WMH.Model.Edge(vertex2, vertex1);

            WMH.Model.Memory.long_term_memory.LongTermMemory ltm = new WMH.Model.Memory.long_term_memory.LongTermMemory();
            for(int i=0; i < numEdge1; i++)
                ltm.addEdge(edge1);
            for (int i = 0; i < numEdge1; i++)
                ltm.addEdge(edge2);

            return ltm.getNumberOfAppearedEdge(edge1);
        }
    }
}
