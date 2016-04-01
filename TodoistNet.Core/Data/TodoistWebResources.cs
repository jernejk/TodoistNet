using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public class TodoistWebResources : TodoistBaseResponse
    {
        // TODO: Implement all commented properties
        //"Collaborators": [],
        //"DayOrdersTimestamp": "1344642991.1",

        [DataMember(Name = "Notes")]
        public WebNote[] Notes { get; set; }

        [DataMember(Name = "Labels")]
        public WebLabel[] Labels { get; set; }

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
        [DataMember(Name = "Filters")]
        public WebFilter[] Filters { get; set; }

        [DataMember(Name = "Items")]
        public WebItem[] Items { get; set; }

        //"Reminders": [],
        [DataMember(Name = "Projects")]
        public WebProject[] Projects { get; set; }
    }
}
