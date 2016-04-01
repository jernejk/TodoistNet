using System.Runtime.Serialization;

namespace TodoistNet.RichClient.Data
{
    public class TodoistResources : TodoistBaseResponse
    {
        // TODO: Implement all commented properties
        //"Collaborators": [],
        //"DayOrdersTimestamp": "1344642991.1",

        public Note[] Notes { get; set; }

        public Label[] Labels { get; set; }

        public int UserId { get; set; }

        //"CollaboratorStates": [],
        //"DayOrders": {},
        //"LiveNotifications": [],
        public long SeqNumber { get; set; }

        public int WebStaticVersion { get; set; }

        public long LiveNotificationsLastRead { get; set; }

        //"User": {},
        public Filter[] Filters { get; set; }

        public Item[] Items { get; set; }

        //"Reminders": [],
        public Project[] Projects { get; set; }
    }
}
