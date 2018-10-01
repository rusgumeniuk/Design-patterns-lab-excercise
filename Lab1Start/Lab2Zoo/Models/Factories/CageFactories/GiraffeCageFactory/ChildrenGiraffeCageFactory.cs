using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages.GiraffeCages;

namespace Lab2Zoo.Models.Factories.CageFactories.GiraffeCageFactory
{
    public class ChildrenGiraffeCageFactory : CageFactory
    {
        public override BaseEntity CreateNewObject()
        {
            return new GiraffeChildrenCage();
        }
    }
}