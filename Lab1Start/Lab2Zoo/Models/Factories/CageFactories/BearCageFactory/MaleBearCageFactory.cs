using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages;

namespace Lab2Zoo.Models.Factories.CageFactories.BearCageFactory
{
    public class MaleBearCageFactory : CageFactory<MaleBearCageFactory>
    {
        public override MaleBearCageFactory CreateNewObject()
        {
            throw new NotImplementedException();
        }
    }
}