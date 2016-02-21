using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public class TodoistResources
    {
        // TODO: Implement all commented properties
        //"Collaborators": [],
        //"DayOrdersTimestamp": "1344642991.1",
        //"Notes": [],

        [DataMember(Name = "Notes")]
        public Note[] Notes { get; set; }

        [DataMember(Name = "Labels")]
        public Label[] Labels { get; set; }

        [DataMember(Name = "UserId")]
        public int UserId { get; set; }

        //"CollaboratorStates": [],
        //"DayOrders": {},
        //"LiveNotifications": [],
        [DataMember(Name = "seq_no")]
        public long SeqNumber { get; set; }

        [DataMember(Name = "WebStaticVersion")]
        public int WebStaticVersion { get; set; }

        [DataMember(Name = "LiveNotificationsLastRead")]
        public long LiveNotificationsLastRead { get; set; }

        //"User": {},
        //"Filters": [],
        [DataMember(Name = "Items")]
        public Item[] Items { get; set; }

        //"Reminders": [],
        [DataMember(Name = "Projects")]
        public Project[] Projects { get; set; }
    }
}
