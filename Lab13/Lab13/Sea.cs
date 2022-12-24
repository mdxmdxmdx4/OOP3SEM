using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab13
{
    [Serializable]
    [XmlRoot]
    public class Sea : Continent
    {
        public Water water;
        public override void PrintName()
        {
            Console.WriteLine("Название моря - " + Name);
        }
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Море {this.Name}, занимает = {this.PrecOfC}");
        }
        public Sea(string name, int prec, Water water)
        {
            Name = name;
            PrecOfC = prec;
            this.water = water; 
        }
      public Sea()
        {
            Name = "";
            PrecOfC = 0;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            Sea temp = obj as Sea;
            if (temp == null)
                return false;
            return  temp.Name == this.Name && temp.PrecOfC == this.PrecOfC;
        }
    }
}
