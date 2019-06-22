using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class Auctioneer : IPerson
    {
        public string   Name { get; set; }
        public int      AuctioneerId { get; set; }

        public Auctioneer(string name, int id)
        {
            Name = name;
            AuctioneerId = id;
        }
    }
}
