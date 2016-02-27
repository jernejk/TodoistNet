using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TodoistNet.Core.Commands
{
    [DataContract]
    public class TodoistCommand
    {
        public TodoistCommand(string type, TodoistCommandArgument args)
            : this(type, args, Guid.NewGuid())
        {
        }

        public TodoistCommand(string type, TodoistCommandArgument args, Guid tempId)
        {
            Type = type;
            Uuid = Guid.NewGuid();
            TempId = tempId;
            Args = args;
        }

        /// <summary>
        /// Gets or sets command GUID which is used when syncing.
        /// </summary>
        /// <remarks>This ID used by Todoist client API to generate unique ID for every request.</remarks>
        [DataMember(Name = "uuid", Order = 1)]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Gets or sets GUID for newly created Todoist object.
        /// </summary>
        [DataMember(Name = "temp_id", Order = 2)]
        public Guid TempId { get; set; }

        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        [DataMember(Name = "args", Order = 3)]
        public TodoistCommandArgument Args { get; set; }
    }
}
