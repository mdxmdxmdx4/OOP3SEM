using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontrolV2
{
    public class SuperHashSet<T> where T : struct
    {
        public HashSet<T> value;

        public SuperHashSet(HashSet<T> value)
        {
            this.value = value;
        }
    }
}