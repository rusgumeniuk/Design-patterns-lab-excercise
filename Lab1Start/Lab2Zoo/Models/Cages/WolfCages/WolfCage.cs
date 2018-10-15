using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.WolfCages
{
    public class WolfCage<T> : Cage<T>
        where T : Wolf
    {
        internal WolfCage() : base() { }

        public override bool IsContainerCanContainsAnimal(Animal animal)
        {
            return animal is Wolf;
        }
    }
}