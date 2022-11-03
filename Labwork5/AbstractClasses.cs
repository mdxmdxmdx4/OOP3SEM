using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork5
{
   internal abstract class Ground : Continent
    {
        public int Precentage;
        public GeoBelt belt;
        public string Parent;
        public abstract bool TToCompare(object obj);
        public abstract void Info();
        public Ground()
        {
        }
    }
}
