using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Zoo.Models.Factories
{
    abstract class Factory : Base
    {
        public abstract Animal CreateAnimal();
        public static Animal CreateRandomAnimal()
        {
            byte randomNumber = (byte)(new Random().Next(1, 10));
            Factory factory = randomNumber > 8 ? new GiraffeFactory() : (randomNumber < 5 ? (Factory)new WolfFactory() : new BearFactory());    
            return factory.CreateAnimal();
        }
    }
}
