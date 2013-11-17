using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMH.Model;

namespace WMH.TabuSearch
{
    /// <summary>
    /// Interface for comunicating with long term memory.
    /// </summary>
    public interface ILongTermMemory
    {
        /// <summary>
        /// Adds list of 2 edges to long term memory.
        /// </summary>
        /// <param name="addedEdges">List of 2 edges that were added to solution and should be added to long term memory.</param>
        void AddChange(IList<Edge> addedEdges);
    }
}
