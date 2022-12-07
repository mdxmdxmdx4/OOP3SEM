using Lab10;
using System;
using System.Linq;

namespace lab10
{

    public class Program
    {
        public static void Main()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December " };
            IEnumerable<string> res1 = from n in months
                                       where n.Length == 5
                                       select n;
            Console.WriteLine("Месяца с кол-вом букв = 5:");
            foreach (string s in res1)
            {
                Console.WriteLine(s);
            }

            IEnumerable<string> WinterSummer = from x in months
                                               where Array.IndexOf(months, x) < 2 ||
                                                     Array.IndexOf(months, x) > 4 && Array.IndexOf(months, x) < 8 ||
                                                     Array.IndexOf(months, x) == 11
                                               select x;

            Console.WriteLine("\n\nWinter and summer months:");
            foreach (var str in WinterSummer)
            {
                Console.Write(str + "  |  ");
            }

            IEnumerable<string> Alphabetic = from x in months
                                             orderby x ascending
                                             select x;
            Console.WriteLine("\n\nМесяца в алфавитном порядке:");
            foreach (var el in Alphabetic)
            {
                Console.Write(el + " | ");
            }

            IEnumerable<string> uand4 = from x in months
                                        where x.Contains("u") && x.Length > 3
                                        select x;
            Console.WriteLine("\n\nМесяца, содержащие букву \"u\" с длиной > 4:");
            foreach (var el in uand4)
            {
                Console.Write(el + "  |  ");
            }
            Airline a1 = new Airline("Багдад", 12, "Airbus", "Понедельник", new DateTime(2022, 09, 11, 23, 00, 00));
            Airline a2 = new Airline("Киев", 123, "Airbus", "Вторник", new DateTime(2022, 09, 15, 16, 45, 00));
            Airline a3 = new Airline("Варшава", 75, "Airbus", "Вторник", new DateTime(2022, 09, 15, 19, 00, 00));
            Airline a4 = new Airline("Пекин", 1012, "Belavia", "Среда", new DateTime(2022, 09, 20, 22, 45, 00));
            Airline a5 = new Airline("Москва", 151, "Аэрофлот", "Среда", new DateTime(2022, 12, 04, 15, 30, 00));
            Airline a6 = new Airline("Катар", 444, "TurkishAirlines", "Среда", new DateTime(2022, 12, 05, 07, 45, 00));
            Airline a7 = new Airline("ОАЭ", 812, "Fly Emirates", "Четверг", new DateTime(2022, 12, 10, 10, 00, 00));
            Airline a8 = new Airline("Бангкок", 315, "s7 Airlines", "Пятница", new DateTime(2022, 12, 29, 20, 30, 00));
            Airline a9 = new Airline("Лима", 785, "Belavia", "Суббота", new DateTime(2023, 01, 13, 19, 45, 00));
            Airline a10 = new Airline("Каир", 109, "TurkishAirlanes", "Воскресенье", new DateTime(2023, 02, 12, 12, 00, 00));
            List<Airline> airlist = new List<Airline>();
            airlist.Add(a1);
            airlist.Add(a2);
            airlist.Add(a3);
            airlist.Add(a4);
            airlist.Add(a5);
            airlist.Add(a6);
            airlist.Add(a7);
            airlist.Add(a8);
            airlist.Add(a9);
            airlist.Add(a10);
            Console.WriteLine("\n\nСписок рейсов:");
            foreach (var el in airlist)
            {
                Console.WriteLine(el);
            }

            IEnumerable<Airline> destination = from x in airlist
                                               where x.Destination == "Лима"
                                               select x;
            Console.WriteLine("\nРейсы в Лиму");
            foreach (Airline el in destination)
            {
                Console.WriteLine(el);
            }

            IEnumerable<Airline> byday = from x in airlist
                                         where x.WeekDay == "Вторник"
                                         select x;
            Console.WriteLine("\nВсе рейсы во вторник");
            foreach (Airline el in byday)
            {
                Console.WriteLine(el);
            }

            var resdays = airlist
               .GroupBy(n => n.WeekDay)
               .Select(n => new { WeekDay = n.Key, Max = n.Max(x => x.RaceNumber) });

            Console.WriteLine("\n\nМаксимальный по дню недели рейс (номер)");
            foreach (var el in resdays)
                Console.WriteLine(el);

            Console.WriteLine("\n\nВсе рейсы в определенный день недели и с самым поздним временем вылета");
            Console.ResetColor();
            var resdep = airlist
                .GroupBy(n => n.WeekDay)
                .Select(n => new { День_Недели = n.Key, Время_отправления = n.Max(x => Convert.ToString(x.TimeOfDep.Hour)
                + ":" + Convert.ToString(x.TimeOfDep.Minute)) });
            foreach (var el in resdep)
                Console.WriteLine(el);

            Console.WriteLine("\nУпорядоченные по времени рейсы");
            Console.ResetColor();
            Console.ResetColor();
            var resdayys = airlist
                .OrderBy(n => n.TimeOfDep.Hour);
            foreach (var el in resdayys)
                Console.WriteLine("{0}", el);

            var restypes = from x in airlist
                           where x.AirplaneType == "Belavia"
                           select x;
            Console.WriteLine("\n\nРейсы Belavia");
            foreach (var el in restypes)
                Console.WriteLine(el);


            Console.WriteLine("\n\nЗапрос из 5-и операторов");
            IEnumerable<Airline> bigquery = airlist
                .Where(n => n.RaceNumber > 300)
                .OrderBy(n => n.Destination)
                .Take(2)
                .Select(n => n)
                .Concat(airlist.Skip(8));

            foreach (var el in bigquery)
                Console.WriteLine(el);

            Airline a31 = new Airline("Афигы", 151, "s7 Airlanes", "Воскресенье", new DateTime(2023, 02, 02, 14, 50, 00));
            Airline a41 = new Airline("Катовице", 1012, "Turkish Airlanes", "Среда", new DateTime(2023, 4, 8, 14, 45, 00));
            Airline a51 = new Airline("Санкт-Петербург", 777, "Аэрофлот", "Пятница", new DateTime(2022, 12, 29, 21, 00, 00));
            Airline a61 = new Airline("Владивосток", 444, "Аэрофлот", "Суббота", new DateTime(2023, 01, 04, 12, 30, 00));

            List<Airline> list2 = new List<Airline>();
            list2.Add(a31);
            list2.Add(a41);
            list2.Add(a51);
            list2.Add(a61);
            Console.WriteLine("\n\n Оператор Join");
            int[] nums = { 123, 454, 151, 1012, 444, 999, 12 };
            var joinquery = airlist
                .Join(
                list2,
                w => w.RaceNumber,
                q => q.RaceNumber,
                (w, q) =>  new
                {
                    Race = w.RaceNumber + " " + w.Destination + " " + w.TimeOfDep,
                    SameFromSecondList = q.Destination + " " + q.RaceNumber + " " + q.TimeOfDep
                })
                .OrderBy(n => n.SameFromSecondList);
            foreach(var el in joinquery)
            {
                Console.WriteLine(el);
            }






        }

    }

}