﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages
{
    public class Cage<T> : BaseEntity, IComponent
        where T : Animal
    {
        public List<IComponent> Components = new List<IComponent>();

        public string Voice()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var component in Components)
            {
                stringBuilder.Append(component.Voice());
            }
            return stringBuilder.ToString();
        }

        public virtual void Add(IComponent component)
        {
            Components.Add(component);
        }
        public virtual void Remove(IComponent component)
        {
            Components.Remove(component);
        }

        public virtual IComponent GetChild(int index)
        {
            if (index < 0 || index >= Components.Count)throw new IndexOutOfRangeException("'" + index + "' is wrong index");
            return Components[index];
        }
        public virtual int GetWeight()
        {
            int weight = 0;
            foreach (var component in Components)
            {
                weight += component.GetWeight();
            }
            return weight;
        }
    }
}