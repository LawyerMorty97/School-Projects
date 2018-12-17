using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    class Program
    {
        private static AuctionMarket            _auction;

        /// <summary>
        /// Start of the program.
        /// </summary>
        /// <param name="args">Arguments that are passed when the program starts (In the case, there are none)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Lotta's Flea Market!");

            enterItems:
            Console.Write("Please enter the amount of items the flea market will have: ");
            string userInput = Console.ReadLine();
            int actualAmount = 0;

            try
            {
                actualAmount = Convert.ToInt32(userInput);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: You did not enter a number, try again.");
                goto enterItems;
            }

            _auction = new AuctionMarket(actualAmount);
            _auction.Start();
        }
    }

}