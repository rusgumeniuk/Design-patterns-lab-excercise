using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models.Animals
{
    public abstract class Wolf : Animal
    {
        public override string Voice()
        {
            return Id + ": ARH - WOOOOOOOO";
        }
    }
}