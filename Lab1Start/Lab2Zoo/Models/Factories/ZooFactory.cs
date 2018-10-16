using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Zoo.Models.Factories
{
    public class ZooFactory
    {
        public static Zoo CreateZoo()
        {
            return new Zoo();
        }        
    }
}
