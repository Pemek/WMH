using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMH.Model;

namespace WMH.TabuSearch
{
    /// <summary>
    /// Interface for comunicating with tabu list.
    /// </summary>
    public interface ITabuList
    {
        /// <summary>
        /// Checks if given change (adding edges) is on tabu list.
        /// </summary>
        /// <param name="addedEdges">List of 2 added edges.</param>
        /// <returns>True if given edges change is on tabu list.</returns>
        bool IsOntabuList(IList<Edge> addedEdges);

        /// <summary>
        /// Adds list of 2 edges to tabu list.
        /// </summary>
        /// <param name="addedEdges">List of 2 edges that were added to solution and should be added to tabu list.</param>
        void AddChange(IList<Edge> addedEdges);
    }
}
