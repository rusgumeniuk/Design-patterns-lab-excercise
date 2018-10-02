using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models.Animals
{
    public abstract class Animal : Component
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
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("'" + value + "' can not be name");
                else
                    name = value;
            }
        }  

        public string WakeUp()
        {
            IsSleeping = false;
            return this + " is woke up!";
        }
        
        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }
        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }
        public override Component GetChild(int index)
        {
            throw new InvalidOperationException();
        }
        public override int GetWeight()
        {
            return Weight;
        }

        public override string ToString()
        {
            return this.GetType().Name + " '" + Name + "'";
        }
    }
}