using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models
{
    public enum DayMode : byte
    {
        Day,
        Night
    }

    class Zoo : Base
    {
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public DayMode CurrentMode { get; set; } = DayMode.Day;

        public string CreateRandomAnimal()
        {
            int randomNumber = (new Random().Next(1, 10));
            Animal animal = randomNumber > 8 ? new Giraffe() : (randomNumber < 5 ? (Animal)new Wolf() : (Animal)new Bear());            

            Animals.Add(animal);
            return animal.GetType() + " was added";
        }
        public string GetVoicesOfAllZoo()
        {
            if (Animals.Count < 1) return "We can hear noone because the zoo has not any animal";
            StringBuilder stringBuilder = new StringBuilder();
            if(CurrentMode == DayMode.Night)
            {
                foreach (var item in Animals)
                {
                    if(item.IsSleeping)
                        item.WakeUp();
                    stringBuilder.Append(item.Voice());
                }
            }
            else
            {
                foreach (var item in Animals)
                {
                    stringBuilder.Append(item.Voice());
                }
            }
            return stringBuilder.ToString();
        }

    }
}
