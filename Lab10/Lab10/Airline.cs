using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Airline
    {
        private string _Destination;
        private int _RaceNumber;
        private string _AirplaneType;
        private string _WeekDay;
        private DateTime _TimeOfDep;
        private const int MaxRaceNumber = 999;
        private const int maxTimeD = 24;
        private static int kolvo;
        public readonly int id;
        public int RaceNumber               // v - свойства 
        {
            set
            {
                if (value > MaxRaceNumber)
                {
                    Console.WriteLine("\n*You enter an incorrect race number*");
                }
                else { this._RaceNumber = value; }
            }
            get { return this._RaceNumber; }
        }
        public string Destination
        {
            get { return this._Destination; }

        }
        public string AirplaneType
        {
            set { this._AirplaneType = value; }
            get { return this._AirplaneType; }
        }
        public string WeekDay
        {
            set { this._WeekDay = value; }
            get { return this._WeekDay; }
        }
        public DateTime TimeOfDep
        {
            set { this._TimeOfDep = value; }
            get { return this._TimeOfDep; }
        }
        static Airline()    //статический конструктор
        {
            kolvo = 0;
        }
        public Airline(string Destination, int RaceNumber, string AirplaneType, string WeekDay, DateTime TimeOfDep) //конструктор с параметрами
        {
            id = kolvo;
            _Destination = Destination;
            _RaceNumber = RaceNumber;
            _AirplaneType = AirplaneType;
            _WeekDay = WeekDay;
            _TimeOfDep = TimeOfDep;
            kolvo++;
        }
        public Airline()    //конструктор без параметров
        {
            id = kolvo;
            _Destination = "no data";
            _RaceNumber = 0;
            _AirplaneType = "no data";
            _WeekDay = "no data";
            _TimeOfDep = DateTime.MinValue;
            kolvo++;
        }
        ~Airline()      //деструктор
        {
            kolvo--;
        }
        public static void Weekday_check(Airline[] Air, out string needed_day)   //проверка по дню недели
        {

            Console.WriteLine("Insert a weekday");
            needed_day = Console.ReadLine();
            bool IsExistt = false;
            foreach (Airline day in Air)
            {
                if (needed_day == day.WeekDay)
                {
                    Console.WriteLine("Finded race:{0} {1} {2} {3}", day.Destination, day.RaceNumber, day.AirplaneType,
                        day.TimeOfDep);
                    IsExistt = true;
                }
            }
            if (IsExistt = false)
            {
                Console.WriteLine("No results found :(");
            }
        }
        public static void destination_check(Airline[] arr, ref string needed_weekday) //проверка по месту назначения
        {
            needed_weekday = "Bagdad";
            bool IsExists = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Destination == needed_weekday)
                {
                    IsExists = true;
                    Console.WriteLine("Finded race: " + arr[i].Destination + " " + arr[i].RaceNumber + " " + arr[i].AirplaneType + " " +
                    arr[i].WeekDay + " " + arr[i].TimeOfDep);
                }
            }
            if (IsExists == false)
            {
                Console.WriteLine("No such races or check your input\n");
            }

        }



        public static void printall(Airline[] array)          //вывод информации
        {
            Console.WriteLine("\n");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Race " + array[i].id + ": " + array[i]._Destination + " " + array[i]._RaceNumber + " "
                    + array[i]._AirplaneType + " " + array[i]._WeekDay + " " + array[i]._TimeOfDep);
            }


        }

        public override string ToString()                       //переопределение метода ToString() 
        {
            return ($"Пункт назначения: {this.Destination}, День недели: {this.WeekDay}, Номер рейса: {this.RaceNumber}, Тип самолёта: {this.AirplaneType}");
        }

        public override int GetHashCode()                       //переопределение метода GetHashCode()
        {
            Console.WriteLine("\n*Overriding of method GetHashCode()*");
            return base.GetHashCode();
        }
        public override bool Equals(object obj)                 //переопределение метода Equals()
        {
            Console.WriteLine("\n*Overriding of method Equals()*");
            Airline temp = obj as Airline;
            if (temp == null)
                return false;
            return (temp.Destination == this.Destination && temp.WeekDay == this.WeekDay &&
            temp.RaceNumber == this.RaceNumber && temp.AirplaneType == this.AirplaneType &&
            temp.TimeOfDep == this.TimeOfDep);
        }

    }
}
