using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab9true
{
    class Program {
        static void Main(string[] args)
        {

            //            #1

            Services serv1 = new Services("Установка Windows", "Стоимость ПО включена в итоговую цену услуги", 149);
            Services serv2 = new Services("Чистка ПК", "Чистка от пыли, замена термопасты", 39);
            Services serv3 = new Services("Замена видеокарты", "Замена GPU на более производительную", 1500);
            CollectionQueue collect = new CollectionQueue();
            collect.Add("Установка Windows", serv1);
            collect.Add("Чистка ПК", serv2);
            collect.Add("Замена видеокарты", serv3);

            Console.WriteLine("\n\tКлючи коллекции: ");
            foreach (var i in collect.Keys)
            Console.WriteLine(i);

            Console.WriteLine("\n\tПолные значения коллекции:");
            foreach (var i in collect.Values)
            Console.WriteLine(i);
            collect.Remove("Чистка ПК");
            Console.WriteLine("\n\tОчередь после удаления одной услуги");
            foreach (string i in collect.Keys)
            Console.WriteLine(i);
            Console.WriteLine("\n" + collect[1]);
            Console.WriteLine("\n" + collect.Contains("Замена видеокарты"));
            Console.WriteLine("\n" + collect.Contains("Чистка ПК"));

            //             #2

            Queue<int> q1 = new Queue<int>();
            q1.Enqueue(0);
            q1.Enqueue(3);
            q1.Enqueue(123131);
            q1.Enqueue(114);
            q1.Enqueue(31);
            q1.Enqueue(1);
            Console.WriteLine("\nКоллекция Queue<int> содержит:");
            foreach(var el in q1)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("\nВведите число n для удаления элементов");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                q1.Dequeue();
                if(q1.Count <= 0)
                {
                    Console.WriteLine("Очередь пуста!");
                    break;
                }
            }
            Console.WriteLine($"\nКоллекция Queue<int> после удаления {n} элементов:") ;
            foreach (var el in q1)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("Коллекцмя Stack:");
            var st = new Stack(q1);
            foreach (var el in st)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();
            Console.WriteLine(st.Contains(444));
            Console.WriteLine(st.Contains(114));


            //        #3

            var myCollection = new ObservableCollection<Services>();
            Services services4 = new Services("Замена корпуса", "Замена корпуса ПК", 99);
            Console.WriteLine("\nРабота с ObservableCollection<T>:");

            myCollection.CollectionChanged += CollectionChanged;
            myCollection.Add(services4);
            myCollection.Remove(services4);

        }
        private static void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен новый элемент");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удален элемент");
                    break;
            }
        }
    }


}
