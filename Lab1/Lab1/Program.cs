using System;
using System.Collections.Specialized;
using System.Text;

namespace Lab1
{
    class firstclass
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            //         1) Типы
            //task A
            bool TaskA1 = true;
            char TaskA2 = 'g';
            long TaskA3 = 12312313;
            decimal TaskA4 = 132.41234m;
            float TaskA5 = 5.5f;
            short TaskA6 = -12314;
            int TaskA7 = 10;
            double TaskA8 = 7.1234123;
            Console.WriteLine(".........1)Types..........\n" +
                " \n----Task A----\n Bool = {0} \n Char = {1} \n Long = {2} \n Decimal = {3} \n" +
                " Float = {4} \n Short = {5} \n Int = {6}\n Double = {7}\n ",
                TaskA1, TaskA2, TaskA3, TaskA4, TaskA5, TaskA6, TaskA7, TaskA8);
            //task B
            int b1 = Convert.ToInt16(0.981231);  //1 явное
            Console.WriteLine(" ----Task B---- \n b1 = " + b1 + " , " + b1.GetType());
            long b2 = (long)b1; //2 явное
            short b3 = (short)b2; //3 явное
            bool b4 = Convert.ToBoolean(b3); //4 явное
            Console.WriteLine("short ---> bool, now b4 = " + b4);
            int b5 = Convert.ToInt32(b4); //5 явное
            Console.WriteLine("type of b5 is {0}", b5.GetType(), '\n');

            float b6 = 1.2123123f;
            double b7 = b6; // float -> double (1)
            byte b8 = 8;
            short b9 = b8; // byte -> short (2)
            b1 = b9; // short -> int    (3)
            b2 = b1; // int -> long (4)
            double b10 = b1; // int -> double (5)
            // task C
            int i = 123;
            object o = i;
            o = 123;
            i = (int)o;
            //task D
            var a = 28;
            var b = 1.123412;
            Console.WriteLine("\n ----Task D----\nvar a is " + a.GetType() + ", var b is" + b.GetType());
            var c = a + b;
            Console.WriteLine("var c is " + a.GetType());
            //task E
            Console.WriteLine("\n ----Task E----\n");
            int? e1 = null;
            int? e2 = null;
            Console.WriteLine("Compairing nullable = {0}\nSum of nullable = {1}", e1 == e2, e1 + e2);
            //task F
            Console.WriteLine("\n ----Task F----\n");
            var f1 = 123.12312;
            f1 = 12;
            Console.WriteLine("f1 = {0}, {1}", f1, f1.GetType());
            //2)  Строки
            //Task A
            Console.WriteLine("\n\n.........2)Strings..........\n\n ----Task A----\n");
            string s1 = "wex";
            string s2 = "wex";
            string s3 = "notwex";
            Console.WriteLine($"Compairing strings s1 и s2: {s1 == s2}");
            Console.WriteLine($"Compairing strings s2 и s3 : {s2 == s3}");
            //Task B
            Console.WriteLine("\n ----Task B----\n");
            string string1 = "exort";
            string string2 = "some words here";
            string string3 = "amg";
            Console.WriteLine("concantenation: " + String.Concat(string1, string2));
            Console.WriteLine("Copirovanie: " + String.Copy(string1));
            Console.WriteLine("SUBSTRING: " + string2.Substring(5));
            string[] string4 = string2.Split(' ');
            Console.WriteLine("Splitint str2:");
            foreach (var asd in string4)
            {
                Console.WriteLine(asd);
            }
            Console.WriteLine("Inserting string in string: " + string3.Insert(2, string1));
            Console.WriteLine("Deleting substring: " + string2.Remove(6) + "\n\n ----Task C----");
            //Task C
            string nllstr = null;
            string vstr = "";
            Console.WriteLine("isnullorempty on nullstr: {0} , on voidstr : {1}", string.IsNullOrEmpty(nllstr),
                string.IsNullOrEmpty(vstr));
            Console.WriteLine("Equality of strings : " + (nllstr == vstr) + ", Concantenation: " + String.Concat(vstr, nllstr) + "\n\n ----Task D----\n");
            //Task D
            StringBuilder SB = new StringBuilder("ABC", 20);
            SB.Remove(1, 2);
            SB.Append(new char[] { 'D', 'E', 'F' });
            SB.Insert(0, "GEM");
            Console.WriteLine("{0} chars: {1}", SB.Length, SB.ToString());
            // 3) Массивы
            // Task A
            int ArrayWidth = 4;
            int ArrayHeight = 5;
            int[,] DoubleArray = new int[ArrayWidth, ArrayHeight];
            Console.WriteLine("\n\n.........3)Arrays..........\n\n ----Task A----\n Matrix:)");
            for (int j = 0; j < ArrayWidth; j++)
            {
                for (int k = 0; k < ArrayHeight; k++)
                {
                    DoubleArray[j, k] = j + k * 2;
                    Console.Write(DoubleArray[j, k] + " ");
                }
                Console.Write("\n");
            }
            //Task B
            string[] StringArr = { "scars", "up", "on", "my", "wrist" };
            Console.WriteLine("\n ----Task B----:\n");
            foreach (var elem in StringArr)
            {
                Console.Write(elem + " | ");
            }
            Console.WriteLine("\nWhich element you want to change? (0-" + (StringArr.Count() - 1) + ") ");
            int zzz = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write a standin");
            StringArr[zzz] = Console.ReadLine();
            Console.WriteLine("New Array:");
            foreach (var elem in StringArr)
            {
                Console.Write(elem + ",");
            }
            //Task C           !!!!!!!!!!!!!!!!!!!!!! ДОДЕЛАТЬ!!!!!!!!!!!!
            Console.WriteLine("\n\n ----Task C---");
            float[][] StepArray = new float[3][];
            for (var ai = 1; ai < 4; ai++)
            {
                StepArray[ai - 1] = new float[ai + 1];
            }

