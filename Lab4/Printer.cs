using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork4true
{
    class Printer
    {
        public void IAmPrinting(Ground someobj)
        {
            if (someobj is Ground)
            {
                Console.WriteLine(someobj.GetType()+ " , " + someobj.ToString());
            }
            else
                Console.WriteLine(someobj + "---не объект Ground---");
        }
    }
}
