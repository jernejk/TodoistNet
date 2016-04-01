using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public class WebItem : TodoistWebObject
    {
        [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        [DataMember(Name = "project_id")]
        public int ProjectId { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "date_string")]
        public string DateString { get; set; }

        [DataMember(Name = "date_lang")]
        public string DateLang { get; set; }

        [DataMember(Name = "due_date_utc")]
        public string DueDateUtc { get; set; }

        [DataMember(Name = "due_date")]
        public string DueDate { get; set; }

        [DataMember(Name = "indent")]
        public int Indent { get; set; }

        [DataMember(Name = "priority")]
        public int Priority { get; set; }

        [DataMember(Name = "item_order")]
        public int ItemOrder { get; set; }

        [DataMember(Name = "day_order")]
        public int DayOrder { get; set; }

        [DataMember(Name = "collapsed")]
        public int Collapsed { get; set; }

        [DataMember(Name = "children")]
        public string Children { get; set; }

        [DataMember(Name = "labels")]
        public int[] LabelIds { get; set; }

        [DataMember(Name = "assigned_by_uid")]
        public int AssignedByUid { get; set; }

        [DataMember(Name = "responsible_uid")]
        public int? ResponsibleUid { get; set; }

        [DataMember(Name = "checked")]
        public int Checked { get; set; }

        [DataMember(Name = "in_history")]
        public int InHistory { get; set; }

        [DataMember(Name = "is_deleted")]
        public int IsDeleted { get; set; }

        [DataMember(Name = "is_archived")]
        public int IsArchived { get; set; }

        [DataMember(Name = "sync_id")]
        public long? SyncId { get; set; }

        [DataMember(Name = "date_added")]
        public string DateAdded { get; set; }

        public WebProject Project { get; set; }

        public List<WebNote> Notes { get; set; }

        public List<WebLabel> Labels { get; set; }
    }
}
