using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.WolfCages
{
    public class WolfCage<T> : Cage<T>
        where T : Wolf
    {
        internal WolfCage() : base() { }

        public override void Add(Component component)
        {
            if (component is WolfCage<T> || (component is Wolf)) 
            {
                Components.Add(component);
            }
            else
                ThrowWrongComponentException(component);
        }
    }
}