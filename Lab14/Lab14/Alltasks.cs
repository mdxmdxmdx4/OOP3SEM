using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    public static class Alltasks
    {
        public static void Task1()
        {
            var allprocs = Process.GetProcesses();
            int n = 0;
            foreach (var proc in allprocs)
            {
                Console.WriteLine($" Процесс #{n}: {proc.Id}, {proc.ProcessName}, {proc.BasePriority}");
                n++;
            }
        }
        public static void Task2()
        {
            AppDomain app = AppDomain.CurrentDomain;
            Console.WriteLine($"\n{app.FriendlyName}, {app.Id}. {app.BaseDirectory}, {app.SetupInformation}");
            var assembl = app.GetAssemblies();
            Console.WriteLine();
            foreach (var el in assembl)
            {
                Console.WriteLine(el);
            }
     /*            AppDomain newD = AppDomain.CreateDomain("New");
                        newD.Load("Assembly.GetExecutingAssembly().FullName");
                        AppDomain.Unload(newD);*/
        }
        public static void Task3()
        {
            Mutex mutex = new Mutex();  // позволяет обеспечить синхронизацию среди множества процессов. Только один поток может получить блокировку и иметь доступ к синхронизированным областям кода.
            Thread NumbersThread = new Thread(new ParameterizedThreadStart(WriteNums));   // создаем новый поток
            Console.WriteLine();
            NumbersThread.Start(7);                                                       // запускаем его


            Thread.Sleep(2000);         // приостанавливает выполнение потока, в котором он был вызван
            mutex.WaitOne();            // вход в критическую секцию

            Console.WriteLine("Приоритет:      " + NumbersThread.Priority);
            Thread.Sleep(100);
            Console.WriteLine("Имя потока:     " + NumbersThread.Name);
            Thread.Sleep(100);
            Console.WriteLine("ID потока:      " + NumbersThread.ManagedThreadId);
            Thread.Sleep(100);
            Console.WriteLine("Статус потока:  " + NumbersThread.ThreadState);
            Thread.Sleep(1000);

            mutex.ReleaseMutex();       // выход из критической секции
            Thread.Sleep(2000);         // приостанавливает выполнение потока, в котором он был вызван

            void WriteNums(object number)   // ввод чисел 
            {
                int num = (int)number;
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(500);
                }
            }
            Console.WriteLine();
        }

        public static void EvenNumbers()        // вывод чётных чисел до 20
        {
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
        }

        public static void OddNumbers()         // вывод нечётных чисел до 20
        {
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
        }
        public static void Task4()
        {
            Thread witheven = new Thread(Alltasks.EvenNumbers);
            witheven.Priority = ThreadPriority.Highest;
            Thread withodd = new Thread(Alltasks.OddNumbers);
            withodd.Priority = ThreadPriority.Lowest ;
            Console.WriteLine("Сделайте выбор: a - отдельно, b - чередование");
            string k = Console.ReadLine();
            switch (k)
            {
                case "a":
                    {
                        witheven.Start();
                        witheven.Join();
                        Console.WriteLine();
                        withodd.Start();
                        witheven.Join();
                        break;
                    }
                case "b":
                    {
                        witheven.Start();
                        withodd.Start();
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неправильный ввод");
                        break;
                    }
            }

        }

        public static void Task5()
        {
            Thread.Sleep(3000);
            TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);  // делегат для таймера
            // позволяет запускать определенные действия по истечению некоторого периода времени:
            Timer timer = new Timer(timerCallback, null, 500, 1000);       /* null - параметр, который передаётся в метод, 500 - время, через которое запустится процесс с таймером, 
                                                                            * 1000 - периодичность таймера (интервал между вызовами метода делегата). */
            Thread.Sleep(5000);                                             // 500 - ждем и не закрываем поток
            timer.Change(Timeout.Infinite, 2000);                           // уничтожение таймера

            void WhatTimeIsIt(object obj)
            {
                Console.WriteLine("\nПрошлa 1 секунда");
            }
            Console.WriteLine("Таймер закончился!");
        }


    }
}
