using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class CollectionQueue<T> /*IOrderedDictionary*/
    {
                
        Queue<T> queue = new Queue<T>();
        public int kolvo = 0;
        public int Count => queue.Count;

        public CollectionQueue()
               {
               }
        public CollectionQueue(T value)
               {
                   queue.Enqueue(value);
                   kolvo++;
               }

        public void AddElement(object key, object value) // добавление элемента в коллекцию
        {
            queue.Enqueue((T)value);
        }

        public void Clear()
               {
                    queue.Clear();
                    kolvo = 0;
               }

        public void Contains(object elem)
                {
                    bool y = queue.Contains((T)elem);
                    if (y == false)
                    {
                        Console.WriteLine("Такого элемента нету в очереди");
                    }
                    else if ( elem is Services q )
                    {
                        Console.WriteLine("Услуга:" + Convert.ToString(q.title) + " содержится в очереди");
                    }
                    else
                        Console.WriteLine("Элемент:" + Convert.ToString(y) + " содержится в очереди");
                }
        public void RemoveElement()
                {
                    Console.WriteLine("Удаление элемента из очереди (первый элемент): " + queue.Dequeue());
                    kolvo--;
                }
                public void Print()
                {
                    Console.WriteLine("Очередь:");
                    foreach (var item in queue)
                    {
                        Console.WriteLine(item);
                    }
                }
        public T ElementAtIndex (int index)
                {
                    return queue.ElementAt((int)index);
                }

         public ICollection Keys => queue.ToArray();
         public ICollection Values => queue.ToArray();
         public static CollectionQueue<T> operator +(CollectionQueue<T> coll, T item)  //перегрузка операторов
                {
                    Console.WriteLine("Перегрузка оператора \"+\"");
                    coll.AddElement(item, item);
                    coll.kolvo++;
                    return coll;

                }

 


















    }
}
