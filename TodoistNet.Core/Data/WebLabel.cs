using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public class WebLabel : TodoistWebObject
    {
        [DataMember(Name = "uid")]
        public int Uid { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "color")]
        public int Color { get; set; }

        [DataMember(Name = "item_order")]
        public int ItemOrder { get; set; }

        [DataMember(Name = "is_deleted")]
        public int IsDeleted { get; set; }

        public List<WebItem> Items { get; set; }
    }
}
