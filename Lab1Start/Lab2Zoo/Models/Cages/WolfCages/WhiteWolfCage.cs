using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.WolfCages
{
    public class WhiteWolfCage : WolfCage<WhiteWolf>
    {
        internal WhiteWolfCage() : base() { }
        public override void Add(Component component)
        {
            if(component is WhiteWolfCage || component is WhiteWolf)
            {
                Components.Add(component);
            }
        }
    }
}