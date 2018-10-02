using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Factories.AnimalFactories
{
    public abstract class AnimalFactory       
    {
        public static Animal CreateRandomAnimal()
        {
            byte randomNumber = (byte)(new Random().Next(1, 10));
            bool wolfRandom = new Random().Next(0, 1) == 1;

            AnimalFactory factory = randomNumber > 8 ? new GiraffeFactory() : (randomNumber < 5 ? new BearFactory() : (wolfRandom ? (AnimalFactory)new WhiteWolfFactory() : new GreyWolfFactory()));

            return factory.CreateAnimal();
        }

        public abstract Animal CreateAnimal();
    }
}