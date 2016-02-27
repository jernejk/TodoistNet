using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public class TodoistBaseResponse
    {
        [DataMember(Name = "error_tag", EmitDefaultValue = false)]
        public string ErrorTag { get; set; }

        [DataMember(Name = "error_code", EmitDefaultValue = false)]
        public int? ErrorCode { get; set; }

        [DataMember(Name = "error_extra", EmitDefaultValue = false)]
        public Dictionary<string, string> ErrorExtra { get; set; }

        [DataMember(Name = "error", EmitDefaultValue = false)]
        public string Error { get; set; }

        public bool ContainsErrors { get { return ErrorCode.HasValue; } }
    }
}
