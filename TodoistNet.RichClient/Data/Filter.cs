using System.Runtime.Serialization;
using TodoistNet.Core.Data;

namespace TodoistNet.RichClient.Data
{
    public class Filter : TodoistObject
    {
        public Filter() { }

        public Filter(WebFilter filter)
        {
            UserId = filter.UserId;
            Name = filter.Name;
            Query = filter.Query;
            Color = filter.Color;
            ItemOrder = filter.ItemOrder;
            IsDeleted = filter.IsDeleted;
        }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Query { get; set; }

        public int Color { get; set; }

        public int ItemOrder { get; set; }

        public int IsDeleted { get; set; }
    }
}
