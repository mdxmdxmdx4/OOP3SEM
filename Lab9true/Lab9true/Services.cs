using System;
using System.Collections.Generic;

namespace Lab9true
{
    public class Services
    {

        public string title;
        public string description;
        public int price;
        public Services(string t, string d, int p)
        {
            title = t;
            description = d;    
            price = p; 

        }
        public override string ToString()
        {
            return ("Title:" + title + ", Description:" + description + ", Price = " + Convert.ToString(price));
        }
    }
}