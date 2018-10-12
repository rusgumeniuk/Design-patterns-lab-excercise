using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.GiraffeCages
{
    public class GiraffeAdultCage : GiraffeCage
    {
        internal GiraffeAdultCage() : base() { }

        public override void Add(Component component)
        {
            if (component is GiraffeAdultCage || (component is Giraffe && (component as Giraffe).Age > 14)) 
            {
                Components.Add(component);
            }
            else
                ThrowWrongComponentException(component, "It should be older");
        }
    }
}