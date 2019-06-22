using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Condition { get; set; }
        public string OfficialListing { get; set; }

        public string Auctioneer { get; set; }
        public int AuctioneerId { get; set; }
        public string Buyer { get; set; }

        public Item(string name, ItemStrings.Condition condition)
        {
            Name = name;
            Condition = ItemStrings.GetConditionString(condition);
            OfficialListing = Condition.ToLower() + " " + Name;
        }
    }
}
