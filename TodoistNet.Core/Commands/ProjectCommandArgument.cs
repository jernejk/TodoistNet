using System.Runtime.Serialization;

namespace TodoistNet.Core.Commands
{
    [DataContract]
    public class ProjectCommandArgument : TodoistCommandArgument
    {
        public ProjectCommandArgument(string name)
        {
            Name = name;
        }

        [DataMember(Name = "name", Order = 0, IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Name = "color", Order = 3, EmitDefaultValue = false, IsRequired = false)]
        public int? Color {get;set;}

        [DataMember(Name = "indent", Order = 2, EmitDefaultValue = false, IsRequired = false)]
        public int? Indent { get; set; }

        [DataMember(Name = "Item_order", Order = 1, EmitDefaultValue = false, IsRequired = false)]
        public int? ItemOrder { get; set; }

        [DataMember(Name = "collapsed", Order = 4, EmitDefaultValue = false, IsRequired = false)]
        public int? Collapsed { get; set; }
    }
}
