using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models
{
    public abstract class Container : Component
    {
        public List<Component> Components = new List<Component>();       
      
        public override void Add(Component component)
        {
            Components.Add(component);            
        }       
        public override void Remove(Component component)
        {
            Components.Remove(component);
        }

        public override Component GetChild(int index)
        {
            if (index < 0 || index >= Components.Count) throw new IndexOutOfRangeException("'" + index + "' is wrong index");
            return Components[index];
        }

        public float GetAverageWeight()
        {
            try
            {
                return GetWeight() / GetAmountOfAnimals();
            }
            catch (DivideByZeroException)
            {
                return -1;
            }
        }
        public override int GetWeight()
        {
            int weight = 0;
            foreach (var component in Components)
            {
                weight += component.GetWeight();
            }
            return weight;
        }
        public override int GetAmountOfAnimals()
        {
            int count = 0;
            foreach (var item in Components)
            {
                count += item.GetAmountOfAnimals();
            }
            return count;
        }
    }
}