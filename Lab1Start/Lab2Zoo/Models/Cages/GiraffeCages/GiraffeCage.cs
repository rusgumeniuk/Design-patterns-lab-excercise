﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages.GiraffeCages
{
    public class GiraffeCage : Cage<Giraffe>
    {
        internal GiraffeCage() : base() { }

        public override bool IsContainerCanContainsAnimal(Animal animal)
        {
            return animal is Giraffe;
        }
    }
}