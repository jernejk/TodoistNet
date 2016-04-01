using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public abstract class TodoistWebObject
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
