using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.WolfCages
{
    public class GreyWolfCage : WolfCage<GreyWolf>
    {
        internal GreyWolfCage() : base() { }

        public override bool IsContainerCanContainsAnimal(Animal animal)
        {
            return animal is GreyWolf;
        }

        public override bool IsContainerCanContainsContainer(Container innerContainer)
        {
            return innerContainer is GreyWolfCage;
        }
    }
}