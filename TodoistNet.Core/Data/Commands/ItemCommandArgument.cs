using System.Runtime.Serialization;

namespace TodoistNet.Core.Data.Commands
{
    [DataContract]
    public class ItemCommandArgument : TodoistCommandArgument
    {
        public ItemCommandArgument(string content)
        {
            Content = content;
        }

        public ItemCommandArgument(long id)
        {
            Id = id;
        }

        [DataMember(Name = "id", Order = 0, EmitDefaultValue = false)]
        public long Id { get; set; }

        [DataMember(Name = "content", Order = 0)]
        public string Content { get; set; }

        [DataMember(Name = "project_id", Order = 1, EmitDefaultValue = false)]
        public string ProjectId { get; set; }

        [DataMember(Name = "date_string", Order = 1, EmitDefaultValue = false)]
        public string DateString { get; set; }

        [DataMember(Name = "date_lang", Order = 1, EmitDefaultValue = false)]
        public string DateLang { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM
        /// </summary>
        [DataMember(Name = "due_date_utc", Order = 1, EmitDefaultValue = false)]
        public string DueDateUtc { get; set; }

        [DataMember(Name = "priority", Order = 1, EmitDefaultValue = false)]
        public int? Priority { get; set; }

        [DataMember(Name = "indent", Order = 1, EmitDefaultValue = false)]
        public int? Indent { get; set; }

        [DataMember(Name = "item_order", Order = 1, EmitDefaultValue = false)]
        public int? ItemOrder { get; set; }

        [DataMember(Name = "day_order", Order = 1, EmitDefaultValue = false)]
        public int? DayOrder { get; set; }

        [DataMember(Name = "collapsed", Order = 1, EmitDefaultValue = false)]
        public int? Collapsed { get; set; }

        [DataMember(Name = "labels", Order = 1, EmitDefaultValue = false)]
        public int[] Labels { get; set; }

        [DataMember(Name = "assigned_by_uid", Order = 1, EmitDefaultValue = false)]
        public int? AssignedByUid { get; set; }

        [DataMember(Name = "responsible_uid", Order = 1, EmitDefaultValue = false)]
        public int? ResponsibleUid { get; set; }
    }
}
