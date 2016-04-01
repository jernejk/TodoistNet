using System.Collections.Generic;
using TodoistNet.Core.Data;

namespace TodoistNet.RichClient.Data
{
    public class Label : TodoistObject
    {
        public Label() { }

        public Label(WebLabel label)
        {
            Uid = label.Uid;
            Name = label.Name;
            Color = label.Color;
            ItemOrder = label.ItemOrder;
            IsDeleted = label.IsDeleted;
        }

        public int Uid { get; set; }

        public string Name { get; set; }

        public int Color { get; set; }

        public int ItemOrder { get; set; }

        public int IsDeleted { get; set; }

        public List<Item> Items { get; set; }
    }
}
