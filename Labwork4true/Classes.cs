using Labwork4true;
using System;
using System.Drawing;

namespace lab004
{
    class Planet {
        public string Name;
        public int Precentage;
        public virtual void Chain() {
            Console.WriteLine("Вы находитесь на уровне: " + Name);
        }
        public Planet(string name)
        {
            this.Name = name;
            Precentage = 100;
        }
        public Planet()
        {

        }
          public void PrintName()
        {
            Console.WriteLine("Название объекта - " + Name);
        }
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Море: {this.Name}, является главным звеном, занимает {this.Precentage}% системы");
        }
    }
    abstract class Water : Planet {

        public abstract bool TToCompare(object obj); 
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Все водные ресурсы системы, занимают {this.Precentage}%");
        }
        public Water()
        {
            Precentage = 71;
        }
    }
    abstract class Ground : Planet
    {
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Все ресурсы суши, занимают {this.Precentage}% от всей планеты");
        }
        public string Parent;
        public abstract void Info();
    public Ground()
        {
            Precentage = 21;
        }
    }

    sealed class Sea : Water, FirstInterface {
        public string TypeOfWater;
        public override bool TToCompare(object obj)
        {
            Sea sea = obj as Sea;
            if (sea != null)
            {
                return sea.Name == Name ;
            }
            return false;
        }
        public override void Chain()
        {
            Console.WriteLine("Нижний уровень иерархии Water ---> Sea :" + Name);
        }
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Море: {this.Name}, занимает {this.Precentage}% водной части континента, тип воды - {this.TypeOfWater}");
        }

        public override int GetHashCode()                       //переопределение метода GetHashCode()
        {
            Console.WriteLine("\n**Переопределение GetHashCode()**");
            return base.GetHashCode();
        }
        public override bool Equals(object obj)                 //переопределение метода Equals()
        {
            Console.WriteLine("\n**Переопределение метода Equals()**");
            Sea temp = obj as Sea;
            if (temp == null)
                return false;
            return (temp.Name == this.Name && temp.Precentage == this.Precentage &&
            temp.TypeOfWater == this.TypeOfWater);
        }

        bool FirstInterface.TToCompare(object obj)
        {
            if (obj is Sea sea)
            {
                if (sea.TypeOfWater == TypeOfWater)
                {
                    Console.WriteLine($"\nОба моря имеют тип воды = {sea.TypeOfWater}");
                    return true;
                }
                else return false;
            }
            return false;
        }

        public Sea(string name, string type)
        {
            Name = name;
            TypeOfWater = type;
        }
        public Sea() { }
    }
    class Continent : Ground {
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Континент {this.Name}, население = {this.Humanity}");
        }
        public double PrecOfC;
        public long Humanity;
        public Continent(string name, long humanity)
        {
            PrecOfC = 100;
            Name = name;
            Humanity = humanity;
        }
        public Continent(){}
        public override void Info()
        {
            Console.WriteLine("Континет - " + Name);
        }

    }
    class Government: Continent {
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Государство {this.Name}, население = {this.Humanity}, валюта - {this.Vallet}, глава гос-ва - {this.HeadOfG}");
        }
        public Government(string name, string head, string vallet, int humanity, string ParentName, long Phumanity) : base(ParentName, Phumanity)
        {
            Name = name;
            HeadOfG = head;
            Vallet = vallet;
            Humanity = humanity;
            PrecOfC= Convert.ToDouble(humanity) / Convert.ToDouble(Phumanity);
        }
        public string HeadOfG;
        public string Vallet;
        public override void Info()
        {
            Console.WriteLine("Cтрана - " + Name);
        }
        public Government() {}


        public  void ShowHierarchy()
        {
            Console.Write("Государство - " + Parent) ;
        }

    }
    class Island : Government, ICloneable {

  
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Остров {this.Name}, относится к гос-ву {this.Parent}, население острова  = {this.Humanity}");
        }
        public override void Chain()
        {
            Console.WriteLine("\n\nКонтинет ---> Страна ---> Остров");
            Console.WriteLine("Вы сейчас находитесь тут  ^^^^^^ " + Name + "\t\t конец цепочки");
        }
        public override void Info()
        {
            Console.WriteLine("Остров - " + Name);
        }
        public Island(string name, string country, string head, string vallet, int humanity, string continent,int ParentHumanity, long Chu) : base(country, head, vallet, ParentHumanity, continent, Chu)
        {
            Name = name;
          //Square = square;
            Parent = country;
            Humanity= humanity;
        }
        public Island() {}
        public new void ShowHierarchy()
        {
            base.ShowHierarchy();
            Console.Write(",к нему относится остров - " + Name);
        }

        public object Clone()
        {
            return new Island()
            {
                Name = this.Name,
                Humanity = this.Humanity,
                Parent = this.Parent,
                Vallet = this.Vallet,
                HeadOfG = this.HeadOfG
            };
        }
    }

}