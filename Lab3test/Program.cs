using System.Collections.Specialized;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;

namespace lab003
{
    class Stack
    {
        public Production prod;
        Stack<int>stackExample = new Stack<int>();
        Stack<string>stringExample = new Stack<string>();
        private int kolvo = 0;
        public Stack()
        {
        }
        public void Push(int item)
        {
            stackExample.Push(item);
            kolvo++;
        }
        public void Push(string s)
        {
            stringExample.Push(s);
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
            Console.WriteLine("Верхний элемент стека:" + stackExample.Peek());
        }
        public int Count()
        {
            return stackExample.Count();
        }
        public void Printall()
        {
            Console.WriteLine("Stack:");
            foreach (int item in stackExample)
            {
                Console.WriteLine(item);
            }

        }
        public static Stack operator +(Stack oper, int item)  //перегрузка операторов
        {
            Console.WriteLine("Перегрузка оператора \"+\"");
            oper.Push(item);      
            oper.kolvo++;
            return oper;
                
        }
        public static Stack operator --(Stack oper)
        {
            Console.WriteLine("Перегрузка оператора \"-\"");
            oper.Pop();
            oper.kolvo--;
            return oper;
           

        }
        public static bool operator true(Stack v)
        {
            if (v.Count() != 0)
                return true;
            else
                return false;
        }
        public static bool operator false(Stack v)
        {
            if (v.Count() == 0)
                return true;
            else
                return false;
        }

      public static Stack operator >(Stack st1, Stack st2)
        {
            int count = st1.Count();
            int[] arr = new int[count];
            for(int i = 0; i < count; i++)
            {
                arr[i] = st1[i];

            }

            int temp;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
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
        public static Stack operator <(Stack st1, Stack st2)
        {
            int count = st2.Count();
            int[] arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = st1[i];

            }

            int temp;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
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
        public int this[int i]   //индексатор
    {
               get
               {
                   if (i < 0 || i >= kolvo)
                   {
                       return default(int);
                   }
                   int indexer = 0;

                   foreach (var item in stackExample)
                   {
                       if (indexer == i)
                       {
                           return (int)item;
                       }

                       indexer++;
                   }
                   return default(int);
               }
               set
               {
                   if (i < 0 || i >= kolvo)
                   {
                       throw new ArgumentException();
                   }

                   int indexer = 0;

                   var newStack = new Stack<int>();

                   foreach (var item in stackExample)
                   {
                       if (indexer == i)
                       {
                           newStack.Push(value);
                       }

                       newStack.Push((int)item);
                       indexer++;
                   }

                stackExample = newStack;
               }
               }
          public class Developer
        {
            public Developer(string Name, string otdel)
            {
                id++;
                name = Name;
                sector = otdel;
            }
            public void ShowInfo()                 
            {
                Console.WriteLine($"Id:             {id}");
                Console.WriteLine($"Имя:            {name}");
                Console.WriteLine($"Отдел:    {sector}\n");
            }
            private static int id = 0;
            private string name;
            private string sector;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
         Stack stack1 = new Stack();
            if (stack1)
                Console.WriteLine("Стек не пуст");
            else
                Console.WriteLine("Стек пуст");
         stack1.Push(3);
         stack1.Push(4);
         stack1.Push(10);
         stack1.Peek();
         stack1.Printall();
         stack1.Pop();
         stack1.Peek();

         stack1.Printall();
         stack1--;
         stack1 += 3;
         stack1.Printall();
            if (stack1)
                Console.WriteLine("Стек не пуст");
            else
                Console.WriteLine("Стек пуст");
            stack1--;
            stack1--;
            if (stack1)
                Console.WriteLine("Стек не пуст");
            else
                Console.WriteLine("Стек пуст");
            Stack stack2 = new Stack();
            stack1 += 3;
            stack1 += 10;
            stack1 += 7;
            stack1.Printall();
            stack2 = stack1 > stack2;
            stack2.Printall();

            Stack.Developer dev = new Stack.Developer("Khinets Ilya Sergeevich", "Data Security");
            stack2.prod.organisation = "1231";
            stack2.sum();
            stack2.difference();
            stack2.CountOfElems();
            stack2.Middle();
            string testr = "Lorem. Ipsum. Dolor";
            string testr1 = "Doom";
            testr.SentensX();

        }

    }
}