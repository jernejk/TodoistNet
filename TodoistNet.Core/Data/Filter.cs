using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public class Filter : TodoistObject
    {
  [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "query")]
        public string Query { get; set; }

        [DataMember(Name = "color")]
        public int Color { get; set; }

        [DataMember(Name = "item_order")]
        public int ItemOrder { get; set; }

        [DataMember(Name = "is_deleted")]
        public int IsDeleted { get; set; }
    }
}
