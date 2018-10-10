using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab2Zoo.Models;
using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages;
using Lab2Zoo.Models.Cages.BearCages;
using Lab2Zoo.Models.Cages.WolfCages;
using Lab2Zoo.Models.Cages.GiraffeCages;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;
using Lab2Zoo.Models.Factories.CageFactories.GiraffeCageFactory;
using Lab2Zoo.Models.Factories.CageFactories.WolfCageFactory;

namespace Lab2Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            Bear firstBear = new BearFactory().CreateAnimal() as Bear;
            Animal randomAnimal = AnimalFactory.CreateRandomAnimal();

            firstBear.Name = "First bear";
            randomAnimal.Name = "Random animal";

            firstBear.Weight = 15;
            randomAnimal.Weight = 33;

            BearCage bearCage = (new BearCageFactory().CreateCage() as BearCage);
            zoo.Add(bearCage);
            bearCage.Add(firstBear);
            bearCage.Add(randomAnimal);

            Console.WriteLine(firstBear);
            Console.WriteLine(randomAnimal);

            Console.WriteLine(bearCage + ":");
            Console.WriteLine(bearCage.Voice());

            Console.WriteLine(zoo.GetAmountOfAnimals());

            Console.ReadKey();
        }
    }
}