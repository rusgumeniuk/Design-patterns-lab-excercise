using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.GiraffeCages
{
    public class GiraffeCage : Cage<Giraffe>
    {
        public override void Add(IComponent component)
        {
            if(component is GiraffeCage || (component is Giraffe))
            {
                Components.Add(component);
            }
        }
    }
}