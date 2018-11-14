using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab2Zoo.IOValidators;

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
        #region Start info
        static readonly BearCageFactory bearCageFactory = new BearCageFactory();
        static readonly FemaleBearCageFactory femaleBearCageFactory = new FemaleBearCageFactory();        
        
        static readonly BearFactory bearFactory = new BearFactory();
        #endregion

        static ZooConsole console;
        static Zoo zoo;                

        static void Main(string[] args)
        {
            {
                zoo = new Zoo();
                console = ZooConsole.GetInstance(zoo);

                BearCage bearCage = bearCageFactory.CreateCage() as BearCage;
                BearFemaleCage bearFemaleCage = femaleBearCageFactory.CreateCage() as BearFemaleCage;
                zoo.Add(bearCage);
                zoo.Add(bearFemaleCage);

                Bear femaleBear = bearFactory.CreateAnimal(Models.Enums.MaleMode.Female) as Bear;
                Bear maleBear = bearFactory.CreateAnimal(Models.Enums.MaleMode.Male) as Bear;
                femaleBear.Name = "Female bear";
                maleBear.Name = "Male bear";
                femaleBear.Weight = 40;
                maleBear.Weight = 130;

                Container contForFemale = zoo.GetContainerForAnimal(femaleBear);
                contForFemale.Add(femaleBear);

                Container contForMale = zoo.GetContainerForAnimal(maleBear);
                contForMale.Add(maleBear);
            }                      
            while (true)
            {
               console.DisplayMainMenu();
            }
        }       
    }
}