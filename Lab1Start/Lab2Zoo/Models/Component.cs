using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models
{
    public abstract class Component
    {
        public readonly Guid Id;

        internal Component()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);
        public abstract int GetWeight();
        public abstract int GetAmountOfAnimals();
        public abstract List<Animal> GetAnimals();
        public abstract string Voice();

        public override string ToString()
        {
            return GetType().Name + " " + Id;
        }
    }
}