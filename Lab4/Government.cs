using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork4true
{
    class Government : Ground
    {
        public Water water;
        public override bool TToCompare(object obj)
        {
            return true;
        }
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Государство {this.Name}, население = {this.Humanity}, валюта - {this.Vallet}, глава гос-ва - {this.HeadOfG}");
        }
        public Government(string name, string head, string vallet, int humanity) :base()
        {
            water = new Water();
            Name = name;
            HeadOfG = head;
            Vallet = vallet;
            Humanity = humanity;
            this.water = water;
        }

        public Government(int asd) : base()
        {
        }
        public string HeadOfG;
        public string Vallet;
        public override void Info()
        {
            Console.WriteLine("Cтрана - " + Name);
        }
        public Government() { }
        public override void PrintName()
        {
            base.PrintName();
        }

    }
}
