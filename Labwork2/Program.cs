using System;
using System.Runtime.CompilerServices;

namespace lab2
{   partial class Airlane
    {
        private string _Destination;
        private int _RaceNumber;
        private string _AirplaneType;
        private string _WeekDays;
        private DateTime _TimeOfDestination;
        private const int MaxRaceNumber = 999;
        public int RaceNumber
        {
            set
            {
                if (value < MaxRaceNumber)
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
        public string WeekDays
        {
            set { this._WeekDays = value; }
            get { return this._WeekDays; }
        }
        public DateTime TimeOfDestination { 
            set { this._TimeOfDestination = value;}
            get { return this._TimeOfDestination;}
            }



        private const int maxTimeD = 24; 
        private static int kolvo;
        public readonly int id;
        static Airlane()
        {
            kolvo = 0;
        }


        public Airlane(string Destination, int RaceNumber, string AirplaneType, string WeekDays, DateTime TimeOfDestination)
        {
            id = kolvo;
            _Destination = Destination;
            _RaceNumber = RaceNumber;
            _AirplaneType = AirplaneType;
            _WeekDays = WeekDays;
            _TimeOfDestination = TimeOfDestination;
            kolvo++;
        }
        public Airlane()
        {
            id = kolvo;
            _Destination = "no data";
            _RaceNumber = 0;
            _AirplaneType = "no data";
            _WeekDays = "no data";
            _TimeOfDestination = DateTime.MinValue;
            kolvo++;
        }
        ~Airlane()
        {
            kolvo--;
        }

        public static void printall(Airlane[] array)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Race " + array[i].id +  ": " + array[i]._Destination + " " +array[i]._RaceNumber + " "
                    + array[i]._AirplaneType + " " + array[i]._WeekDays + " "+ array[i]._TimeOfDestination);
            }


        }

        public override int GetHashCode()                       //переопределение метода GetHashCode()
        {
            Console.WriteLine("\nOverriding of method GetHashCode");
            return base.GetHashCode();
        }
        public override bool Equals(object obj)                 //переопределение метода Equals()
        {
            Console.WriteLine("\nOverriding of method Equals");
            Airlane temp = obj as Airlane;
            if (temp == null)
                return false;
                return (temp.Destination == this.Destination && temp.WeekDays == this.WeekDays && 
                temp.RaceNumber == this.RaceNumber && temp.AirplaneType == this.AirplaneType && 
                temp.TimeOfDestination == this.TimeOfDestination);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Airlane[] airlane = new Airlane[6] {
                new Airlane("Bagdad", 12, "Boeing", "Monday", new DateTime(2022, 09, 11, 23, 00, 00)),
                new Airlane("Kiev", 151, "Boeing", "Friday", new DateTime(2022, 09, 15, 16, 45, 00)),
                new Airlane("Warsaw", 75, "Boeing", "Tuesday", new DateTime(2022, 09, 15, 19, 00, 00)),
                new Airlane("Beigin", 99, "Boeing", "Tuesday", new DateTime(2022, 09, 20, 22, 45, 00)),
                new Airlane("Qatar", 151, "Boeing", "Wednesday", new DateTime(2022, 09, 29, 03, 30, 00)),
                new Airlane()
            };

            Airlane.printall(airlane);
            airlane[2].AirplaneType = "NotBoeing";
            airlane[3].RaceNumber = 777;
            airlane[4].WeekDays = "Sunday";
           // airlane[5].Destination = "Madrid";
            airlane[5].AirplaneType = "QatarAirways";
            airlane[5].RaceNumber = 1099; 
            airlane[5].WeekDays = "Saturday";
            airlane[5].TimeOfDestination = new DateTime(2022, 10, 1, 11, 00, 00);
            Airlane.printall(airlane);
            Console.WriteLine(airlane[1].GetHashCode());
            Console.WriteLine( "Checking equality of 2 objects:" + (airlane[0].Equals(airlane[5])));
        }


    }


}