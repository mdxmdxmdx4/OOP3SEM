namespace kr
{
    public class SuperStack<T>
    {
        public Stack<T> mys = new Stack<T>();

        public void Add(T el)
        {
            mys.Push(el);
        }

        public static bool operator ==(SuperStack<T> a1, SuperStack<T> a2)  //перегрузка операторов
        {
            return a1.mys.Count() == a2.mys.Count();

        }
        public static bool operator !=(SuperStack<T> a1, SuperStack<T> a2)  //перегрузка операторов
        {
            return a1.mys.Count() == a2.mys.Count();

        }
    }

    public class Program
    {
        static void Main()
        {
            var stack = new SuperStack<int>();
            stack.Add(0);
            stack.Add(2);
            var st2 = new SuperStack<int>();
            st2.Add(1);
            Console.Write(st2 == stack);
            Console.WriteLine();
            st2.Add(2);
            Console.WriteLine(st2 == stack);


        }
    }
 
}