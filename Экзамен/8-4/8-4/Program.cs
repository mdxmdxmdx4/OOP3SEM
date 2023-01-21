


using System.Collections.Generic;

namespace foreeee {
public interface IScore
    {
        public int Amount { get; set; }
        public void AddCash() { }
        public void TakeCash() { }

    }
    public abstract class Human
    {
        public DateTimeOffset date;
    }
    public class Person : Human, IScore
    {
        public int Amount { get; set; }
        private static int count ;
        static Person()
        {
            count = 0;
        }
        public Person(DateTimeOffset dt, int cash) {
            Amount = cash;
            date = dt;
            count++;
        }
        public void AddCash(int mon)
        {
            Amount += mon;
        }
        public void TakeCash(int mon) {
            Amount -= mon;
        }
        public static void ShowCount()
        {
            Console.WriteLine("Кол-во экземпляров Person = " + count);

        }
        public override bool Equals(object? obj)
        {
            var pers = obj as Person;
            return pers.date == this.date;
        }



    }
    public class Bank
    {
        public List<Person> people = new List<Person>();
        public void Add(Person p)
        {
            people.Add(p);
        }

    }

    public class Program
    {
        public static void Main()
        {
            DateTimeOffset dt = new DateTimeOffset(DateTime.Now);
            DateTimeOffset dt2 = new DateTimeOffset(2022,2,2,1,1,1,TimeSpan.Zero);
            var p1 = new Person(dt, 700);
            var p2 = new Person(dt2, 100);
            var p3 = new Person(dt, 5000);
            var p4 = new Person(dt2, 0);
            var p5 = new Person(dt, 80);
            Console.WriteLine("Баланс p3:" + p3.Amount);
            p3.AddCash(1234);
            Console.WriteLine("Баланс p3 после пополнения:" + p3.Amount);
            p3.TakeCash(5555);
            Console.WriteLine("Баланс p3 после снятия:" + p3.Amount);
            Person.ShowCount();
            Console.WriteLine(p1.Equals(p5));
            var belarus = new Bank();
            belarus.Add(p1);
            belarus.Add(p2);
            belarus.Add(p3);
            var alfa = new Bank();
            alfa.Add(p1);
            alfa.Add(p4);
            alfa.Add(p5);
            var vtb = new Bank();
            vtb.Add(p2);
            vtb.Add(p1);
            vtb.Add(p4);
            var t1 = new Task(() =>
            {
                foreach (var el in belarus.people)
                {
                    if (el.date == dt2)
                    {
                        Console.WriteLine($"Клиент банка Belarus с указанной датой {dt2.ToString()} найден");
                    }
                }
            });
            var t2 = new Task(() =>
            {
                foreach (var el in vtb.people)
                {
                    if (el.date == dt)
                    {
                        Console.WriteLine($"Клиент банка VTB с указанной датой {dt.ToString()} найден");
                    }
                }
            });
            var t3 = new Task(() =>
            {
                foreach (var el in alfa.people)
                {
                    if (el.date == dt)
                    {
                        Console.WriteLine($"Клиент банка Alfa с указанной датой {dt.ToString()} найден");
                    }
                }
            });
            t1.Start();
            t2.Start();
            t3.Start();
            Console.Read();
            

        }
    }



}

