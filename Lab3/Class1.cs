using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab003
{
    internal static class StaticOperation
    {
         public static void sum(this Stack obj)
        {
            int kkk = obj.Count();
            int sum = 0;
            for (int i = 0; i < kkk; i++)
            {
                sum += obj[i];
            }
            Console.WriteLine("Сумма элементов стека = " + sum);
        }

        public static int difference(this Stack obj)
        {
            int min = 9999;
            int max = 0;
            int leng = obj.Count();
            for (int i = 0; i < obj.Count(); i++)
            {
                if (obj[i] < min)
                {
                    min = obj[i];
                }
                if (obj[i] > max)
                {
                    max = obj[i];
                }
            }
            int diff = max - min;
            Console.WriteLine("Разница между наименьшим и наибольшим элемнтом стека: {0} - {1} = {2}", max, min, diff);
            return diff;

        }
        public static int CountOfElems(this Stack obj)
        {
            Console.WriteLine("--Сработал метод из статического класса--");
            return obj.Count();
        }

        public static int Middle(this Stack obj)
        {
            int kol = obj.Count();
            int all = 0;
           for(int i =0; i < kol; i++)
            {
                all += obj[i];

            }
            int middle = all / kol;

            Console.WriteLine("Средний элемент стека = " + middle);
            return middle;
        }

        public static int SentensX(this String obj)
        {
            int kolvo = 0;

           if(obj == null)
            {
                kolvo = 0;
            }
            else
            {
                string[] sent = obj.Split(new char[] {'.'} );
                foreach (var word in sent)
                {
                        kolvo++;
                }

            }
            Console.WriteLine("Количество предложения в строке = " + kolvo);
            return kolvo;
        }


    }
}