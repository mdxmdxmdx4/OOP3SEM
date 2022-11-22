using lab08;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Program
    {
        static void Main()
        {
            Programmer prog = new Programmer("Dmitry");
            PLanguage C = new PLanguage("C#", 9.0f, "Полиморфизм", "Наследование", "Типизация");
            PLanguage SQL = new PLanguage("SQL", Math.Round(6.3f, 2), "Интерактивный", "Взаимодействие с БД");
            prog.Rename += C.ChangeName;
            prog.NewProperty += C.DeleteProperty;
            prog.NewProperty += SQL.AddProperty;
        

            prog.CommandRenameOperation("Cpp");
            prog.CommandCProp("Типизация");

            prog.NewProperty -= C.DeleteProperty;
            prog.NewProperty += C.AddProperty;

            prog.CommandCProp("Взаимодействие с объектами");
            Console.WriteLine(C);
            Console.WriteLine(SQL);




        }

    }
}
