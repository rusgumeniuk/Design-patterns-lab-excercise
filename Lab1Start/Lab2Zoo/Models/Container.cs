using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models
{
    public abstract class Container : Component
    {
        public List<Component> Components = new List<Component>();

        public override void Add(Component component)
        {
            Components.Add(component);
            component.container = this;
        }
        public override string Voice()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var component in Components)
            {
                stringBuilder.Append(component.Voice());
            }
            return stringBuilder.ToString();
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
        public override int GetWeight()
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