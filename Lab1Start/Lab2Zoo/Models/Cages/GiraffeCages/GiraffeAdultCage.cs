using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.GiraffeCages
{
    public class GiraffeAdultCage : GiraffeCage
    {
        internal GiraffeAdultCage() : base() { }

        public override bool IsContainerCanContainsAnimal(Animal animal)
        {
            return base.IsContainerCanContainsAnimal(animal) && (animal as Giraffe).Age > 14;
        }
    }
}