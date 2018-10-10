﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models
{
    public abstract class Component
    {
        public readonly Guid Id;

        public Component()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);
        public abstract int GetWeight();
        public abstract int GetAmountOfAnimals();
        public abstract string Voice();

        public override string ToString()
        {
            return GetType().Name + " " + Id;
        }
    }
}