using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class Populator
    {
        private readonly List<string>        _names_list;
        private List<string>                 _used_names;

        /// <summary>
        /// Create an instance of the Populator object
        /// </summary>
        /// <param name="output">Contains the object used for printing results of actions.</param>
        public Populator()
        {
            _names_list = Utilities.ConvertJSONToList("data/names.json");
            _used_names = new List<string>();
        }

        /// <summary>
        /// Populates the list of buyers with random names
        /// </summary>
        /// <param name="numberOfBuyers">Decides how many buyers will exist</param>
        /// <param name="list">The list where all buyers will be held</param>
        /// <returns>Returns the amount of buyers that have been instantiated</returns>
        public int PopulateBuyerList(int numberOfBuyers, List<Buyer> list)
        {
            getUnusedBuyerName:
            for (int i = 0; i < numberOfBuyers; i++)
            {
                int nameIndex = Utilities.GetRandomNumber(0, _names_list.Count);
                if (!_used_names.Contains(_names_list[nameIndex]))
                {
                    string name = _names_list[nameIndex];
                    if (list.Count < numberOfBuyers)
                    {
                        Buyer buyer = new Buyer(name);
                        list.Add(buyer);

                        _used_names.Add(name);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    goto getUnusedBuyerName;
                }
            }

            return list.Count;
        }

        /// <summary>
        /// Populates the list of auctioneers with random names
        /// </summary>
        /// <param name="list">The list where all auctioneers will be held</param>
        public void PopulateAuctioneersList(List<Auctioneer> list)
        {
            const int max = 4;
            getUnusedAucioneerName:
            for (int i = 0; i < max; i++)
            {
                int nameIndex = Utilities.GetRandomNumber(0, _names_list.Count);
                if (!_used_names.Contains(_names_list[nameIndex]))
                {
                    string name = _names_list[nameIndex];
                    if (list.Count < max)
                    {
                        Auctioneer auctioneer = new Auctioneer(name, 1);
                        list.Add(auctioneer);
                        _used_names.Add(name);
                    }
                }
                else
                {
                    goto getUnusedAucioneerName;
                }
            }
        }
    }
}
