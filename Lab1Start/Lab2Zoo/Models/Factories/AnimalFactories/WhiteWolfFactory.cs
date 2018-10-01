using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Factories.AnimalFactories
{
    public class WhiteWolfFactory : AnimalFactory
    {
        public override Animal CreateAnimal()
        {
            return new WhiteWolf();
        }
    }
}