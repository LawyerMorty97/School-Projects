using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public interface IConsoleOutput
    {
        void PrintTransaction(IItem soldItem);
        void PrintAuctionListing(IItem itemToSell);
        void PrintEndAuction(int buyers, int items);
    }
}
