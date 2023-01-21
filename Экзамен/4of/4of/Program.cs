

using System.Drawing;
using System.Reflection;

namespace off
{
    public delegate void ChangeEventHandler();
    public class DeleteException : Exception { 
    public DeleteException(string message) : base(message) { }
    }

    public class D2Path
    {
        public event ChangeEventHandler Change;
        public List<D2Point> Points = new List<D2Point>();
        public void OnChange() {
            Change.Invoke();
            Console.WriteLine("Вызвано событие CHANGE!");
        }
        public void Add(D2Point p)
        {
            Points.Add(p);
        }
        public void Delete(D2Point item) { 
            Points.Remove(item);
            if(Points.Count == 0)
            {
                throw new DeleteException("Вы пытаетесь удалить из пустой коллекции");
            }
        }
        public void Clear()
        {
            Points.Clear();
        }
        public ValueTuple<int, int, int, int> CountPoints()
        {
            int LeftTop = 0;
            int RightTop = 0;
            int LeftBottom = 0;
            int RightBottom = 0;
            foreach (var point in Points)
            {
                if (point.X < 0 && point.Y < 0)
                    LeftBottom++;
                if (point.X > 0 && point.Y > 0)
                    RightTop++;
                if (point.X < 0 && point.Y > 0)
                    LeftTop++;
                if (point.X > 0 && point.Y < 0)
                    RightBottom++;
            }
            Console.WriteLine(RightTop + " " + LeftTop + " " + LeftBottom + " " + RightTop);
            return (RightTop, LeftTop, LeftBottom, RightTop);
        }
        public  static bool operator ==(D2Path p, D2Path p1) {
            return p.Equals(p1);
        }
        public static bool operator !=(D2Path p, D2Path p1)
        {
            return !p.Equals(p1);
        }


    }
    public class D2Point {
        public int X { get; set; }
        public int Y { get; set; }
        public D2Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void doChange()
        {
            X = X * -1;
            Y = Y * -1;
        }

    }

    public class Program {

        public static void Main(string[] args)
        {
            var point1 = new D2Point(1,2);
            var point2 = new D2Point(-10, -21);
            var point3 = new D2Point(-98, 2);
            var point4 = new D2Point(1, -2);
            var point5 = new D2Point(333, 444);
            var point6 = new D2Point(5, -2);
            var point7 = new D2Point(-3, -3);
            var D2Path = new D2Path();
            D2Path.Add(point1);
            D2Path.Add(point2);
            D2Path.Add(point3);
            D2Path.Add(point4);
            D2Path.Add(point5);
            D2Path.Add(point6);
            D2Path.Add(point7);
            D2Path.CountPoints();
            Console.WriteLine("До события:");
            Console.WriteLine(point1.X + " " + point1.Y);
            Console.WriteLine(point2.X + " " + point3.Y);
            D2Path.Change += point1.doChange;
            D2Path.Change += point2.doChange;
            Console.WriteLine("После события");
            D2Path.OnChange();
            Console.WriteLine(point1.X + " " + point1.Y);
            Console.WriteLine(point2.X + " " + point3.Y);
            Type t = typeof(D2Point);
            foreach(var el in t.GetConstructors())
            {
                Console.WriteLine(el.Name);
            }
            foreach (FieldInfo el in t.GetFields())
            {
                Console.WriteLine(el.Name);
            }




        }
    }

}
