using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models
{
    public class Zoo : BaseEntity, IComponent
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

        public void Add(IComponent component)
        {
            Components.Add(component);
        }
        public void Remove(IComponent component)
        {
            Components.Remove(component);
        }

        public IComponent GetChild(int index)
        {
            return Components[index];
        }
    }
}