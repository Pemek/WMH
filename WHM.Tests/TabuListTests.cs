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
            var addedEdges = this.CreateAddedEdges();
            // act
            // assert
            Assert.IsFalse(this.AddElementsAndCheck(new List<EdgesAdded>(), 10, addedEdges));
        }

        [Test]
        public void IsOntabuList_WhenElementNotOnTabuList_RetunsFalse()
        {
            // arrange
            var addedEdges1 = this.CreateAddedEdges();
            var addedEdges2 = this.CreateAddedEdges();
            // act
            // assert
            Assert.IsFalse(this.AddElementsAndCheck(new List<EdgesAdded> { addedEdges1 }, 10, addedEdges2));
        }

        [Test]
        public void IsOnTabuList_WhenElementIsOnList_ReturnsTrue()
        {
            // arrange
            var addedEdges1 = this.CreateAddedEdges();
            var addedEdges2 = this.CreateAddedEdges();
            // act
            // assert
            Assert.IsTrue(this.AddElementsAndCheck(new List<EdgesAdded> { addedEdges1, addedEdges2 }, 10, addedEdges1));
        }

        [Test]
        public void AddChange_WhenAddElement_AddsElement()
        {
            // arrange
            var addedEdges = this.CreateAddedEdges();
            // act
            // assert
            Assert.IsTrue(this.AddElementsAndCheck(new List<EdgesAdded>{ addedEdges }, 10, addedEdges));
        }

        [Test]
        public void AddChange_WhenMaxSize_FirstElementRemoved()
        {
            // arrange
            var list = new List<EdgesAdded>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(this.CreateAddedEdges());
            }
            // act
            // assert
            Assert.IsFalse(this.AddElementsAndCheck(list, 5, list[0]));
        }

        private bool AddElementsAndCheck(IList<EdgesAdded> elementsToAdd, int tabuListSize, EdgesAdded elementToCheck)
        {
            var tabuList = new TabuList(tabuListSize);
            foreach (var element in elementsToAdd)
            {
                tabuList.AddChange(element);
            }
            return tabuList.IsOntabuList(elementToCheck);
        }

        private EdgesAdded CreateAddedEdges()
        {
            return new EdgesAdded(this.CreateEdge(), this.CreateEdge());
        }

        private Edge CreateEdge()
        {
            var random = new Random();
            return new Edge(new Vertex(random.NextDouble(), random.NextDouble()), new Vertex(random.NextDouble(), random.NextDouble()));
        }
    }
}
