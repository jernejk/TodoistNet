namespace TodoistNet.Core.Commands
{
    public static class TodoistCommands
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

        public const string NoteAdd = "note_add";
        public const string NoteUpdate = "note_update";
        public const string NoteDelete = "note_delete";

        public const string LabelAdd = "label_add";
        public const string LabelUpdate = "label_update";
        public const string LabelDelete = "label_delete";
        public const string LabelUpdateOrders = "label_update_orders";
    }
}
