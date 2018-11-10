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
            if (component is Animal)
                return IsContainerCanContainsAnimal(component as Animal);
            if (component is Container)
                return !IsContainerIsParentContainer(component as Container) && IsContainerCanContainsContainer(component as Container);
            return false;
        }
        public bool IsContainerAlreadyContainsComponent(Component component)
        {
            return GetContainerWithComponent(component) != null;
        }
       
        public Container GetContainerWithComponent(Component component)
        {
            if (Components.Contains(component)) return this;
            foreach (var item in Components)
            {
                if ((item is Container) && (item as Container).IsContainerAlreadyContainsComponent(component))
                    return item as Container;
            }
            return null;
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

        public Animal GetAnimalFromContainerByName(string animalName)
        {
            foreach (var component in Components)
            {
                if ((component is Animal) && (component as Animal).Name.Equals(animalName))
                {
                    return component as Animal;
                }
            }
            return null;
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

        public override Component[] GetComponents()
        {
            List<Component> components = new List<Component>();
            foreach (var item in Components)
            {
                components.Add(item);
                components.AddRange(item.GetComponents());
            }
            return components.ToArray();
        }
        public Container[] GetContainers()
        {            
            List<Container> containers = new List<Container>();
            foreach (var item in Components)
            {
                if(item is Container)
                {
                    containers.Add(item as Container);
                    containers.AddRange((item as Container).GetContainers());
                }
            }
            return containers.ToArray();
        }
        public override Animal[] GetAnimals()
        {
            List<Animal> animals = new List<Animal>();
            foreach (var item in Components)
            {
                animals.AddRange(item.GetAnimals());
            }
            return animals.ToArray();
        }
        public string GetAnimalsString()
        {
            Animal[] animals = GetAnimals();
            if (animals.Length < 1) return "No one";
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