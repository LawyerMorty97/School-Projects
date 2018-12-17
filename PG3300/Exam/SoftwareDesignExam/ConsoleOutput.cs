using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class ConsoleOutput : IConsoleOutput
    {
        /// <summary>
        /// Prints out when the auction is finished.
        /// </summary>
        /// <param name="buyers">The amount of buyers that were active during the sale</param>
        /// <param name="items">The amount of items that were sold</param>
        public void PrintEndAuction(int buyers, int items)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\nThe flea market had " + buyers + " customers.\n");
            sb.Append("The flea market had " + items + " items for sale.\n");

            Console.WriteLine(sb);

            Console.WriteLine("Press any key to exit . . . ");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints out information related to when a transaction occurs and when a item is sold
        /// </summary>
        /// <param name="soldItem">The item that was sold</param>
        public void PrintTransaction(IItem soldItem)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("                                          ");
            sb.Append(soldItem.Buyer + " " + "bought " + soldItem.Auctioneer + "'s ");
            sb.Append(soldItem.Condition.ToLower() + " " + soldItem.Name.ToLower() + " " + "#" + soldItem.AuctioneerId);

            Console.WriteLine(sb);
        }

        /// <summary>
        /// Prints out when a new item is added for sale
        /// </summary>
        /// <param name="itemToSell">THe item which is being sold</param>
        public void PrintAuctionListing(IItem itemToSell)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(itemToSell.Auctioneer + " puts his ");
            sb.Append("#" + itemToSell.AuctioneerId);
            sb.Append(" " + itemToSell.Condition.ToLower());
            sb.Append(" " + itemToSell.Name.ToLower());
            sb.Append(" up for sale");

            Console.WriteLine(sb);
        }

    }
}
