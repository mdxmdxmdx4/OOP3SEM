using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab003
{
    internal  class Production
    {
        public Production(string org) //конструктор, добавляющий владельцев
        {
            id++;
            organisation = org;
        }
        public void ShowInfo()                  //метод вывод информации
        {
            Console.WriteLine($"Id:             {id}");
            Console.WriteLine($"Организация:    {organisation}\n");
        }
        private static int id = 0;
        public string organisation;
    }
}
