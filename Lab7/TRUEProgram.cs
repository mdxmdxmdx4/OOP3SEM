using lab003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab003
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* vv  Можно использовать только при ограничении struct vv
                 * myStack<int> stack1 = new myStack<int>();
                stack1.Push(3);
                stack1.Add(4);
                stack1 += 10;
                stack1.Show();
                myStack<char> stack2 = new myStack<char>('2');
                stack2.Push('.');
                stack2.Add('b');
                stack2.Push('б');
                myStack<char> stack3 = new myStack<char>();
                stack3 = stack2 < stack3;
                stack3.Show();
                myStack<double> stackDouble = new myStack<double>();
                stackDouble.Push((double)3.12341123123f);
                stackDouble.Add(2.2222222222);
                stackDouble += -12314.12313141;
                stackDouble.Show();
                stackDouble.Sum();*/
                Island island = new Island("Сицилия", "Италия", 6000000);
                Island island1 = new Island("Сицилия", "Не Италия", 10000);
                island1.water.typeOFWater = "пресная";
                island1.water.square = 1234;
                Island island2 = new Island("Южный", "Новая Зеландия", 2000000);
                Island island3 = new Island("Гренландия", "Дания", 26000);
                myStack<Island> stack1 = new myStack<Island>();
                stack1.Push(island);
                stack1 += island1;
                stack1.Add(island2);
                stack1.Add(island3);
                stack1.Pop();
                
                myStack<Island> stack2 = new myStack<Island>();
                stack2 = stack1 < stack2;
                stack2.Show();
                stack2.Pop();
                stack2.Pop();
                stack2.Add(island3);
                myStack<Island>.WriteToFile(ref stack2);
                Console.WriteLine("\nЧтение из файла:\n");
                myStack<Island>.ReadFromFile();



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("end try-catch-finally");
            }

        }

    }
}
