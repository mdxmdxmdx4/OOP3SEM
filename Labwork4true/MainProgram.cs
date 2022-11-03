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
            Government government = new Government("Республика Беларусь", "Александр Лукашенко", "BYN", 9100000);
            Console.WriteLine(government.Precentage);
            Water salted = new Water(1234, "солёная");
            Water presnaya = new Water(4567, "пресная");
            Sea sea = new Sea("Саргассово море", 12, presnaya );
            Sea sea2 = new Sea("Красное море", 15, salted);
            sea.PrintName();
            Console.WriteLine(sea.Equals(sea2));
            Continent continent = new Continent("Австралия",25200000);
            continent.PrintName();
            Island island = new Island("Сицилия", "Италия",6000000);
            Island island1 = new Island("Сицилия", "Не Италия", 10000);
            island1.water.typeOFWater = "пресная";
            island1.water.square = 1234;
            object obj1 = new Island("Сицилия", "Италия", 6000000);
            object obj2 = "1234";
            Console.WriteLine(island.TToCompare(obj1));
            Console.WriteLine(island.TToCompare(obj2));
            Console.WriteLine(island1.TToCompare(continent));
            ((FirstInterface)island1).TToCompare(obj1);
            FirstInterface firstInterface = island;
            Console.WriteLine(firstInterface.TToCompare(obj1));
            government.PrintName();
            object[] someTypes = { continent, government, island1, firstInterface, obj2};
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
            Console.WriteLine();
            Printer printer = new Printer();
            object[] lastarray = { continent, government, cloneIsl, printer, obj2, firstInterface};
            foreach (var item in lastarray)
            {
                printer.IAmPrinting(item as Ground);
            }

        }
    }
}