using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.WolfCages
{
    public class WhiteWolfCage : WolfCage<WhiteWolf>
    {
        public override void Add(IComponent component)
        {
            if(component is WhiteWolfCage || component is WhiteWolf)
            {
                Components.Add(component);
            }
        }
    }
}