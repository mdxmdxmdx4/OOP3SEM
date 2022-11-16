using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab003
{
    internal interface IntGeneric <T>
    {
        void Add(T dt);
        void Delete();
        void Show();
    }
}
