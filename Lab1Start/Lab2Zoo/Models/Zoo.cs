using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages;

namespace Lab2Zoo.Models
{
    public enum DayMode : byte
    {
        Day,
        Night
    }

    class Zoo : Base
    {
        public List<Cage<Animal>> Cages { get; set; } = new List<Cage<Animal>>();
        public DayMode CurrentMode { get; set; } = DayMode.Day;

        public Animal GetRandomAnimal()
        {
            return Factories.Factory.CreateRandomAnimal();
        }

        public string GetVoicesOfAllZoo()
        {
            if (Cages.Count < 1) return "We can hear noone because the zoo has not any animal";
            StringBuilder stringBuilder = new StringBuilder();
            if(CurrentMode == DayMode.Night)
            {
                foreach (var cage in Cages)
                {
                    foreach (var animal in cage.Animals)
                    {
                        if (animal.IsSleeping)
                            animal.WakeUp();
                        stringBuilder.Append(animal.Voice());
                    }                   
                }
            }
            else
            {
                foreach (var item in Cages)
                {
                    foreach (var animal in item.Animals)
                    {
                        stringBuilder.Append(animal.Voice());
                    }                    
                }
            }
            return stringBuilder.ToString();
        }
    }
}
