using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Factories.AnimalFactories
{
    public abstract class AnimalFactory : BaseFactory       
    {
        public static BaseEntity CreateRandomAnimal()
        {
            byte randomNumber = (byte)(new Random().Next(1, 10));
            bool wolfRandom = new Random().Next(0, 1) == 1;

            AnimalFactory factory = null;

            if (randomNumber > 8)
            {
                factory = (AnimalFactory)new GiraffeFactory();
            }
            else if (randomNumber < 5)
            {
                factory = new BearFactory();
            }
            else
            {
                if (wolfRandom)
                {
                    factory = new GreyWolfFactory();
                }
                else
                {
                    factory = new WhiteWolfFactory();
                }
            }

            return factory.CreateNewObject();
        }
    }
}