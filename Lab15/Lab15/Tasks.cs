using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    public  static partial class Tasks
    {
        public static void MatriX()
        {
            var sw = new Stopwatch();
            sw.Start();
            int[ , ] A = new int[7, 7];
            int[ , ] B = new int[7, 7];
            Random random = new Random();
            for(int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    A[i, j] = random.Next(-10, 55);
                    Console.Write(A[i, j] + ", ");
                }
                Console.WriteLine();
            }
            Thread.Sleep(100);
            Console.WriteLine();
            Random random1 = new Random();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    B[i, j] = random1.Next(1, 20);
                    Console.Write(B[i, j] + ", ");
                }
                Console.WriteLine();
            }

            var resmatr = new int[7, 7];
            Console.WriteLine();

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        resmatr[i, j] += A[i, k] * B[k, j];
                    }
                    Console.Write(resmatr[i, j] + ", ");
                }
                Console.WriteLine();
            }
            sw.Stop();
            Console.WriteLine($"Создание и перемножение матриц заняло:{sw.ElapsedMilliseconds} милисекунд");
        }
        public static void Task1()
        {
            Console.WriteLine("-----Task 1-----");
            var task1 = new Task(MatriX, TaskCreationOptions.LongRunning);
            Console.WriteLine($"Task #{task1.Id}, статус - {task1.Status}");
            task1.Start();
            while (true)
            {
                System.Threading.Thread.Sleep(100);
                Console.WriteLine($"Task #{task1.Id} status - {task1.Status}");
                if (task1.Status == TaskStatus.RanToCompletion)
                    break;

            }
        }
        public static void Task2()
        {
            Console.WriteLine("\n-----Task 2-----");
            CancellationTokenSource cts = new CancellationTokenSource();
            new Task(MatriX, cts.Token).Start();
            Thread.Sleep(10);
            cts.Cancel();
        }
        public static void Task3and4()
        {
            Console.WriteLine("\n-----Task 3/4-----");
            Console.WriteLine("---a---");
            Task<string> s1 =  Task.Run(() => CocncatStr("a", "b", "c"));
            Task<string> s2 =  Task.Run(() => CocncatStr("1", "2", "3"));
            Task<string> s3 = (Task<string>)Task.WhenAll(s1,s2).ContinueWith(t => CocncatStr(s1.Result, s2.Result, "completed"));
            Console.WriteLine(s3.Result);
            Console.WriteLine("---b---");
            Task<string> s4 = Task.Run(() => CocncatStr("xx", "yy", "oo"));
            Task<string> s5 = Task.Run(() => CocncatStr("7", "8", "9"));
            Task<string> s6 = (Task<string>)Task.WhenAll(s4, s5).ContinueWith(t => CocncatStr(s4.Result, s5.Result, "finished"));
            var awaiter = s6.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                string res = awaiter.GetResult() + "awaiter";
                Console.WriteLine(res);
            });
        }
        public static void Task5()
        {
            Console.WriteLine("\n-----Task 5-----");
            int size = 5000;
            int[] arr = new int[size];
            Random rand = new();

            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(-100000, 100000);
            }

            int[] temp = new int[size];

            arr.CopyTo(temp, 0);

            Stopwatch sw = new();
            sw.Start();
            Tasks.Sort(arr);
            sw.Stop();

            Console.WriteLine("Результат пятого задания обычными циклами: " + sw.ElapsedMilliseconds + " мс");

            sw.Reset();
            temp.CopyTo(arr, 0);
            // Parallel.For()
            {
                sw.Start();

                bool isSorted = false;
                while (!isSorted)
                {
                    isSorted = true;
                    Parallel.For(0, size - 2, n =>
                    {
                        if (temp[n].CompareTo(temp[n + 1]) > 0)
                        {
                            int temp1 = temp[n];
                            temp[n] = temp[n + 1];
                            temp[n + 1] = temp1;
                            isSorted = false;
                        }
                    });
                }
                sw.Stop();
            }
            Console.WriteLine("Время выполнения параллельного алгоритма(For): " + sw.ElapsedMilliseconds + " мс");

            sw.Reset();
            // Parallel.ForEach()
            {
                sw.Start();
                List<int> list = arr.ToList();
                int min = int.MaxValue;
                Index index = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    list = arr[i..].ToList();
                    min = int.MaxValue;

                    Parallel.ForEach(list, el =>
                    {
                        if (min > el)
                        {
                            min = el;
                            index = Array.IndexOf(arr, min);
                        }
                    });

                    arr[index] = arr[i];
                    arr[i] = min;
                }

                sw.Stop();
            }

            Console.WriteLine("Время выполнения параллельного алгоритма(ForEach): " + sw.ElapsedMilliseconds + " мс");
        }


        public static void Task6()
        {
            Console.WriteLine("\n-----Task 6-----");
            Parallel.Invoke
            (
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"Task {Task.CurrentId} выполняется"); Thread.Sleep(3000); }
            );
        }
        public static void Task8()
        {
            Console.WriteLine("\n-----Task 8-----");
            void Factorial()
            {
                var result = 1;
                for (var i = 1; i <= 6; i++)
                {
                    result *= i;
                }
                Thread.Sleep(5000);
                Console.WriteLine($"Факториал 6-и = {result}");
            }

            async void FactorialAsync()
            {
                Console.WriteLine("Начало метода FactorialAsync");
                await Task.Run(Factorial);
                Console.WriteLine("Конец метода FactordialAsync");
            }

            FactorialAsync();
            Console.WriteLine("Конец метода Task8");
            Console.ReadKey();
        }

        public static T[] Sort<T>(T[] arr) where T : IComparable
        {
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < arr.Length - 2; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        isSorted = false;
                    }
                }
            }

            return arr;
        }
        public static string CocncatStr(string frst, string scnd, string thrd)
        {
            return frst + scnd + thrd;
        }

    }
    
}
  