using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMH.Model.Comparators;

namespace WMH.Model
{
    public class EdgesAdded
    {
        public string guid;
        public int NumberOfOccurrences;
        public Edge Edge1 { get; set; }
        public Edge Edge2 { get; set; }

        public EdgesAdded(Edge edge1, Edge edge2)
        {
            Edge1 = edge1;
            Edge2 = edge2;
        }
    }
}
