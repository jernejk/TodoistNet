using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TodoistNet.Core.Data.Commands
{
    [DataContract]
    public class TodoistCommand
    {
        public const string ProjectAdd = "project_add";
        public const string ProjectUpdate = "project_update";
        public const string ProjectDelete = "project_delete";
        public const string ProjectArchive = "project_archive";
        public const string ProjectUnarchive = "project_unarchive";
        public const string ProjectUpdateOrdersIndents = "project_update_orders_indents";

        public const string ItemAdd = "item_add";
        public const string ItemUpdate = "item_update";
        public const string ItemDelete = "item_delete";
        public const string ItemMove = "item_move";
        public const string ItemComplete = "item_complete";
        public const string ItemUncomplete = "item_uncomplete";
        public const string ItemUpdateDateComplete = "item_update_date_complete";
        public const string ItemClose = "item_close";
        public const string ItemUpdateOrdersIndents = "item_update_orders_indents";
        public const string ItemUpdateDayOrders = "item_update_day_orders";

        public TodoistCommand(string type, TodoistCommandArgument args)
        {
            Type = type;
            Uuid = Guid.NewGuid();
            TempId = Guid.NewGuid();
            Args = args;
        }

        /// <summary>
        /// Gets or sets command GUID which is used when syncing.
        /// </summary>
        /// <remarks>This ID used by Todoist client API to generate unique ID for every request.</remarks>
        [DataMember(Name = "uuid", Order = 1)]
        public Guid Uuid { get; set; }

        /// <summary>
        /// Gets or sets GUID for newly created Todoist object.
        /// </summary>
        [DataMember(Name = "temp_id", Order = 2)]
        public Guid TempId { get; set; }

        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        [DataMember(Name = "args", Order = 3)]
        public TodoistCommandArgument Args { get; set; }
    }
}
