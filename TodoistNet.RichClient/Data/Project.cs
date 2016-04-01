using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TodoistNet.RichClient.Data
{
    public class Project : TodoistObject
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public int Indent { get; set; }

        public int ItemOrder { get; set; }

        public int Collapsed { get; set; }

        public bool Shared { get; set; }

        public bool IsDeleted { get; set; }

        public int IsArchived { get; set; }

        public string ArchivedDate { get; set; }

        public long ArchivedTimestamp { get; set; }

        public bool IsInboxProject { get; set; }

        public bool IsTeamInbox { get; set; }

        public Project Parent { get; set; }

        public List<Project> Childs { get; set; }

        public List<Item> Items { get; set; }
    }
}
