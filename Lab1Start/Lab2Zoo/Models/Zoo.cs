using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Enums;
using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models
{
    public class Zoo : BaseEntity, IComponent
    {
        public DayMode CurrentDayMode = DayMode.Day;
        public List<IComponent> Components = new List<IComponent>();       

        public Animal GetRandomAnimal()
        {
            return Factories.AnimalFactories.AnimalFactory.CreateRandomAnimal();
        }
                
        public string Voice()
        {
            if (Components.Count < 1) return "No one in zoo";
            StringBuilder stringBuilder = new StringBuilder();

            if(CurrentDayMode == DayMode.Day)
            {
                foreach (var component in Components)
                {
                    stringBuilder.Append(component.Voice());
                }                
            }
            else
            {
                foreach (var item in Components)
                {
                    if (item is Animal)
                    {
                        if((item as Animal).IsSleeping)
                        {
                            (item as Animal).WakeUp();                            
                        }
                        stringBuilder.Append((item as Animal).Voice());
                    }
                    else stringBuilder.Append(item.Voice());
                }
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