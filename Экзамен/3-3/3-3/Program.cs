


using System.Linq;

namespace third
{
    public static class Printer
    {
        public static void Printt(string message)
        {
            using(var sw = new StreamWriter("12314.txt", true))
            {
                sw.WriteLine(message);
            }
        }
    }
    public class SomeString : IComparer<SomeString>
    {
        public string example;
        public SomeString(string s)
        {
            example = s;
        }

        public int Compare(SomeString? x, SomeString? y)
        {
            
            if (x.example.Length < y.example.Length)
                return -1;
            if (x.example.Length > y.example.Length)
                return 1;
            return 0;
        }

        public override bool Equals(object? obj)
        {
            var st = obj as SomeString;
            if (st != null)
            {
                if (st.example.First() == example.First() && st.example.Last() == example.Last() && example.Length == st.example.Length)
                    return true;
            }
            return false;
        }

        public static SomeString operator +(SomeString ex1, char a)
        {
            ex1.example += a;
            return ex1;
        }
        public static SomeString operator -(SomeString ex1, char a)
        {
            var v = new SomeString("");
            if(ex1.example.Length == 0)
            {
                throw new Exception("Строка пустая!");
            }
            for(int i = 1; i < ex1.example.Length; i++)
            {
                v.example += ex1.example[i];

            }
            return v;
        }
    }

    public static class StringStatic { 
    public static int SpaceCountt(this String st)
        {
            int cspace = 0;
            string[] sp = st.Split(' ');
            foreach(var el in sp)
            {
                cspace++;
            }
            return cspace - 1;
        }
        public static string DeleteSymbols(this String st, string a)
        {
            string[] arr = { ",", ".", "!", ".", "-" };
            string res = "";
            for(int i = 0; i < (a.Length - 1); i++)
            {
                for(int j = 0; j < 0; j++)
                {
                    if (a[i] != a[j])
                        res += a[i];
                }

            }
            return res;
        }

    
    }

    public class Program
    {
        public static void Main()
        {
            SomeString s1 = new SomeString("as af");
            SomeString s2 = new SomeString("afaff");
            SomeString s3 = new SomeString("BSTU");
            SomeString s4 = new SomeString("OOP and C#");
            SomeString s5 = new SomeString("Steam");


            var aa = new SomeString[5];
            aa[0] = s1;
            aa[1] = s2;
            aa[2] = s3;
            aa[3] = s4;
            aa[4] = s5;
            var res = aa
                .Sum(n => n.example.SpaceCountt());
            Printer.Printt(Convert.ToString(res));
            Printer.Printt(Convert.ToString(s1.Equals(s2)));
            Printer.Printt(s1.example);
            s1 += 'k';
            s1 -= 'l';
            Printer.Printt(s1.example);
            Printer.Printt(Convert.ToString(s4.example.SpaceCountt()));
            Printer.Printt(Convert.ToString(s1.Compare(s1,s2)));
            Printer.Printt(Convert.ToString(s1.Compare(s1,s4)));
            Printer.Printt(Convert.ToString(s1.Compare(s4,s5)));


            
        
        }
    }


}