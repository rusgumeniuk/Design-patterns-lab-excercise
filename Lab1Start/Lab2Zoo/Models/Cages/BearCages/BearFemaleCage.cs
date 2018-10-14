using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.BearCages
{
    public class BearFemaleCage : BearCage
    {
        internal BearFemaleCage() : base() { }

        public override void Add(Component component)
        {
            if (component is BearFemaleCage || (component is Bear && (component as Bear).Male == Enums.MaleMode.Female)) 
            {
                Components.Add(component);
            }
        }
        public override bool IsContainerCanContainsAnimal(Animal animal)
        {
            return base.IsContainerCanContainsAnimal(animal) && (animal as Bear).Male == Enums.MaleMode.Female;
        }
    }
}