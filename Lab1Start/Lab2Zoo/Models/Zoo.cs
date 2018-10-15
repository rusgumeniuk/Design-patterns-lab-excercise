using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Enums;
using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models
{
    public class Zoo : Container
    {
        public DayMode CurrentDayMode = DayMode.Day;

        public Animal GetRandomAnimal()
        {
            return Factories.AnimalFactories.AnimalFactory.CreateRandomAnimal();
        }                

        public void ChangeDayMode(DayMode mode)
        {
            CurrentDayMode = mode;
        }
        public void ChangeDayMode()
        {
            if (CurrentDayMode == DayMode.Day)
                CurrentDayMode = DayMode.Night;
            else
                CurrentDayMode = DayMode.Day;
        }

        private void LetSleepSomeAnimal()
        {
            Random random = new Random();
            foreach (var animal in GetAnimals())
            {
                animal.IsSleeping = random.Next(0, 10) > 2;
            }
        }        

        private void WakeZooUp()
        {
            foreach (var animal in GetAnimals())
            {
                animal.IsSleeping = false;
            }
        }

        public override bool IsContainerCanContainsContainer(Container innerContainer)
        {
            return innerContainer is Cages.Cage<Animal>;
        }

        public override string Voice()
        {
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
                    if (item is Animal && (item as Animal).IsSleeping)
                        stringBuilder.Append((item as Animal).WakeUp() + " : ");
                    stringBuilder.Append(item.Voice());
                }
            }

            return stringBuilder.Length > 0 ? stringBuilder.ToString() : "No one in zoo";
        }
    }
}