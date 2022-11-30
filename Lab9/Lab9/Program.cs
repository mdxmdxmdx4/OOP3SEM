using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class Program
    {
        static void Main()
        {


            //     #1
            Services serv1 = new Services("Установка Windows","Стоимость ПО включена в итоговую цену услуги", 149);
            Services serv2 = new Services("Чистка ПК", "Чистка от пыли, замена термопасты", 39);
            Services serv3 = new Services("Замена видеокарты", "Замена GPU на более производительную", 1500);
            CollectionQueue<Services> collect = new CollectionQueue<Services>();
            collect.AddElement(serv1, serv1);
            collect.AddElement(serv2, serv2);
            collect.AddElement(serv3, serv3);
            collect.Print();
            collect.Contains(serv1);
            collect.RemoveElement();
            Console.WriteLine("Кол-во элементов = " + collect.kolvo);
            Console.WriteLine("Очередь очищена");
            collect.Clear();
            CollectionQueue<int> intovaya = new CollectionQueue<int>();
            intovaya.AddElement(6, 6);
            intovaya.AddElement(3, 3);
            intovaya.AddElement(10  , 10);
            intovaya.AddElement(948, 948);
            intovaya.AddElement(13, 13);
            intovaya.AddElement(63, 63);
            Console.WriteLine();
            intovaya.Print();
            Console.WriteLine("Введите число n");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < intovaya.kolvo - 1; i++)
            {
                if (intovaya.kolvo > 0)
                {
                    intovaya.RemoveElement();
                }
            }
            intovaya.Print();
            intovaya += 4;
            intovaya.AddElement(0, 0);


            //         #2
            LinkedList<int> link = new LinkedList<int>();

            for (int i = 0; i < (intovaya.kolvo - 1); i++)
            {
                link.AddLast(intovaya.ElementAtIndex(i));
            }
            Console.WriteLine("\nВторая коллекция:");
            foreach (var item in link)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Тип первой коллекции: " + collect.GetType());
            Console.WriteLine("Тип второй коллекции: " + intovaya.GetType());
            Console.WriteLine("Тип третьей коллекции: " + link.GetType());
            Console.WriteLine("\n^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^");

            //         #3
            var myCollection = new ObservableCollection<Services>();
            Services services4 = new Services("Замена корпуса","Замена корпуса ПК", 99);

            myCollection.CollectionChanged += CollectionChanged;
            myCollection.Add(services4);
            myCollection.Remove(services4);

        }

        private static void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен новый объект");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удален объект");
                    break;
            }
        }


    }
}
