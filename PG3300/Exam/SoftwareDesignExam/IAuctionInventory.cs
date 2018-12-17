using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public interface IAuctionInventory
    {
        void AddAuctioneer(string name);
        void AddBuyer(string name);
        void AddItem(IItem item);
    }
}
