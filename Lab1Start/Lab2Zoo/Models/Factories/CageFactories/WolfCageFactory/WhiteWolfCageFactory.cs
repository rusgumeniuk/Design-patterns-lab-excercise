using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages.WolfCages;
namespace Lab2Zoo.Models.Factories.CageFactories.WolfCageFactory
{
    public class WhiteWolfCageFactory : CageFactory
    {
        public override BaseEntity CreateNewObject()
        {
            return new WhiteWolfCage();
        }
    }
}