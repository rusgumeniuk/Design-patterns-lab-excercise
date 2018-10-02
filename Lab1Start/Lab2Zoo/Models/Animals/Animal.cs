using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models.Animals
{
    public abstract class Animal : BaseEntity, IComponent
    {
        private string name = "Unknown";
        private ushort weight = 0;
        public bool IsSleeping = false;

        public ushort Weight
        {
            get => weight;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Weight should be non-negative");
                weight = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("'" + value + "' can not be name");
                else
                    name = value;
            }
        }  

        public void WakeUp()
        {
            IsSleeping = false;
        }

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
        public int GetWeight()
        {
            return Weight;
        }
    }
}