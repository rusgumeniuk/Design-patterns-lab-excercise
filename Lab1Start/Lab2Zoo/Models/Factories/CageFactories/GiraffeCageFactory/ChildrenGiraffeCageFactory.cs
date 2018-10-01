using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages.GiraffeCages;
using Lab2Zoo.Models.Cages;

namespace Lab2Zoo.Models.Factories.CageFactories.GiraffeCageFactory
{
    public class ChildrenGiraffeCageFactory : CageFactory<Giraffe>
    {
        public override Cage<Giraffe> CreateCage()
        {
            return new GiraffeChildrenCage();
        }
    }
}