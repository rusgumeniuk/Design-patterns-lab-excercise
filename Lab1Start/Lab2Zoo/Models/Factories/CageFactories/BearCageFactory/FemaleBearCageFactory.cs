using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages.BearCages;
using Lab2Zoo.Models.Cages;

namespace Lab2Zoo.Models.Factories.CageFactories.BearCageFactory
{
    public class FemaleBearCageFactory : CageFactory<Bear>
    {
        public override Cage<Bear> CreateCage()
        {
            return new BearFemaleCage();
        }
    }
}