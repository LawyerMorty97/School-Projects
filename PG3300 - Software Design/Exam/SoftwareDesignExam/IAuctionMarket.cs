using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public interface IAuctionMarket
    {
        void AddItem();
        void RemoveItem(List<IItem> list);
        Buyer GetBuyer();
        IItem GetItem();
        void BuyItem();
    }
}
