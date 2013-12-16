using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMH.Model;

namespace WMH.TabuSearch
{
    public class NeighbourFinder : INeighbourFinder
    {
        public IList<Neighbour> FindNeighbours(IList<Model.Edge> solution)
        {
            var neighbours = new List<Neighbour>();
            foreach (var edge in solution)
            {
                foreach (var anotherEdge in solution.Skip(solution.IndexOf(edge)+1).ToList())
                {
                    var addedEdge1 = new Edge(edge.Start, anotherEdge.End);
                    var addedEdge2 = new Edge(anotherEdge.Start, edge.End);
                    var newSolution = new List<Edge>(solution);
                    newSolution.Remove(edge);
                    newSolution.Remove(anotherEdge);
                    newSolution.Add(addedEdge1);
                    newSolution.Add(addedEdge2);

                    neighbours.Add(new Neighbour
                    {
                        AddedEdges = new EdgesAdded(addedEdge1, addedEdge2),
                        // TODO Compute cost
                        Cost = 0,
                        NewSolution = newSolution
                    });
                }
            }

            return neighbours;
        }
    }
}
