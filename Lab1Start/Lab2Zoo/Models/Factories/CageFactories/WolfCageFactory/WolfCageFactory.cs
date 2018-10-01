using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages.WolfCages;
using Lab2Zoo.Models.Cages;

namespace Lab2Zoo.Models.Factories.CageFactories.WolfCageFactory
{
    public class WolfCageFactory : CageFactory<Wolf>
    {
        public override Cage<Wolf> CreateCage()
        {
            return new WolfCage<Wolf>();
        }
    }
}