using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontrolV2
{
    public delegate void SomeDel(); 

    public class Button
    {
        public string name;

        public Button(string name)
        {
            this.name = name;
        }

        public void Print()
        {
            Console.WriteLine(name);
        }
    }
    public class User
    {
        public event SomeDel click;

        public void Click()
        {
            Console.WriteLine("Пользователь нажал на кнопку! ");
            if (click != null)
            {
                click();
            }
        }

    }
}
