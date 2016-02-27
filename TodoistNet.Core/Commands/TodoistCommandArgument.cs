using System.Runtime.Serialization;

namespace TodoistNet.Core.Commands
{
    [DataContract]
    public abstract class TodoistCommandArgument
    {
        public string Action { get; set; }
    }
}
