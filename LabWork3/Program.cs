using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;

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
                this.Data = item;
            }
        }


        public void PrintAll() //Печать всего списка
        {
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

        }
    }
}