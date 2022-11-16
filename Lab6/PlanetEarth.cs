using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Labwork5
{
    internal class PlanetEarth
    {
        public int kolvo = 0;
        public List<Continent> cntnr;
        public PlanetEarth()
        {
            cntnr = new List<Continent>();
            kolvo++;
        }
        public List<Continent> List
        {
            get => cntnr;
            set
            {
                if (value is List<Continent>)
                {
                    cntnr = value;
                }
            }
        }
        public void Add(object value)
        {
            if (value is Continent thenn)
            {
                cntnr.Add(thenn);
            }
        }

        public void Remove(object value)
        {
            if (value is Continent thenn)
            {
                cntnr.Remove(thenn);
                kolvo--;
            }
        }
        public void Print()
        {
            foreach (var elem in cntnr)
            {
                switch (elem)
                {
                    case Sea:
                        Console.WriteLine($"--Название моря: {elem.Name}");
                        break;
                    case Island:
                        Console.WriteLine($"--Название острова: {elem.Name}");
                        break;
                    case Government:
                        Console.WriteLine($"--Название государства: {elem.Name}");
                        break;
                    default:
                        Console.WriteLine($"---Континет : {elem.Name}");
                        break;
                }
            }
        }



    }

}
