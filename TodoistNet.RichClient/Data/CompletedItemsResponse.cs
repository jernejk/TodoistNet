using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TodoistNet.RichClient.Data
{
    public class CompletedItemsResponse : TodoistBaseResponse
    {
        public Item[] Items { get; set; }

        // TODO: Parse weird [ id: { projectData } ] JSON structure.
        // It's almost like Dictionary<int, Project> but a bit different.
        //[DataMember(Name = "projects")]
        //public Dictionary<int, Project> Projects { get; set; }
    }
}
