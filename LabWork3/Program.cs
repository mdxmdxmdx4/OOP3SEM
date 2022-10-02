using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Drawing;

namespace Laba03
{
    class Stack<T>
    {
        class ListItem<T>
        {
            public T? Data { get; set; } //Данные для хранения
            public ListItem<T> Next { get; set; } //Указатель на следующий элемент

            public ListItem(T item)
            {
                Data = item;
            }
        }



        Stack a;
        public T this[int i]
        {
            get
            {
                if(i < 0 || i >= kolvo)
                {
                    return default(T);
                }
                int indexer = 0;

                foreach (var item in a)
                {
                    if(indexer == i)
                    {
                        return (T)item;
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

                var newStack = new Stack();

                foreach(var item in a)
                {
                    if(indexer == i)
                    {
                        newStack.Push(value);
                    }

                    newStack.Push((T)item);
                    indexer++;
                }

                a = newStack;
            }
        }

        public void PrintAll() //Печать всего списка
        {
            Console.WriteLine("\nStack");
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
            current = first;
        }

        public void Push(T item) //Добавление элемента в список
        {
            kolvo++;
            ListItem<T> I = new ListItem<T>(item);

            if (first == null)
            {
                I.Next = null;
            }
            else
            {
                I.Next = first;

            }
            first = I;
            current = I;
        }


        public void Peek()
        {
            Console.WriteLine("Top element is:" + current.Data);
                
        }

        public void Pop()
        {
            current = current.Next;
            first = null;
            first = current;
            kolvo--;
            Console.WriteLine("Top elment has been deleted");
        }
        public void Count()
        {
            Console.WriteLine("Number of elements in stack = " + kolvo);
        }
        public void Clear()
        {
                while (current != null)
                {
                    
                    current = current.Next;
                    first = null;
                    first = current;
                    kolvo--;
                }
                current = first;

        }

        private ListItem<T> first;
        private ListItem<T> current;
        private int kolvo = 0;


//------------------------------------------------------------------------------------------------------------
        public static Stack<T> operator +(Stack<T> example, T item)
        {
            example.kolvo++;     //Грубо говоря, используем Push()
            ListItem<T> I = new ListItem<T>(item);

            if (example.first == null)
            {
                I.Next = null;
            }
            else
            {
                I.Next = example.first;

            }
            example.first = I;
            example.current = I;
            Console.Write("\nПерегрузка оператора +");
            return example;
        }

        public static Stack<T> operator --(Stack<T> example)
        {

            example.current = example.current.Next;
            Console.WriteLine("\n" + example.first.Data + " - извлеченный элемент списка, перегрузка оператора декремент");
            example.first = null;
            example.first = example.current;
            example.kolvo--;
            return example;

        }

        public static bool operator true(Stack<T> example)
        {
            if (example.current != null)
                return true;
            else
                return false;
        }
        public static bool operator false(Stack<T> example)
        {
            if (example.current == null)
                return true;
            else
                return false;
        }

        //________________________
        public void copyy(Stack<T> st2)
        {
       
             while (current != null)
            {
              ListItem<T> I = new ListItem<T>(current.Data);
                      
                current = current.Next;

             if (st2.first == null)
            {
                I.Next = null;
            }
            else
            {
                I.Next = st2.first;

            }
            st2.first = I;
            st2.current = I;
            }

        }

        public void sort()
        {
            dynamic temp;
            while ((current != null) && (current.Next != null))
            {
                if (Convert.ToInt32(current.Data) < Convert.ToInt32(current.Next.Data))
                {
                    temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    current = first;
                }
                else
                {
                    current = current.Next;

                }
              
            }
            current = first;
        }
        //------------------------------------


        public static Stack<T> operator >(Stack<T> st1, Stack<T> st2)
        {
            st1.copyy(st2);
            st2.sort();

            return st2;
        }
        public static Stack<T> operator <(Stack<T> st1, Stack<T> st2)
        {
            st2.copyy(st1);
            st1.sort();

            return st1;
        }

        public static implicit operator Stack(Stack<T> v)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            Stack<int> MyStack = new Stack<int>();
            MyStack.Push(1);
            MyStack.Push(2);
            MyStack.Push(3);
            MyStack.Push(4);
            MyStack.Push(5);
            MyStack.Count();
            MyStack.PrintAll();
            MyStack.Pop();
            MyStack.PrintAll();
            MyStack.Count();
            MyStack.Clear();
            MyStack.Push(1);
            MyStack.PrintAll();
            MyStack.Count();

//------------------------------------------------------- перегрузка операторов

            MyStack += 2;
            MyStack.PrintAll();
            MyStack--;
            MyStack.PrintAll();

            if (MyStack)
                Console.WriteLine("Стек не пуст");
            else
                Console.WriteLine("Стек пуст");
            MyStack--;
            if (MyStack)
                Console.WriteLine("Стек не пуст");
            else
                Console.WriteLine("Стек пуст");

            MyStack.Push(100);
            MyStack.Push(11);
            MyStack.Push(28);
            MyStack.Push(99);
            MyStack.Push(14);
            MyStack.PrintAll();
            Stack<int> MyStack2 = new Stack<int>();
            MyStack2 = MyStack > MyStack2;
            MyStack2.PrintAll();





        }
    }
}