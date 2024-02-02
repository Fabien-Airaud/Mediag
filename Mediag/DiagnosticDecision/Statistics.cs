using System.Collections.Generic;

namespace Mediag.DiagnosticDecision
{
    class Statistics
    {
        public List<object[]> Set { get; set; }


        public Statistics() : this(new List<object[]>()) { }
        public Statistics(List<object[]> set) { Set = set; }
    }
}
