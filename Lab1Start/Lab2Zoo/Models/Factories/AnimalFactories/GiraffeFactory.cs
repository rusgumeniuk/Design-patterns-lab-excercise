using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Factories.AnimalFactories
{
    public class GiraffeFactory : AnimalFactory
    {
        public override Animal CreateAnimal()
        {
            return new Giraffe();
        }
        public Animal CreateAnimal(byte age)
        {
            return new Giraffe(age);
        }
    }
}