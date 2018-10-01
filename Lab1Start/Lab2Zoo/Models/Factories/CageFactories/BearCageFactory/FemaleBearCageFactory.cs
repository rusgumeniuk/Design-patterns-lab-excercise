using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages;

namespace Lab2Zoo.Models.Factories.CageFactories.BearCageFactory
{
    public class FemaleBearCageFactory : CageFactory<FemaleBearCageFactory>
    {
        public override FemaleBearCageFactory CreateNewObject()
        {
            throw new NotImplementedException();
        }
    }
}