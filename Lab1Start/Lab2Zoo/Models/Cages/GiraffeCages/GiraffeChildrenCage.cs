﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.GiraffeCages
{
    public class GiraffeChildrenCage : GiraffeCage
    {
        public override void Add(Component component)
        {
            if(component is GiraffeChildrenCage || (component is Giraffe && (component as Giraffe).Age <= 14))
            {
                Components.Add(component);
            }
        }
    }
}