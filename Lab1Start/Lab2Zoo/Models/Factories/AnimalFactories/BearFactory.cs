using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Enums;

namespace Lab2Zoo.Models.Factories.AnimalFactories
{
    public class BearFactory : AnimalFactory
    {
        public override Animal CreateAnimal()
        {
            return new Bear();
        }
        public Animal CreateAnimal(MaleMode male)
        {
            return new Bear(male);
        }
    }
}