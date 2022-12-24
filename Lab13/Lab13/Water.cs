﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab13
{
    [Serializable]
   public class Water
    {
        [XmlAttribute]
        public int square;
        public string typeOFWater;
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Тип воды объекта - {this.typeOFWater}, занимает {this.square} м^2");
        }
        public Water()
        {
            square = 999;
            typeOFWater = "notDefined";
        }
        public Water(int sq, string typeOW)
        {

            square = sq;
            typeOFWater = typeOW;

        }
    }
}
