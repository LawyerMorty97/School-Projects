using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public interface IItem
    {
        string  Name { get; set; }
        string  Condition { get; set; }
        string OfficialListing { get; set; }

        string  Auctioneer { get; set; }
        int     AuctioneerId { get; set; }

        string  Buyer { get; set; }
    }
}
