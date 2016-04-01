using System.Runtime.Serialization;

namespace TodoistNet.RichClient.Data
{
    public class Note : TodoistObject
    {
        public int PostedUid { get; set; }

        public int ProjectId { get; set; }

        public int ItemId { get; set; }

        public string Content { get; set; }

        //"file_attachment": {
        //  "file_type": "text/plain",
        //  "file_name": "File1.txt",
        //  "file_size": 1234,
        //  "file_url": "https://example.com/File1.txt",
        //  "upload_state": "completed"
        //},
        //[DataMember(Name = "uids_to_notify": null,

        public int IsDeleted { get; set; }

        public int IsArchived { get; set; }

        public string Posted { get; set; }

        public Project Project { get; set; }

        public Item Item { get; set; }
    }
}
