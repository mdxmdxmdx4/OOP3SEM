
using System.Text;

namespace Lab11
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Пользовательский тип:\n");

            Reflector.AssemblyInfo("CheckRefl");
            Reflector.CtorInfo("CheckRefl");
            Reflector.Method("CheckRefl");
            Reflector.Interface("CheckRefl");
            Reflector.MethodForType("CheckRefl", typeof(System.String));
            object[] p = { "reflection", 10 };
            object o = Reflector.Create("CheckRefl", p);
            Console.WriteLine(o.GetType());
            Reflector.Voke("CheckRefl", "VoidWrite");

            Console.WriteLine("\n\n-------------------------------------------\n\n");
            Console.WriteLine("Встроенный тип System.String:\n");

            Reflector.AssemblyInfo("String");
            Reflector.CtorInfo("String");
            Reflector.Method("String");
            Reflector.Interface("String");
            Reflector.MethodForType("String", typeof(System.Int32));
        }


    }


}