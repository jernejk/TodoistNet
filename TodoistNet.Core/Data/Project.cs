using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public class Project : TodoistObject
    {
        [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "indent")]
        public int Indent { get; set; }

        [DataMember(Name = "item_order")]
        public int ItemOrder { get; set; }

        [DataMember(Name = "collapsed")]
        public int Collapsed { get; set; }

        [DataMember(Name = "shared")]
        public bool Shared { get; set; }

        [DataMember(Name = "is_deleted")]
        public bool IsDeleted { get; set; }

        [DataMember(Name = "is_archived")]
        public int IsArchived { get; set; }

        [DataMember(Name = "archived_date")]
        public string ArchivedDate { get; set; }

        [DataMember(Name = "archived_timestamp")]
        public long ArchivedTimestamp { get; set; }

        [DataMember(Name = "inbox_project")]
        public bool IsInboxProject { get; set; }

        [DataMember(Name = "team_inbox")]
        public bool IsTeamInbox { get; set; }

        public Project Parent { get; set; }

        public List<Project> Childs { get; set; }

        public List<Item> Items { get; set; }
    }
}
