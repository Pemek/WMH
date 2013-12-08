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
        public int generateGraph_NumberOfVertex_Tests(int numberOfVertex)
        {
            WMH.Model.Graph graph = WMH.Model.GraphGenerator.GraphGenerator.generateGraph(numberOfVertex);
            return graph.Vertexes.Count;
        }

        //(n(n-1))/2
        [TestCase(5, Result=true)]
        [TestCase(100, Result=true)]
        public bool generateGraph_NumberOfEdge_Tests(int numberOfVertex)
        {
            WMH.Model.Graph graph = WMH.Model.GraphGenerator.GraphGenerator.generateGraph(numberOfVertex);
            if ((numberOfVertex * (numberOfVertex - 1) / 2) == graph.Edges.Count)
                return true;
            return false;
        }
    }
}
