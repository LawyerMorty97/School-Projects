using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class ItemFactory
    {
        #region Variables
        private readonly List<Auctioneer> _auctioneers;
        #endregion

        #region Methods
        /// <summary>
        /// ItemFactory Constructor
        /// </summary>
        /// <param name="auctioneerList">The list of auctioneers that are created</param>
        public ItemFactory(List<Auctioneer> auctioneerList)
        {
            _auctioneers = auctioneerList;
        }

        /// <summary>
        /// Randomly picks an auctioneer from the list of auctions
        /// </summary>
        public Auctioneer GetAuctioneerRandomly()
        {
            int index = Utilities.GetRandomNumber(0, _auctioneers.Count);

            return _auctioneers[index];
        }

        /// <summary>
        /// Randomly picks an item and creates it
        /// </summary>
        /// <returns>Returns the item that was chosen to be created</returns>
        public IItem GetRandomItem()
        {
            const int items = 20;
            int i = Utilities.GetRandomNumber(0, items);
            IItem theItem;

            switch(i)
            {
                case 0:
                    theItem = new TornBook();
                    break;

                case 1:
                    theItem = new NewBook();
                    break;

                case 2:
                    theItem = new NewVase();
                    break;

                case 3:
                    theItem = new UsedVase();
                    break;

                case 4:
                    theItem = new BrokenVase();
                    break;

                case 5:
                    theItem = new NewTesla();
                    break;

                case 6:
                    theItem = new UsedTesla();
                    break;

                case 7:
                    theItem = new BrokenTesla();
                    break;

                case 8:
                    theItem = new NewLamp();
                    break;

                case 9:
                    theItem = new BrokenLamp();
                    break;

                case 10:
                    theItem = new UsedLamp();
                    break;

                case 11:
                    theItem = new NewiPhone();
                    break;

                case 12:
                    theItem = new BrokeniPhone();
                    break;

                case 13:
                    theItem = new UsediPhone();
                    break;

                case 14:
                    theItem = new NewiPad();
                    break;

                case 15:
                    theItem = new BrokeniPad();
                    break;

                case 16:
                    theItem = new UsediPad();
                    break;

                case 17:
                    theItem = new NewLaptop();
                    break;

                case 18:
                    theItem = new UsedLaptop();
                    break;

                case 19:
                    theItem = new BrokenLaptop();
                    break;

                default:
                    theItem = new DefaultBook();
                    break;

            }

            return theItem;
        }

        /// <summary>
        /// Creates an item
        /// </summary>
        /// <returns>Returns the item that was created</returns>
        public IItem CreateItem()
        {
            Auctioneer selected = GetAuctioneerRandomly();

            IItem item = GetRandomItem();

            item.Auctioneer = selected.Name;
            item.AuctioneerId = selected.AuctioneerId;

            selected.AuctioneerId += 1;
         
            return item;
        }
        #endregion
    }
}
