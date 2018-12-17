using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class NewBook : IItem
    {
        public string Name { get; set; }
        public string Condition { get; set; }
        public string Auctioneer { get; set; }
        public int AuctioneerId { get; set; }
        public string Buyer { get; set; }

        public NewBook()
        {
            Name = ItemStrings.book;
            Condition = ItemStrings.new_condition;
        }
    }
}
