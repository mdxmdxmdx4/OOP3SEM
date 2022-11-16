using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork5
{
    internal class WaterException : ArgumentException
    {
      public WaterException(string message) : base(message) { }
    }
}
