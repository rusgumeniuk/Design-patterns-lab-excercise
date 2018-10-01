using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages;

namespace Lab2Zoo.Models.Factories.CageFactories.WolfCageFactory
{
    public class WhiteWolfCageFactory : CageFactory<WhiteWolfCageFactory>
    {
        public override WhiteWolfCageFactory CreateNewObject()
        {
            return new WhiteWolfCageFactory();
        }
    }
}