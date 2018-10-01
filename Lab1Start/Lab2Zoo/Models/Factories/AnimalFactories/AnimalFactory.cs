using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Factories.AnimalFactories
{
    public abstract class AnimalFactory<T> : BaseFactory<T>
        where T : Animal
    {
        public static Animal CreateRandomAnimal()
        {
            byte randomNumber = (byte)(new Random().Next(1, 10));
            bool wolfRandom = new Random().Next(0, 1) == 1;

            AnimalFactory<Animal> factory = null;

            if (randomNumber > 8)
            {
                factory = (AnimalFactory<Animal>)new GiraffeFactory();
            }
            else if (randomNumber < 5)
            {
                factory = (AnimalFactory<Bear>)new BearFactory();
            }
            else
            {
                if (wolfRandom)
                {
                    factory = (BaseFactory<Animal>)new GreyWolfFactory();
                }
                else
                {
                    factory = (BaseFactory<Wolf>)new WhiteWolfFactory();
                }
            }

            return factory.CreateNewObject();
        }
    }
}