using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMH.Model;
using WMH.TabuSearch;

namespace WHM.Tests
{
    [TestFixture]
    public class CostFinderTests
    {
        [TestCase(new double[] { 0 }, new double[] { 0 }, new double[] { 1 }, new double[] { 0 }, 1.0)]
        [TestCase(new double[] { 0 }, new double[] { 0 }, new double[] { 0 }, new double[] { 1 }, 1.0)]
        [TestCase(new double[] { 1 }, new double[] { 0 }, new double[] { 0 }, new double[] { 0 }, 1.0)]
        [TestCase(new double[] { 0 }, new double[] { 1 }, new double[] { 0 }, new double[] { 0 }, 1.0)]
        [TestCase(new double[] { 0 }, new double[] { 1 }, new double[] { 0 }, new double[] { 1 }, 0.0)]
        [TestCase(new double[] { 0, 0 }, new double[] { 1, 0 }, new double[] { 0, 1 }, new double[] { 0, 0 }, 2.0)]
        public void GetCost_WhenCalled_ComputesCost(double[] xStarts, double[] yStarts, double[] xEnds, double[] yEnds, double result)
        {
            this.GetCost_WhenCalled_ComputesCost(xStarts, yStarts, xEnds, yEnds, result, 1.0);
        }

        [TestCase(new double[] { 0, 1 }, new double[] { 0, 0 }, new double[] { 1, 0 }, new double[] { 1, 0 }, 1.0, 2.0)]
        public void GetCost_WhenCalled_ComputesCost(double[] xStarts, double[] yStarts, double[] xEnds, double[] yEnds, double result, double sqrt)
        {
            // arrange
            var edges = this.CreateSolution(xStarts, yStarts, xEnds, yEnds);
            var costFinder = new CostFinder();
            // act
            // assert
            if (sqrt != 1.0)
            {
                result += Math.Sqrt(sqrt);
            }
            Assert.AreEqual(result, costFinder.GetCost(edges));
        }

        private IList<Edge> CreateSolution(double[] xStarts, double[] yStarts, double[] xEnds, double[] yEnds)
        {
            var result = new List<Edge>();
            for (int i = 0; i < xStarts.Length; i++)
            {
                result.Add(new Edge(new Vertex(xStarts[i], yStarts[i]), new Vertex(xEnds[i], yEnds[i])));
            }
            return result;
        }
    }
}
