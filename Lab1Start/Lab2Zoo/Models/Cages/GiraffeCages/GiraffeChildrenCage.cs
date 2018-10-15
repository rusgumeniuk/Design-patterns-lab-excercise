using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.GiraffeCages
{
    public class GiraffeChildrenCage : GiraffeCage
    {
        internal GiraffeChildrenCage() : base() { }

        public override bool IsContainerCanContainsAnimal(Animal animal)
        {
            return base.IsContainerCanContainsAnimal(animal) && (animal as Giraffe).Age <= 14;
        }
    }
}