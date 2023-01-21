


namespace seven
{
    public enum forCheck
    {
        checkedd,
        uncheckedd
    }
    public class Button
    {
        public string caption;
        public (double, double) startpoint;
        public double w;
        public double h;
        public Button(string caption, double x, double y, double w, double h)
        {
            this.caption = caption;
            this.startpoint.Item1 = x;
            this.startpoint.Item2 = y;
            this.w = w;
            this.h = h;
        }
    }
    public class CheckButton : Button
    {
        public void Check()
        {
            if(state == forCheck.uncheckedd)
                state = forCheck.checkedd;
            if(state == forCheck.checkedd)
                state = forCheck.uncheckedd;
        }
        public void Zoom(double prec)
        {
            w = w * (1 - prec);  
            h = h * (1 - prec);
            startpoint.Item1 = startpoint.Item1 * (1 - prec);
            startpoint.Item2 = startpoint.Item2 * (1 - prec);



        }
        public forCheck state;

        public CheckButton(string cap, double x, double y, double w, double h, forCheck ch) : base(cap, x, y, w, h)
        {
            caption = cap;
            startpoint.Item1 = x;
            startpoint.Item2 = y;
            this.w = w;
            this.h = h;
            state = ch;
        }

        public override string ToString()
        {
            return $"Кнопка со св-вами: X={startpoint.Item1}, Y= {startpoint.Item2}, W= {w}, H={h}";
        }
        public override bool Equals(object? obj)
        {
            if(obj is CheckButton == true)
            {
                var el = obj as CheckButton;
                if (this.h == el.h && this.w == el.w && this.startpoint == el.startpoint)
                    return true;
                else
                    return false;

            }
            return false;
        }
        public void OnClick()
        {
            Check();
            Console.WriteLine("Состояние изменено на " + state.ToString());
        }
        public void OnZoom(double pr)
        {
            Zoom(pr);
        }


    }
    public delegate void ForClick();
    public delegate void ForZoom(double pr);
    
    public class User {
        public event ForClick Click;
        public event ForZoom Zoom;
        public void ClickButton()
        {
            Console.WriteLine("Click!");
            Click.Invoke();
        }
        public void UseZoom(double pr) {
            Console.WriteLine("Zoom!");
            Zoom.Invoke(pr);

        }
    }


    public class Program { 
    public static void Main()
        {
            var cb1 = new CheckButton("nocap", 10, 10, 10,10, forCheck.checkedd);
            cb1.Zoom(0.5);
            cb1.Check();
            Console.WriteLine(cb1.state.ToString());
            var cb2 = new CheckButton("zigzag", 16, 15, 2, 7, forCheck.checkedd);
            var cb3 = new CheckButton("drach", 33, 1, 2, 6, forCheck.uncheckedd);
            var user = new User();
            user.Click += cb1.OnClick;
            user.Click += cb3.OnClick;
            user.ClickButton();
            user.Zoom += cb2.Zoom;
            user.Zoom += cb1.Zoom;
            user.UseZoom(0.2);
            var ll = new LinkedList<Button>();
            ll.AddLast(cb1);
            ll.AddLast(cb2);
            var regb1 = new Button("nocap", 3, 91, 2, 3);
            ll.AddLast(regb1);
            Console.WriteLine("Введите желаемую площадь");
            double sq = Convert.ToDouble(Console.ReadLine());
            var needenb = ll
                .Where(n => n.w * n.h == sq)
                .Select(n => new {X = n.startpoint.Item1, Y = n.startpoint.Item2, W = n.w, H = n.h });
            foreach(var el in needenb)
            {
                Console.WriteLine(el);
            }
            var btns = ll
                .Where(n => n.GetType() == cb2.GetType());
            foreach(var el in btns)
            {
                Console.WriteLine(el);
            }






        }
    }



}