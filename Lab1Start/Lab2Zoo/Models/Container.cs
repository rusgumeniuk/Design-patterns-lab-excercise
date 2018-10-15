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
            if (IsContainerCanContainsComponent(component))
                Components.Add(component);
            else
                ThrowWrongComponentException(component);
        }       

        public Container GetContainerForAnimal(Animal animal)
        {
            Container childContainer = GetChildContainerForAnimal(animal);
            if (childContainer != null)
                return childContainer.GetContainerForAnimal(animal);
            else if (IsContainerCanContainsAnimal(animal))
                return this;
            else
                return null;
        }


        public virtual bool IsContainerCanContainsComponent(Component component)
        {
            if (IsContainerAlreadyContainsComponent(component))
                throw new ArgumentException(component + " is already is some container");
            if (component is Animal)
                return IsContainerCanContainsAnimal(component as Animal);
            if (component is Container)
                return !IsContainerIsParentContainer(component as Container) && IsContainerCanContainsContainer(component as Container);
            return false;
        }
        public bool IsContainerAlreadyContainsComponent(Component component)
        {
            if (Components.Contains(component)) return true;
            foreach (var item in Components)
            {
                if ((item is Container) && (item as Container).IsContainerAlreadyContainsComponent(component))
                    return true;
            }
            return false;
        }

        public abstract bool IsContainerCanContainsContainer(Container innerContainer);
        public bool IsContainerIsParentContainer(Container container)
        {
            if (container.Components.Contains(this)) return true;
            foreach (var component in container.Components)
            {
                if (component is Container)
                {
                    if ((component as Container).IsContainerIsParentContainer(this))
                        return true;
                }
            }
            return false;
        }

        public virtual bool IsContainerCanContainsAnimal(Animal animal)
        {
            return animal is Animal;
        }        
        

        public virtual bool IsChildCanContainsAnimal(Animal animal)
        {
            return GetChildContainerForAnimal(animal) != null;
        }
        protected virtual Container GetChildContainerForAnimal(Animal animal)
        {
            foreach (var child in Components)
            {
                if (child is Container && (child as Container).IsContainerCanContainsComponent(animal))
                    return child as Container;
            }
            return null;
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
        public string GetAnimalsString()
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

        protected void ThrowWrongComponentException(Component component)
        {
            throw new TypeAccessException("Object with type '" + component.GetType().Name + "' can not be placed to " + GetType().Name);
        }
        protected void ThrowWrongComponentException(Component component, string message)
        {
            throw new TypeAccessException("Object with type '" + component.GetType().Name + "' can not be placed to " + GetType().Name + "\n" + message);
        }

        public override void Remove(Component component)
        {
            Components.Remove(component);
        }
    }
}