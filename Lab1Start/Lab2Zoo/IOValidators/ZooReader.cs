using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Zoo.Models;
using Lab2Zoo.Models.Animals;

using IOValidation.ConsoleImp;

namespace Lab2Zoo.IOValidators
{
    internal class ZooReader : ConsoleReader
    {
        private static ZooReader reader;
        private static readonly object lockObj = new object();

        private ZooReader() { }
        public static ZooReader GetInstance()
        {
            lock (lockObj)
            {
                if (reader == null)
                {
                    reader = new ZooReader();
                }
                return reader;
            }            
        }
        
        public Animal GetAnimal(Container container)
        {
            Animal animal;
            while (true)
            {
                Console.WriteLine("Enter animal name from " + container + ":");
                string animalName = GetNotEmptyString();
                animal = container.GetAnimalFromContainerByName(animalName);
                if (animal == null)
                {
                    Console.WriteLine("Wrong animal name or container");
                    continue;
                }
                return animal;
            }
        }
    }
}
