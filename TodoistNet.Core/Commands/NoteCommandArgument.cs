using System;
using System.Runtime.Serialization;

namespace TodoistNet.Core.Commands
{
    [DataContract]
    public class NoteCommandArgument : TodoistCommandArgument
    {
        [DataMember(Name = "id", Order = 0, EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(Name = "item_id", Order = 0, EmitDefaultValue = false)]
        public string ItemId { get; set; }

        [DataMember(Name = "project_id", Order = 0, EmitDefaultValue = false)]
        public string ProjectId { get; set; }

        [DataMember(Name = "content", Order = 1, EmitDefaultValue = false)]
        public string Content { get; set; }

        // TODO: Add file attachments
        
        public static NoteCommandArgument AddNote(int itemId, string content)
        {
            return new NoteCommandArgument { ItemId = itemId.ToString(), Content = content, Action = TodoistCommands.NoteAdd };
        }

        public static NoteCommandArgument AddNote(Guid tempItemId, string content)
        {
            return new NoteCommandArgument { ItemId = tempItemId.ToString(), Content = content, Action = TodoistCommands.NoteAdd };
        }

        public static NoteCommandArgument AddProjectNote(int projectId, string content)
        {
            return new NoteCommandArgument { ProjectId = projectId.ToString(), Content = content, Action = TodoistCommands.NoteAdd };
        }

        public static NoteCommandArgument AddProjectNote(Guid tempProjectId, string content)
        {
            return new NoteCommandArgument { ProjectId = tempProjectId.ToString(), Content = content, Action = TodoistCommands.NoteAdd };
        }

        public static NoteCommandArgument UpdateNote(int id, string content)
        {
            return new NoteCommandArgument { Id = id, Content = content, Action = TodoistCommands.NoteUpdate };
        }

        public static NoteCommandArgument DeleteNote(int id)
        {
            return new NoteCommandArgument { Id = id, Action = TodoistCommands.NoteDelete };
        }
    }
}
