using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TodoistNet.RichClient.Data
{
    public class Item : TodoistObject
    {
        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public string Content { get; set; }

        public string DateString { get; set; }

        public string DateLang { get; set; }

        public string DueDateUtc { get; set; }

        public string DueDate { get; set; }

        public int Indent { get; set; }

        public int Priority { get; set; }

        public int ItemOrder { get; set; }

        public int DayOrder { get; set; }

        public int Collapsed { get; set; }

        public string Children { get; set; }

        public int[] LabelIds { get; set; }

        public int AssignedByUid { get; set; }

        public int? ResponsibleUid { get; set; }

        public int Checked { get; set; }

        public int InHistory { get; set; }

        public int IsDeleted { get; set; }

        public int IsArchived { get; set; }

        public long? SyncId { get; set; }

        public string DateAdded { get; set; }

        public Project Project { get; set; }

        public List<Note> Notes { get; set; }

        public List<Label> Labels { get; set; }
    }
}
