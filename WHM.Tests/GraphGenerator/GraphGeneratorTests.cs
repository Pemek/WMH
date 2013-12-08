using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WHM.Tests.GraphGenerator
{
    [TestFixture]
    class GraphGeneratorTests
    {
        [TestCase(100, Result=100)]
        [TestCase(5, Result=5)]
        public int generateGraphTests(int numberOfVertex)
        {
            WMH.Model.Graph graph = WMH.Model.GraphGenerator.GraphGenerator.generateGraph(numberOfVertex);
            return graph.Vertexes.Count;
        }
    }
}
