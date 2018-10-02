using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.BearCages
{
    public class BearMaleCage : BearCage
    {
        public override void Add(IComponent component)
        {
         if(component is BearMaleCage || (component is Bear && (component as Bear).Male == Enums.MaleMode.Male))
            {
                Components.Add(component);
            }
                
        }
    }
}