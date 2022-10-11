using lab004;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork4true
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Planet planet = new Planet("планета Земля");
            planet.Chain();
            Continent continent = new Continent("Австралия",25200000);
            Island island = new Island("Сицилия", "Италия", "Серджо Маттарелла", "Евро",6000000, "Евразия", Convert.ToInt32(60 * Math.Pow(10, 6)), 8000000000);
            Sea sea = new Sea("Саргассово море", "солёная");
            sea.PrintName();
            Console.WriteLine(sea.ToString());
            Sea sea1 = new Sea("Черное море", "солёная");
            Console.WriteLine(sea.Equals(sea1));
            island.ShowHierarchy();
            island.Chain();
            Console.WriteLine(island.ToString());
            object obj1 = new Sea("Черное море", "солёная");
            object obj2 = "1234";
            sea1.TToCompare(obj1);
            Console.WriteLine(sea1.TToCompare(obj1));
            Console.WriteLine(sea1.TToCompare(obj2));
            Console.WriteLine(sea.TToCompare(continent));
            sea1.Precentage = 13;
            FirstInterface firstInterface = sea1;
            sea.Precentage = 12;
            Console.WriteLine(firstInterface.TToCompare(obj1));
            Government government = new Government("Республика Беларусь","Александр Лукашенко","BYN", 9100000, "Евразия",5340000000);
            object[] someTypes = { sea, continent, government, island, firstInterface };
            Console.WriteLine("\n");
            foreach (var item in someTypes)
            {
                if (item is Ground)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("\n");
            foreach (var item in someTypes)
            {
                FirstInterface fi = item as FirstInterface;
                if (fi != null)
                {
                    Console.WriteLine(fi);
                    fi.Agreement();
                }
            }
            Console.WriteLine("\n\n");
            object cloneIsl = island.Clone();
            Console.WriteLine(cloneIsl.Equals(island));
            Printer printer = new Printer();
            object[] lastarray = { planet, continent, sea, government, island, printer };
            foreach (var item in lastarray)
            {
                printer.IAmPrinting(item as Ground);
            }

        }
    }
}