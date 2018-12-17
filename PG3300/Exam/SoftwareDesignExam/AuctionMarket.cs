using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class AuctionMarket : IAuctionMarket
    {
        #region Variables and Properties
        public AuctionInventory             inventory;

        private ProxyThread                 _threads;
        private ConsoleOutput               _output;
        private ItemFactory                 _factory;
        private static readonly object      _buyLock = new object();

        private int                         _chosenItems = 0;
        #endregion

        #region Methods
        /// <summary>
        /// Create an instance of the AuctionMarket object
        /// </summary>
        /// <param name="output">Contains the object used for printing results of actions.</param>
        public AuctionMarket(int itemsToSell)
        {
            _chosenItems = itemsToSell;
            _output = new ConsoleOutput();
            _threads = new ProxyThread(5);
            _threads.CreateThreads(BuyItem);

            inventory = new AuctionInventory();

            if (Utilities.IsUnitTestRunning)
            {
                inventory.AddAuctioneer("Test Auctioneer");
                inventory.AddBuyer("Test Buyer");
            }

            _factory = new ItemFactory(inventory.auctioneerList);
        }

        public void Start()
        {
            bool reiterate = false;
            addRemainingItems:
            for (int i = 0; i < _chosenItems; i++)
            {
                if (reiterate)
                {
                    AddItem();
                    _threads.StartAdditionalThread(BuyItem);
                    break;
                }

                if (i < _threads.Length)
                {
                    AddItem();
                    _threads.StartThread();
                }
            }

            if (_chosenItems > inventory.TotalItems)
            {
                reiterate = true;
                goto addRemainingItems;
            }

            Utilities.Sleep(Utilities.GetRandomNumber(200, 1000));

            _output.PrintEndAuction(inventory.Customers, inventory.TotalItems);
            _threads.StopThreads();
        }

        /// <summary>
        /// Adds an item to the auction
        /// </summary>
        public void AddItem()
        {
            IItem item = _factory.CreateItem();
            inventory.AddItem(item);
            _output.PrintAuctionListing(item);
        }
        /// <summary>
        /// Removes an item from postion zero in the list.
        /// </summary>
        /// <param name="list">The list where all buyers will be held</param>
        public void RemoveItem(List<IItem> list)
        {
            list.RemoveAt(0);
        }

        /// <summary>
        /// Retrieves a random buyer from the auction
        /// </summary>
        public Buyer GetBuyer()
        {
            int index = Utilities.GetRandomNumber(0, inventory.buyerList.Count);

            return inventory.buyerList[index];
        }

        /// <summary>
        /// Retrieves the first item that is for sale
        /// </summary>
        public IItem GetItem()
        {
            IItem tmp = null;
            if (  inventory.forSale.Count > 0) {
                tmp = inventory.forSale[0];
                RemoveItem(inventory.forSale);
                //inventory.RemoveItem(0);
            }

            return tmp;
        }

        /// <summary>
        /// Performs the purchase on an item from a Buyer
        /// </summary>
        public void BuyItem()
        {
            IItem selectedItem;
            
            lock (_buyLock)
            {        
                selectedItem = GetItem();  
            }

            if (selectedItem == null)
            {
                return;
            }
            Buyer selectedBuyer = GetBuyer();
            selectedItem.Buyer = selectedBuyer.Name;


            _output.PrintTransaction(selectedItem);
        }

        #endregion
    }
}
