using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lab15
{
    public static  partial class Tasks
    {
        public static void Task7()
        {
            Console.WriteLine("\n-----Task 7-----");
            var bc = new BlockingCollection<string>(5);
            var ts = new CancellationTokenSource();

            var sellers = new Task[]    //поставщики
            {
                new(() => { while(true){Thread.Sleep(400); bc.Add("Стиральная машина"); } }),
                new(() => { while(true){Thread.Sleep(500); bc.Add("Электрочайник"); } }),
                new(() => { while(true){Thread.Sleep(550); bc.Add("Утюг");  } }),
                new(() => { while(true){Thread.Sleep(500); bc.Add("Микроволновка");  } }),
                new(() => { while(true){Thread.Sleep(550); bc.Add("Пылесос"); } }),
            };

            var consumers = new Task[]     //покупатели
            {
                new(() => { while(true){ Thread.Sleep(850);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(950);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(1100);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(1300);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(1250);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(860);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(999);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(787);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(1010);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(959);   bc.Take(); } })
            };

            foreach (var i in sellers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            foreach (var i in consumers)
                if (i.Status != TaskStatus.Running)
                    i.Start();
            var count = 0;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(1000);
                    Console.WriteLine("---------Cклад---------");

                    foreach (var item in bc)
                        Console.WriteLine(item);

                    Console.WriteLine("-----------------------");
                }
            }


        }

    }
}
