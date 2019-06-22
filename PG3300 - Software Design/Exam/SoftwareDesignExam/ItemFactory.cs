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
                    theItem = new Item("Book", ItemStrings.Condition.Torn);
                    break;

                case 1:
                    theItem = new Item("Book", ItemStrings.Condition.New);
                    break;

                case 2:
                    theItem = new Item("Vase", ItemStrings.Condition.New);
                    break;

                case 3:
                    theItem = new Item("Vase", ItemStrings.Condition.Used);
                    break;

                case 4:
                    theItem = new Item("Vase", ItemStrings.Condition.Broken);
                    break;

                case 5:
                    theItem = new Item("Tesla", ItemStrings.Condition.New);
                    break;

                case 6:
                    theItem = new Item("Tesla", ItemStrings.Condition.Used);
                    break;

                case 7:
                    theItem = new Item("Tesla", ItemStrings.Condition.Broken);
                    break;

                case 8:
                    theItem = new Item("Lamp", ItemStrings.Condition.New);
                    break;

                case 9:
                    theItem = new Item("Lamp", ItemStrings.Condition.Broken);
                    break;

                case 10:
                    theItem = new Item("Lamp", ItemStrings.Condition.Used);
                    break;

                case 11:
                    theItem = new Item("iPhone", ItemStrings.Condition.New);
                    break;

                case 12:
                    theItem = new Item("iPhone", ItemStrings.Condition.Broken);
                    break;

                case 13:
                    theItem = new Item("iPhone", ItemStrings.Condition.Used);
                    break;

                case 14:
                    theItem = new Item("iPad", ItemStrings.Condition.New);
                    break;

                case 15:
                    theItem = new Item("iPad", ItemStrings.Condition.Broken);
                    break;

                case 16:
                    theItem = new Item("iPad", ItemStrings.Condition.Used);
                    break;

                case 17:
                    theItem = new Item("Macbook Pro", ItemStrings.Condition.New);
                    break;

                case 18:
                    theItem = new Item("Macbook Pro", ItemStrings.Condition.Broken);
                    break;

                case 19:
                    theItem = new Item("Macbook Pro", ItemStrings.Condition.Used);
                    break;

                default:
                    theItem = new Item("Book", ItemStrings.Condition.Default);
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
