using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Lab13
{
    [Serializable]
    [DataContract(Name = "continent", Namespace = "Planet")]
    public class Continent
    {
        [DataMember(Name = "name", Order = 0)]
        public string Name;
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Континент {this.Name}, население = {this.Humanity}");
        }
        [NonSerialized]
        [DataMember(Name = "precentage", Order = 2)]
        public double PrecOfC;
        [DataMember(Name ="humanity", Order = 1)]
        public long Humanity;
        public Continent(string name, long humanity)
        {
            PrecOfC = 100;
            Name = name;
            Humanity = humanity;
        }
        public Continent() { }
        public virtual void PrintName()
        {
            Console.WriteLine("Название объекта - " + Name);
        }

    }

}