            for (var bi = 0; bi < 3; bi++)
            {
                for (var j = 0; j < StepArray[bi].Length; j++)
                {
                    Console.WriteLine("StepArray[{0}][{1}]: ", bi, j);
                    StepArray[bi][j] = float.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
            for (var ci = 0; ci < 3; ci++)
            {
                for (var j = 0; j < StepArray[ci].Length; j++)
                {
                    Console.Write("{0} ", StepArray[ci][j]);
                }

                Console.WriteLine();
            }

            //
            Console.WriteLine("\n ----Task D---");
            var array1 = new object[0];
            var str = "";
            Console.WriteLine("1st type: {0} ,2nd type: {1}",array1.GetType(), str.GetType());
            // 4 Кортежи
            Console.WriteLine("\n\n.........4)Tuple..........\n ----Task A----");
            
                        (int, string, char, string, ulong) reference = (1, "HEad", 'g', "food", 65758758);

                        Console.WriteLine("весь кортеж -  " + reference + " ");
                        Console.WriteLine("1st item" + reference.Item1);
                        Console.WriteLine("2nd item" + reference.Item3);
                        Console.WriteLine("3rd itme" + reference.Item5);

            Console.WriteLine(" ----Task B----");
            int int1;
            string string01, string02;
            char char1;
            ulong ulong1;
            Console.WriteLine(" ----Task C----");
            (_, string1, _, _, ulong1) = reference;
            (int1 , _, char1, string2, _) = reference;
            Console.WriteLine(" ----Task D----");
            var tuple1 = (1.1231f, 2m, 3, "131", 'q');
            var tuple2 = (1.1231f, 2m, 3, "131", 'q');
            Console.WriteLine("Equality of tuples:" + (tuple1 == tuple2));
            Console.WriteLine("\n\n.........5)Local function..........\n");
            static (int, int, int, char) Localfunction(int[] numbers, string str1)
            {

                int min = int.MaxValue;
                int max = int.MinValue;
                int sum = 0;


                foreach (int elem in numbers)
                {
                    sum += elem;
                    if (elem < min)
                    {
                        min = elem;
                    }

                    if (elem > max)
                    {
                        max = elem;
                    }
                }

                char letter = str1[0];

                return (max, min, sum, letter);

            };
             var nums = new[]
                { 991, 1241, 777, 11, 31};
            var strforfunc = "miracle^";
            Console.WriteLine(Localfunction(nums, strforfunc));
            Console.WriteLine("\n\n..........Checked/unchecked..........\n");
            static int localf2()
            {
                int mval = int.MaxValue;
                unchecked
                {
                    Console.WriteLine("unchecked: " + (mval + 1));
                };
                return mval;
            };
            static int localf3()
            {
                int mval2 = int.MaxValue;
                try
                {
                    checked
                    {
                        Console.WriteLine(mval2 + 1);
                    }
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
                }
                return mval2;
            };
            localf2();
            Console.WriteLine("if we will use \" checked \", compiler will throw an error, so using try/catch construction\n");
            localf3();

        }

    }


}