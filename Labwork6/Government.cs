using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork5
{
    partial class Government : Ground
    {
        public Water water;
        public string Cont;
        public Government(string name, string head, string vallet, int humanity, string cont)
        {
            water = new Water();
            Name = name;
            HeadOfG = head;
            Vallet = vallet;
            Humanity = humanity;
            this.water = water;
            Cont = cont;    
        }
        public string HeadOfG;
        public string Vallet;
    }
}
