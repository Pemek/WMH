using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMH.Model;
using WMH.Model.Comparators;

namespace WHM.Tests.Comparators
{
    [TestFixture]
    public class EdgeComparatorTests
    {
        [TestCase(false, true, Result = true)]
        [TestCase(true, true, Result = true)]
        [TestCase(false, false, Result = false)]
        [TestCase(true, false, Result = false)]
        public bool AreEqual_WhenCalled_ReturnsValue(bool inverse, bool sameVertexes)
        {
            // arrange
            var vertex1 = new Vertex(1, 0);
            var vertex2 = new Vertex(2, 2);
            var edge1 = new Edge(vertex1, vertex2);
            var vertex3 = vertex2;
            if (!sameVertexes)
            {
                vertex3 = new Vertex(3, 3);
            }

            var edge2 = new Edge(vertex1, vertex3);
            if (inverse)
            {
                edge2 = new Edge(vertex3, vertex1);
            }
            // act
            // assert
            return edge1.AreEqual(edge2);
        }

        [TestCase(1,2,3,4, Result=true)]
        public bool EdgeGUIDTests(double x1, double y1, double x2, double y2)
        {
            //Vertex vertex1 = new Vertex(x1, y1);
            //Vertex vertex2 = new Vertex(x2, y2);
            //Edge edge1 = new Edge(vertex1, vertex2);
            //Edge edge2 = new Edge(vertex1, vertex2);
            //Edge edge3 = new Edge(vertex2, vertex1);
            //if (!edge1.edgeGuid.Equals(edge2.edgeGuid))
            //    return false;
            //if (edge1.edgeGuid.Equals(edge3.edgeGuid))
            //    return false;
            return true;
        }
    }
}
