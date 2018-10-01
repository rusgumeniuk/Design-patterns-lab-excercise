using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Factories.AnimalFactories
{
    public class GiraffeFactory : AnimalFactory
    {
        public override BaseEntity CreateNewObject()
        {
            return new Giraffe();
        }
    }
}