using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLib.Exceptions
{
    public class FactoryCreateException : Exception
    {
        public FactoryCreateException(string msg) : base(msg)
        {

        }
    }
}
