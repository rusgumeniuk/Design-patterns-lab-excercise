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
        public Container AddAnimal(Animal animal)
        {
            foreach (var component in Components)
            {
                if (component is Container && IsContainerCanContainsAnimal(component as Container, animal))
                {
                    return component as Container;
                }
            }
            return null;
        }
        public static bool IsContainerCanContainsAnimal(Container container, Animal animal)
        {
            container.Add(animal);
            return container.Components.Contains(animal);
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
        public override List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();
            foreach (var item in Components)
            {
                animals.AddRange(item.GetAnimals());
            }
            return animals;
        }
        public string GetStringAnimals()
        {
            List<Animal> animals = GetAnimals();
            if (animals.Count < 1) return "No one";
            string result = String.Empty;
            foreach (var item in animals)
            {
                result += item;
            }
            return result;
        }
    }
}