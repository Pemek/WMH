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
    public class TabuListTests
    {
        [Test]
        public void IsOntabuList_WithEmptyTabuList_ReturnsFalse()
        {
            // arrange
            var list = this.CreateEdgeList(1);
            // act
            // assert
            Assert.IsFalse(this.AddElementsAndCheck(new List<IList<Edge>>(), 10, list));
        }

        [Test]
        public void IsOntabuList_WhenElementNotOnTabuList_RetunsFalse()
        {
            // arrange
            var list = this.CreateEdgeList(1);
            var list2 = this.CreateEdgeList(1);
            // act
            // assert
            Assert.IsFalse(this.AddElementsAndCheck(new List<IList<Edge>> { list }, 10, list2));
        }

        [Test]
        public void IsOnTabuList_WhenElementIsOnList_ReturnsTrue()
        {
            // arrange
            var list = this.CreateEdgeList(1);
            var list2 = new List<Edge>{ new Edge(list[0].End, list[0].Start) };
            // act
            // assert
            Assert.IsTrue(this.AddElementsAndCheck(new List<IList<Edge>> { list }, 10, list2));
        }

        [Test]
        public void AddChange_WhenAddElement_AddsElement()
        {
            // arrange
            var list = this.CreateEdgeList(2);
            // act
            // assert
            Assert.IsTrue(this.AddElementsAndCheck(new List<IList<Edge>>{ list }, 10, list));
        }

        [Test]
        public void AddChange_WhenMaxSize_FirstElementRemoved()
        {
            // arrange
            var list = new List<IList<Edge>>();
            for (int i = 0; i < 2; i++)
            {
                list.Add(this.CreateEdgeList(2));
            }
            // act
            // assert
            Assert.IsFalse(this.AddElementsAndCheck(list, 1, list[0]));
        }

        private bool AddElementsAndCheck(IList<IList<Edge>> elementsToAdd, int tabuListSize, IList<Edge> elementToCheck)
        {
            var tabuList = new TabuList(tabuListSize);
            foreach (var element in elementsToAdd)
            {
                tabuList.AddChange(element);
            }
            return tabuList.IsOntabuList(elementToCheck);
        }

        private IList<Edge> CreateEdgeList(int count)
        {
            IList<Edge> result = new List<Edge>();
            var random = new Random();
            for (var i = 0; i < count; i++)
            {
                result.Add(new Edge(new Vertex(random.NextDouble(), random.NextDouble()), new Vertex(random.NextDouble(), random.NextDouble())));
            }
            return result;
        }
    }
}
