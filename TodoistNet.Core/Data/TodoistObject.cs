using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public abstract class TodoistObject
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
