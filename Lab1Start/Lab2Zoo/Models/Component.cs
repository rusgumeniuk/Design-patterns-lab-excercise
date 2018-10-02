﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models
{
    public abstract class Component : IComponent, IHandle
    {
        public readonly Guid Id;

        private Component nextComponent;

        public Component()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);
        public abstract int GetWeight();
        public abstract string Voice();

        public void SetNext(Component component)
        {
            this.nextComponent = component;
        }
        public virtual object Handle(object component)
        {
            if (this.nextComponent != null)
                return this.nextComponent.Handle(component);
            else
                return null;
        }
    }
}