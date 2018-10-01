using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages;
using Lab2Zoo.Models.Cages.WolfCages;

namespace Lab2Zoo.Models.Factories.CageFactories.WolfCageFactory
{
    public class GreyWolfCageFactory : CageFactory<GreyWolf>
    {
        public override Cage<GreyWolf> CreateCage()
        {
            return new GreyWolfCage();
        }
    }
}