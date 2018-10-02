using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.WolfCages
{
    public class GreyWolfCage : WolfCage<GreyWolf>
    {
        public override void Add(Component component)
        {
            if (component is GreyWolfCage || component is GreyWolf)
            {
                Components.Add(component);
            }
        }
    }
}