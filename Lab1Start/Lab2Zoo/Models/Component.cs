using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models
{
    public abstract class Component
    {
        public readonly Guid Id;

        internal Component()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract int GetWeight();
        public abstract int GetAmountOfAnimals();
        public abstract List<Animal> GetAnimals();
        public abstract string Voice();

        public override string ToString()
        {
            return GetType().Name + " " + Id;
        }
    }

    public static class AdditionalTypeClass
    {
        public static Type[] GetBaseTypes(this Type type)
        {
            return type.BaseType == null ? null : GetBaseTypes(type, new List<Type>() { type }).ToArray();
        }

        private static List<Type> GetBaseTypes(this Type currentType, List<Type> types)
        {
            if (currentType.BaseType == null) return types;

            types.Add(currentType.BaseType);
            return GetBaseTypes(currentType.BaseType, types);
        }
    }
}