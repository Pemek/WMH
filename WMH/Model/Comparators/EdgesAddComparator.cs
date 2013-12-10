using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model.Comparators
{
    public static class EdgesAddComparator
    {
        public static bool AreEqual(this EdgesAdded edges1, EdgesAdded edges2)
        {
            if ((edges1.Edge1.AreEqual(edges2.Edge1) && edges1.Edge2.AreEqual(edges2.Edge2))
                || (edges1.Edge1.AreEqual(edges2.Edge2) && edges1.Edge2.AreEqual(edges2.Edge1)))
                return true;
            return false;
        }
    }
}
