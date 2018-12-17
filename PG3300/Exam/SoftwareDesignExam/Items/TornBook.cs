using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class TornBook : IItem
    {
        public string Name { get; set; }
        public string Condition { get; set; }
        public string Auctioneer { get; set; }
        public int AuctioneerId { get; set; }
        public string Buyer { get; set; }

        public TornBook()
        {
            Name = ItemStrings.book;
            Condition = ItemStrings.torn_condition;
        }
    }
}
