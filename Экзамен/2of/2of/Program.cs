using System;
using System.Text.RegularExpressions;
using System.Linq;


namespace ad
{
    public interface IClearnable
    {
        public void Clearn();
    }
    public enum Spec { 
    POIT,
    ISIT,
        MOBILE
    }
    public class Group: IClearnable {
    public List<Stud> students = new List<Stud>();
    public void Add(Stud st)
        {
            students.Add(st);
        }

        public void Clearn()
        {
            if(students.Count == 0)
            {
                throw new Exception("Вы пытаетесь удалить пустую коллекцию");
            }
            else
                students.Clear();
        }
    }


    public class Stud
    {

        public string Name { get; set; }
        public int NumGroup { get; set; }
        public int Course { get; set; }
        public Spec spec;

        public int[] lastMarks;
        public double avg;
        public Stud(string n, int gr, int c, Spec en, params int[] mar)
        {
            Name = n;
            NumGroup = gr;
            Course = c;
            spec = en;
            lastMarks = mar;
        }

        public ValueTuple<int, int, double> AboutMarks()
        {
            int min = 999;
            int max = 0;
            int sum = 0;
            for(int i = 0; i < lastMarks.Length; i++)
            {
                if (lastMarks[i] < min)
                {
                    min = lastMarks[i];
                }
                if (lastMarks[i] > max)
                {
                    max = lastMarks[i];
                }
                sum += lastMarks[i];
            }
            double middle = Convert.ToDouble(sum)/ Convert.ToDouble(lastMarks.Length);
            Console.WriteLine(min+ " " + max + " " + middle);
            avg = middle;
            return (min, max, middle);

        }
        
    }

    public class Program
    {
        public static void Main()
        {
            var st1 = new Stud("Denis", 3, 2, Spec.ISIT, 6, 6, 6);
            var st2 = new Stud("Arseniy", 7, 2, Spec.MOBILE, 4, 4, 4);
            var st3 = new Stud("Pavel", 2, 2, Spec.POIT, 10, 7, 9);
            var st4 = new Stud("Maxim", 3, 2, Spec.ISIT, 4, 5, 4);
            var st5 = new Stud("Yana", 4, 1, Spec.POIT, 8, 9, 8);
            st1.AboutMarks();
            st2.AboutMarks();
            st3.AboutMarks();
            st4.AboutMarks();
            st5.AboutMarks();
            var Group = new Group();
            Group.Add(st1);
            Group.Add(st2);
            Group.Add(st3);
            Group.Add(st4);
            Group.Add(st5);
            var res = Group.students
                .GroupBy(n => n.spec)
                .Select(n => n.Max(n => n.avg))
                .ToArray();
            var x = Group.students
                .Join(
                res,
                w => w.avg,
                q => q,
                (w, q) => new
                {
                    avg = w.avg,
                    name = w.Name,
                    spec = w.spec
                }
                );
            foreach (var el in x)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine();
            try
            {
                Group.Clearn();
                Console.WriteLine(Group.students.Count);
                Group.Clearn();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}

