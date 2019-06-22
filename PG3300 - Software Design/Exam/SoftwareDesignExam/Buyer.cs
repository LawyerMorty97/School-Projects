using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class Buyer : IPerson
    {
        public string Name { get; set; }

        public Buyer(string name)
        {
            Name = name;
        }
   
    }

}
