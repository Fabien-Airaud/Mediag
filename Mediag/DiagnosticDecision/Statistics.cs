using System.Collections.Generic;

namespace Mediag.DiagnosticDecision
{
    class Statistics
    {
        public List<object[]> Set { get; set; } = new List<object[]>();


        public Statistics() { }
        public Statistics(List<object[]> set) { Set = set; }
    }
}
