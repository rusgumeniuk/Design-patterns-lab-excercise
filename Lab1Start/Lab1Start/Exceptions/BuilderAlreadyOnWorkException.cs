using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Start.Exceptions
{
    class BuilderAlreadyOnWorkException : InvalidOperationException 
    {
        public BuilderAlreadyOnWorkException() : base() { }
        public BuilderAlreadyOnWorkException(string mes) : base(mes) { }
    }
}
