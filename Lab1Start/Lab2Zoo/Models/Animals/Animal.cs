using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models.Animals
{
    public abstract class Animal : BaseEntity, IComponent
    {
        public abstract string Voice();
        public void Add(IComponent component)
        {
            throw new InvalidOperationException();
        }
        public void Remove(IComponent component)
        {
            throw new InvalidOperationException();
        }
        public IComponent GetChild(int index)
        {
            throw new InvalidOperationException();
        }
    }
}