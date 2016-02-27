using System.Runtime.Serialization;

namespace TodoistNet.Core.Commands
{
    public class LabelCommandArgument : TodoistCommandArgument
    {
        [DataMember(Name = "id", Order = 0, EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(Name = "name", Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = " color", Order = 2, EmitDefaultValue = false)]
        public int Color { get; set; }

        [DataMember(Name = "item_order", Order = 3, EmitDefaultValue = false)]
        public int ItemOrder { get; set; }

        public static LabelCommandArgument AddLabel(string name)
        {
            return new LabelCommandArgument { Name = name, Action = TodoistCommands.LabelAdd };
        }

        public static LabelCommandArgument UpdateLabel(int id)
        {
            return new LabelCommandArgument { Id = id, Action = TodoistCommands.LabelUpdate };
        }

        public static LabelCommandArgument DeleteLabel(int id)
        {
            return new LabelCommandArgument { Id = id, Action = TodoistCommands.LabelDelete };
        }

        // TODO: Add support for updating multiple orders
    }
}
