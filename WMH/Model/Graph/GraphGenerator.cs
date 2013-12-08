using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model.GraphGenerator
{
    public static class GraphGenerator
    {
        public static Graph generateGraph(int numberOfVertex)
        {
            Graph newGraph = generateVertex(numberOfVertex);
            createAllEdge(ref newGraph);

            return newGraph;
        }

        static private Graph generateVertex(int numberOfVertex)
        {
            Graph newGraph = new Graph();
            Random rand = new Random();
            for (int i = 0; i < numberOfVertex; i++)
            {
                Vertex newVertex = new Vertex(rand.NextDouble(), rand.NextDouble());
                if(itsAlreadyOnEdgesList(newVertex, ref newGraph))
                    continue;
                newGraph.Vertexes.Add(newVertex);
            }
            return newGraph;
        }

        static private bool itsAlreadyOnEdgesList(Vertex newVertex, ref Graph graph)
        {
            foreach (Vertex vertex in graph.Vertexes)
            {
                if (newVertex.X == vertex.X && newVertex.Y == vertex.Y)
                    return true;
            }
            return false;
        }

        private static void createAllEdge(ref Graph graph)
        {
            for (int edgeNumber = 0; edgeNumber < graph.Vertexes.Count; edgeNumber++)
            {
                createEdgeToAllOtherVertex(edgeNumber, ref graph);
            }
        }

        private static void createEdgeToAllOtherVertex(int vertexNumber ,ref Graph graph)
        {
            if (vertexNumber >= graph.Vertexes.Count)
                return;
            for (int i = vertexNumber+1; i < graph.Vertexes.Count; i++)
            {
                graph.Edges.Add(new Edge(graph.Vertexes[vertexNumber], graph.Vertexes[i]));
            }
        }
    }
}
