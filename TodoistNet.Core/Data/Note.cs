using System.Runtime.Serialization;

namespace TodoistNet.Core.Data
{
    [DataContract]
    public class Note : TodoistObject
    {
        [DataMember(Name = "posted_uid")]
        public int PostedUid { get; set; }

        [DataMember(Name = "project_id")]
        public int ProjectId { get; set; }

        [DataMember(Name = "item_id")]
        public int ItemId { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        //"file_attachment": {
        //  "file_type": "text/plain",
        //  "file_name": "File1.txt",
        //  "file_size": 1234,
        //  "file_url": "https://example.com/File1.txt",
        //  "upload_state": "completed"
        //},
        //[DataMember(Name = "uids_to_notify": null,

        [DataMember(Name = "is_deleted")]
        public int IsDeleted { get; set; }

        [DataMember(Name = "is_archived")]
        public int IsArchived { get; set; }

        [DataMember(Name = "posted")]
        public string Posted { get; set; }

        public Project Project { get; set; }

        public Item Item { get; set; }
    }
}
