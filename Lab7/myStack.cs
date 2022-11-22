using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;

namespace lab003
{
    class myStack <T>  where T : class, IComparable<T>
    {
        Stack<T> stackExample = new Stack<T>();
        private int kolvo = 0;
        Stack st1 = new Stack();
        public void Add(T dt)
        {
            stackExample.Push(dt);
        }

        public void Show()
        {
            Printall();
        }
        public void Delete()
        {
            Pop();
        }
        public T this[int i]   //индексатор
        {
            get
            {
                if (i < 0 || i >= kolvo)
                {
                    return default(T);
                }
                int indexer = 0;

                foreach (var item in stackExample)
                {
                    if (indexer == i)
                    {
                        return item;
                    }

                    indexer++;
                }
                return default(T);
            }
            set
            {
                if (i < 0 || i >= kolvo)
                {
                    throw new ArgumentException();
                }

                int indexer = 0;

                var newStack = new Stack<T>();

                foreach (var item in stackExample)
                {
                    if (indexer == i)
                    {
                        newStack.Push(value);
                    }

                    newStack.Push(item);
                    indexer++;
                }

                stackExample = newStack;
            }
        }
        public myStack()
        {
            kolvo++;
        }
        public myStack(T data)
        {
            kolvo++;
            stackExample.Push(data);
        }
        public void Push(T item)
        {
            stackExample.Push(item);
            kolvo++;
        }
        public void Clear()
        {
            stackExample.Clear();
            kolvo = 0;
        }
        public void Pop()
        {
            stackExample.Pop();
            kolvo--;
        }
        public void Peek()
        {
            Console.WriteLine("Верхний элемент стека:");
            stackExample.Peek();
        }
        public int Count()
        {
            return stackExample.Count();
        }
        public void Printall()
        {
            Console.WriteLine("Stack:");
            foreach (var item in stackExample)
            {
                Console.WriteLine(item);
            }

        }
        public static myStack<T> operator +(myStack<T> oper, T item)  //перегрузка операторов
        {
            Console.WriteLine("Перегрузка оператора \"+\"");
            oper.Push(item);      
            oper.kolvo++;
            return oper;
          
        }
        public static myStack<T> operator --(myStack<T> oper)
        {
            Console.WriteLine("Перегрузка оператора \"-\"");
            oper.Pop();
            oper.kolvo--;
            return oper;
        }
        public static bool operator true(myStack<T> v)
        {
            if (v.Count() != 0)
                return true;
            else
                return false;
        }
        public static bool operator false(myStack<T> v)
        {
            if (v.Count() == 0)
                return true;
            else
                return false;
        }

      public static myStack<T> operator >(myStack<T> st1, myStack<T> st2)
        {
            int count = st1.Count();
            T[] arr = new T[count];
            for(int i = 0; i < count; i++)
            {
                arr[i] = st1[i];

            }
            T temp;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        // меняем элементы местами
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            for (int c = 0; c < count; c++)
            {
                st2.Push(arr[c]);
            } 

            return st2;
        }
        public static myStack<T> operator <(myStack<T> st1, myStack<T> st2)
        {
            int count = st2.Count();
            T[] arr = new T[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = st1[i];

            }

            T temp;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        // меняем элементы местами
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            for (int c = 0; c < count; c++)
            {
                st1.Push(arr[c]);
            }

                return st1;
        }
        public void ChangeTheHead<T>(T obj, myStack<T> s1) where T : class, IComparable<T>
        {
            if (s1.kolvo >= 1)
            {
                s1.Pop();
                s1.Push(obj);
            }
            else
            {
                Console.WriteLine("!!!Error!!!");
            }
        }
        public static void WriteToFile(ref myStack<T> stack)
        {
            using (var file = new StreamWriter("file.txt", false))
            {
                foreach (var item in stack.stackExample)
                {
                    file.Write($"{item}\n");
                }
            }
        }

        public static void ReadFromFile()
        {
            using (var file = new StreamReader("file.txt", true))
            {
                Console.WriteLine(file.ReadToEnd());
            }
        }

    }
 
}