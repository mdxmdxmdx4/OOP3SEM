using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork5
{
    public struct GvmntInhabitant  {

        public string Profession = "struct";
        public int Revenue;
        bool Happiness;
        string GvName;
        public GvmntInhabitant(string profession, int revenue, bool happiness, string gvname ) { 
        Profession = profession;   
        Revenue = revenue;
        Happiness = happiness;
        GvName = gvname;   
        }
        public static int sample()
        {
            return 1;
        }
    }
}
