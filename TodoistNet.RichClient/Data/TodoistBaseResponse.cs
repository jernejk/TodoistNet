using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TodoistNet.RichClient.Data
{
    public class TodoistBaseResponse
    {
        public string ErrorTag { get; set; }

        public int? ErrorCode { get; set; }

        public Dictionary<string, string> ErrorExtra { get; set; }

        public string Error { get; set; }

        public bool ContainsErrors { get { return ErrorCode.HasValue; } }
    }
}
