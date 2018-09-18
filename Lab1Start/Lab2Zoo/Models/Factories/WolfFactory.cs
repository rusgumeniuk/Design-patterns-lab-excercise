using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Zoo.Models.Factories
{
    class WolfFactory : Factory
    {
        public override Animal CreateAnimal()
        {
            return new Lab2Zoo.Models.Animals.Wolf();
        }
    }
}
