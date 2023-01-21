using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace oft
{
    [Serializable]
    [DataContract(Name = "Time")]
    public class Time: IComparable<Time>
    {
        private int hours;
        private int seconds;
        private int minutes;
        public int Hours
        {
            get { return hours; }
            set
            {
                if (value >= 0 && value <= 24)
                    hours = value;
                else
                {
                    Console.WriteLine("Некорректное время!");
                    hours = 0;
                }
            }
        }
        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value >= 0 && value <= 59)
                    seconds = value;
                else
                {
                    Console.WriteLine("Некорректное время!");
                    seconds = 0;
                }
            }
        }
        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value >= 0 && value <= 59)
                    minutes = value;
                else
                {
                    Console.WriteLine("Некорректное время!");
                    minutes = 0;
                }
            }
        }
        public int CompareTo(Time? other)
        {
            if (this.hours == other.hours && this.minutes == other.minutes)
                return 0;
            if(this.hours < other.hours)
                return -1;
            if (this.hours > other.hours)
                return 1;
            else return 999999;
        }
        public Time(int h, int m, int s)
        {
            Hours = h;
            Minutes = m;
            Seconds = s;
        }
        public override string ToString()
        {
            return hours + ":" + minutes + ":" + seconds;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Time T1 = new Time(6, 11, 44);
            Time T2 = new Time(12, 31, 33);
            Time T3 = new Time(23, 56, 777);
            Time T4 = new Time(2, 22, 41);
            Time T5 = new Time(4, 07, 07);
            Time[] times = { T1, T2, T3, T4, T5 };
            var night = from n in times
                        where n.Hours > 0 && n.Hours < 5
                        orderby n.Hours
                        select n;
            Console.WriteLine("Ночь");
            foreach (var item in night)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Утро");
            var morning = from n in times
                        where n.Hours > 5 && n.Hours < 12
                          orderby n.Hours
                          select n;
            foreach (var item in morning)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("День");
            var afternoon = from n in times
                        where n.Hours > 12 && n.Hours < 18
                            orderby n.Hours
                            select n;
            foreach (var item in afternoon)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Вечер");
            var evening = from n in times
                          where n.Hours > 18 && n.Hours < 24
                          orderby n.Hours
                          select n;
                        ;
            foreach (var item in evening)
            {
                Console.WriteLine(item);
            }
            var jsonn = new DataContractJsonSerializer(typeof(Time[]));
            using (var st = new FileStream("jsonTimeArray.json", FileMode.OpenOrCreate))
            {
                jsonn.WriteObject(st, times);
            }


        }
    }

    }
