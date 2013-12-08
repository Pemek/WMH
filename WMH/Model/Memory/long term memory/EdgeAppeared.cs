using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMH.Model.Memory.long_term_memory
{
    class EdgeAppeared
    {
        public Guid guid;
        public int NumberOfOccurrences;

        public EdgeAppeared(Guid _guid)
        {
            guid = _guid;
        }
    }
}
