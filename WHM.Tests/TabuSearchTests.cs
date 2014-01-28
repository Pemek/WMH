using Moq;
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
    public class TabuSearchTests
    {
        private Mock<INeighbourFinder> neighbourFinderMock;
        private Mock<ITabuList> tabuListMock;
        private Mock<ILongTermMemory> longTermMemoryMock;
        private Mock<ICostFinder> costFinderMock;
        private Mock<IAspirationCriteria> aspirationCriteriaMock;
        private Mock<IStopCriteria> stopCriteriaMock;

        private TabuSearch tabuSearch;

        /// <summary>
        /// Setup method run before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.neighbourFinderMock = new Mock<INeighbourFinder>();
            this.tabuListMock = new Mock<ITabuList>();
            this.longTermMemoryMock = new Mock<ILongTermMemory>();
            this.costFinderMock = new Mock<ICostFinder>();
            this.aspirationCriteriaMock = new Mock<IAspirationCriteria>();
            this.stopCriteriaMock = new Mock<IStopCriteria>();

            tabuSearch = new TabuSearch(this.neighbourFinderMock.Object, this.tabuListMock.Object, this.longTermMemoryMock.Object, this.costFinderMock.Object, this.aspirationCriteriaMock.Object, this.stopCriteriaMock.Object, this.stopCriteriaMock.Object, this.stopCriteriaMock.Object);
        }

        [Test]
        public void FindSolution_WhenCriteriaAlreadyMeet_ReturnsInitialSolution()
        {
            // arrange
            var graph1 = this.CreateGraphWithNodes(1);
            var graph2 = this.CreateGraphWithNodes(1);
            this.stopCriteriaMock.Setup(m=>m.IsCriteriaMeet()).Returns(true);
            // act
            var result = this.tabuSearch.FindSolution(graph1, graph2);
            // assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(result[0].Start, graph1.Vertexes[0]);
            Assert.AreEqual(result[0].End, graph2.Vertexes[0]);
        }

        [Test]
        public void FindSolution_GraphWothDifferentVertexesCount_ThrowsException()
        {
            // arrange
            var graph1 = this.CreateGraphWithNodes(1);
            var graph2 = this.CreateGraphWithNodes(2);
            // act
            // assert
            Assert.Throws(typeof(ArgumentException), () => this.tabuSearch.FindSolution(graph1, graph2));
        }

        private Graph CreateGraphWithNodes(int nodes)
        {
            var graph = new Graph();
            var rand = new Random();
            for (int i = 0; i < nodes; i++)
            {
                graph.Vertexes.Add(new Vertex
                {
                    X = rand.NextDouble(),
                    Y = rand.NextDouble()
                });
            }

            return graph;
        }
    }
}
