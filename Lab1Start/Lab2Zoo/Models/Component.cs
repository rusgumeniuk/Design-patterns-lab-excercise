using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models
{
    public abstract class Component : IComponent
    {
        public readonly Guid Id;

        internal Container container;

        public Component()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);
        public abstract int GetWeight();
        public abstract string Voice();
    }
}