using System.Linq;

namespace kontrolV2
{

    class Program
    {
           public class SuperHashSet<T> where T : struct
        {
           public HashSet<T> value;

        public SuperHashSet(HashSet<T> value)
        {
            this.value = value;
        }
        }
      

        static void Main(string[] args)
        {

            var set = new HashSet<int>() { 1, 5, 6, 7, 2 };
            Car ooo = new Car("goovach");
            Car nnn = new Car("Leshiiiq");
            HashSet<Car> set2 = new HashSet<Car> { ooo, nnn };

            HashSet<Car> set3 = new HashSet<Car> { new Car("sdfsdf"), new Car("235"), new Car("12") , new Car("235") }; 

            int size = set2.Count(n => n.name == "goovach");


            Console.WriteLine(set2.Count(n => n.name == "goovach"));
            Console.WriteLine(size);
            Console.WriteLine(set3.Count(n => n.name == "235"));

            var LIST = set3.Select(N => N.name);
            foreach (var item in LIST)
            {
                Console.WriteLine(item);
            }

            User Pasha = new User(); 
            Button big = new Button("конь");
            Button small = new Button("Дворянинкин");

            Pasha.click += new SomeDel(big.Print);
            Pasha.click += new SomeDel(small.Print);
            Pasha.Click();
        }

    }

}
