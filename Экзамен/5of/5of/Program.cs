


namespace five
{
    public class ForWrite
    {
        public static void Write(string mess)
        {
            using (var fs = new StreamWriter("as.txt", true))
            {
                fs.WriteLine(mess);
            }
        }
    }

        public enum forStatus
        {
            fly,
            ready,
            stop
        }
        public abstract class Transport
        {
            public int Speed { get; set; }
            public int CountOfPassangers { get; set; }
        }
        public interface IAirable
        {
            public void Fly();
            public void Check();

        }
        public interface IAirHostess
        {
            void Check();

        }

        public class Air : Transport, IAirable, IAirHostess
        {
            public Air(int s, int count, forStatus st)
            {
                Speed = s;
                CountOfPassangers = count;
                status = st;
            }
            public forStatus status;
            public void Fly()
            {
                if (status == forStatus.fly)
                {
                    Console.WriteLine("Flying");
                    ForWrite.Write("Fly(): Flying");
                }
                else
                {
                    throw new Exception("NotFlying");
                    ForWrite.Write("Fly(): error \"NotFlying\"");
                }

            }

            void IAirable.Check()
            {
                if (status == forStatus.ready && this.Speed > 0 && this.CountOfPassangers > 0)
                {
                    status = forStatus.fly;
                    ForWrite.Write("IAirable.Check() : статус изменен на  fly ");
                    Console.WriteLine("IAirable.Check() : статус изменен на  fly ");
                }
                if (this.Speed == 0 && this.CountOfPassangers == 0)
                {
                    this.status = forStatus.stop;
                    ForWrite.Write("IAirable.Check() :  статус изменен на stop ");
                Console.WriteLine("IAirable.Check() :  статус изменен на stop ");
                }
                if (this.Speed == 0 && this.CountOfPassangers > 0)
                {
                    this.status = forStatus.ready;
                    ForWrite.Write("IAirable.Check() : статус изменен на ready ");
                    Console.WriteLine("IAirable.Check() : статус изменен на ready ");
                }
            }

            void IAirHostess.Check()
            {
                if (this.CountOfPassangers > 20 && this.CountOfPassangers < 100)
                {
                    Console.WriteLine("Ready");
                    ForWrite.Write("IAirHostess.Check() : \"Ready\"");
                }
            }
        }


        public class Program
        {
            public static void Main()
            {
                var air1 = new Air(0, 25, forStatus.stop);
                var air2 = new Air(10, 70, forStatus.ready);
                var air3 = new Air(225, 80, forStatus.fly);
                var air4 = new Air(555, 110, forStatus.stop);
                var air5 = new Air(555, 110, forStatus.ready);
                ((IAirable)air1).Check();
                ((IAirable)air2).Check();
                try
                {
                    air1.Fly();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                ((IAirHostess)air3).Check();
                Air[] Airs = { air1, air2, air3, air4, air5 };
                var res = Airs
                    .Count(n => n.status == forStatus.fly);
                var res2 = Airs
                    .Average(n => n.Speed);

                Console.WriteLine("Самолётов в воздухе: " + res);
                Console.WriteLine("Средняя скороть самолётов = " + res2);
            }
        }
}