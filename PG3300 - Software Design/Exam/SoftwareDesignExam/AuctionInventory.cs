using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class AuctionInventory : IAuctionInventory
    {
        public int TotalItems { get; private set; }
        public int Customers { get; private set; }

        public List<Auctioneer> auctioneerList;
        public List<Buyer> buyerList;
        public List<IItem> forSale;

        private Populator _populator;

        /// <summary>
        /// Creates all lists that are used for data storage.
        /// </summary>
        public AuctionInventory()
        {
            auctioneerList = new List<Auctioneer>();
            buyerList = new List<Buyer>();
            forSale = new List<IItem>();

            _populator = new Populator();

            if (!Utilities.IsUnitTestRunning)
            {
                _populator.PopulateAuctioneersList(auctioneerList);
                Customers = _populator.PopulateBuyerList(4, buyerList);
            }
        }

        /// <summary>
        /// Creates and adds a new auctioneer
        /// </summary>
        /// <param name="name">The name of the auctioneer to create</param>
        public void AddAuctioneer(string name)
        {
            Auctioneer auctioneer = new Auctioneer(name, 1);
            auctioneerList.Add(auctioneer);
        }

        /// <summary>
        /// Creates and adds a new buyer
        /// </summary>
        /// <param name="name">The name of the buyer to create</param>
        public void AddBuyer(string name)
        {
            Customers += 1;
            Buyer buyer = new Buyer(name);
            buyerList.Add(buyer);
        }

        /// <summary>
        /// Increments properties when items are added for sale
        /// </summary>
        public void AddItem(IItem item)
        {
            forSale.Add(item);
            TotalItems += 1;
        }
    }
}
