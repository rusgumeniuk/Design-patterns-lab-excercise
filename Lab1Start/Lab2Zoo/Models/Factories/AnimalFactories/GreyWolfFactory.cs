using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Factories.AnimalFactories
{
    public class GreyWolfFactory : WolfFactory
    {
        public override BaseEntity CreateNewObject()
        {
            return new GreyWolf();
        }
    }
}