using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Labwork5
{
   partial class Government<T> : Ground
    {
        T[] mass;
        public override void Info()
        {
            Console.WriteLine("Cтрана - " + Name);
        }
        public Government() { }
        public override void PrintName()
        {
            base.PrintName();
        }
        public override bool TToCompare(object obj)
        {
            return true;
        }
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Государство {this.Name}, население = {this.Humanity}, валюта - {this.Vallet}, глава гос-ва - {this.HeadOfG}");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Island island1 = new Island("Гренландия", "Дания", 55592);
            if (island1.Humanity < 0)
            {
                throw new HumanityExceprtion("Отрицательное население!");
            }
            else
            {
                Console.WriteLine(island1.Humanity);
            }
            // #1
            try
            {
                island1.Humanity = -12314;
            }
            catch (HumanityExceprtion ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Government government2 = new Government("Республика Польша", "Анджей Дуда", "PLN", 385000000, "Евразия");
            int x = 1234;
            int y = 0;
            // #2
            try
            {
                int result = x / y;
            }
            catch (DivideByZeroException ex1) when (y == 0)
            {
                Console.WriteLine("\nДеление на 0 невозможно! Поменяйте значение делителя");
            }
            Water presnaya = new Water(4567, "пресная");
            Water salted = new Water(1234, "солёная");
            //#3
            try
            {
                salted.TypeOFWater = "красная";
            }
            catch(WaterException ex2)
            {
                Console.WriteLine($"\nОшибка: {ex2.Message}");
            }
            // #4
            try {
                int[] arr = new int[6];
                arr[222] = 12345;
            }
            catch(IndexOutOfRangeException) {
                Console.WriteLine("\nВыход за пределы индекса");
            }
            finally
            {
                Console.WriteLine("Работа с массивом окончена");
            }
            //#5
            Continent continent = new Continent("Евразия", 2000000000);
            try
            {
                Continent AC = new Continent(null, 12314231);
            }
            catch(NameException ex5)
            {
                Console.WriteLine(ex5.Message);
            }


            Debugger.Break();

            // вывод параметров
            try
            {
                Continent AC = continent as Ground;
            }
            catch(Exception wat) {
            Console.WriteLine("\n" +wat.Message + "\n" +
                wat.StackTrace + "\n" + 
                wat.Data  + wat.HelpLink + "\n" + 
                wat.TargetSite);
            }
            finally
            {
                Console.WriteLine("Вся информация об ошибке выведена!");
            };
          /*  try
            {
                MathOP(9999, 0);
            }
            finally
            {
                Console.WriteLine("Демонстрация Многоразовой обработки исключения");
            }*/

            //последовательный вызов блоков try-catch-finally
            Console.WriteLine("\n\n-------------------------------------------------\n\n");
      
            try
            {
                OneOfTheLast();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Catch в Main " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally в Main");
            }
            Console.WriteLine("Конец метода в Main");
            Debug.Assert(island1.Name != "Гренландия", "Это самый крупный остров на земле");
               int[] aa = null;
               Debug.Assert(aa != null, "Values array cannot be null");
        }

        static void MathOP(int x, int y)
        {
            try
            {
                int abc = x / y;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Деление на ноль!");
                throw;
            }

        }
        static void OneOfTheLast()
        {
            try
            { 
                TwoOfTheLast();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Catch в методе 1 " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally в методе 1");
            }
            Console.WriteLine("Конец метода 1");
        }
        static void TwoOfTheLast()
        {
            try
            {
                int aa = 8;
                int bb = aa / 0;
            }
            finally
            {
                Console.WriteLine("Блок finally в методе 2");
            }
            Console.WriteLine("Конец метода в методе 2");
        }
    }
}