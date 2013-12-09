using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model.Comparators
{
    public static class EdgeComparator
    {
        /// <summary>
        /// Compares another edge to edge. Returns true if both edges has same vertexes.
        /// </summary>
        /// <param name="edge">This edge</param>
        /// <param name="anotherEdge">Edge to compare</param>
        /// <returns>True if another edge has same vertexes.</returns>
        public static bool AreEqual(this Edge edge, Edge anotherEdge)
        {
            return (edge.Start.Equals(anotherEdge.Start) && edge.End.Equals(anotherEdge.End)) || (edge.Start.Equals(anotherEdge.End) && edge.End.Equals(anotherEdge.Start));
        }
        public static bool AreEqualByGuid(this Edge edge, Edge anotherEdge)
        {
            if (edge.edgeGuid.Equals(anotherEdge.edgeGuid))
                return true;
            return false;
        }
    }
}
