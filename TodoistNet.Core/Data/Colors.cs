using System.Collections.Generic;

namespace TodoistNet.Core.Data
{
    public class Colors
    {
        public IReadOnlyList<string> HexValues = new List<string>(new string[]
        {
            "95ef63", "ff8581", "ffc471", "f9ec75", "a8c8e4", "d2b8a3", "e2a8e4", "cccccc", "fb886e", "ffcc00", "74e8d3", "3bd5fb",

            // Colors available to Premium users.
            "dc4fad", "ac193d", "d24726", "82ba00", "03b3b2", "008299", "5db2ff", "0072c6", "000000", "777777"
        });
    }
}
