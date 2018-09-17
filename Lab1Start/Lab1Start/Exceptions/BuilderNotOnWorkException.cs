using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Start.Exceptions
{
    class BuilderNotOnWorkException : InvalidOperationException
    {
        public BuilderNotOnWorkException() : base() { }
        public BuilderNotOnWorkException(string mes) : base(mes) { }
    }
}
