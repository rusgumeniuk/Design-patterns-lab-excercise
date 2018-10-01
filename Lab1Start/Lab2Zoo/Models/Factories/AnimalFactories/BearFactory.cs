using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Factories.AnimalFactories
{
    public class BearFactory : AnimalFactory<Bear>
    {
        public override Bear CreateNewObject()
        {
            return new Bear();
        }
    }
}