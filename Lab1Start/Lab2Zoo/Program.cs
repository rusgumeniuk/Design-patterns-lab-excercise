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
        /*
         TODO ChangeParentCage() to Component
         TODO GetParentContainer() to Component
         TODO IsInParentContainer() to Component
         TODO Create List<Zoo> Zoos to Zoo OR Singletone()
        */

        #region Start info
        static readonly BearCageFactory bearCageFactory = new BearCageFactory();
        static readonly FemaleBearCageFactory femaleBearCageFactory = new FemaleBearCageFactory();
        static readonly MaleBearCageFactory maleBearCageFactory = new MaleBearCageFactory();

        static readonly GiraffeCageFactory giraffeCageFactory = new GiraffeCageFactory();
        static readonly AdultGiraffeCageFactory adultGiraffeCageFactory = new AdultGiraffeCageFactory();
        static readonly ChildrenGiraffeCageFactory childrenGiraffeCageFactory = new ChildrenGiraffeCageFactory();

        static readonly WolfCageFactory wolfCageFactory = new WolfCageFactory();
        static readonly WhiteWolfCageFactory whiteWolfCageFactory = new WhiteWolfCageFactory();
        static readonly GreyWolfCageFactory greyWolfCageFactory = new GreyWolfCageFactory();

        static readonly BearFactory bearFactory = new BearFactory();
        static readonly GiraffeFactory giraffeFactory = new GiraffeFactory();
        static readonly WhiteWolfFactory whiteWolfFactory = new WhiteWolfFactory();
        static readonly GreyWolfFactory greyWolfFactory = new GreyWolfFactory();
        #endregion

        static ZooConsole console;
        static Zoo zoo;                

        static void Main(string[] args)
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
            
            while (true)
            {
               console.DisplayMainMenu();
            }

            //Bear firstBear = new BearFactory().CreateAnimal() as Bear;
            //Animal randomAnimal = AnimalFactory.CreateRandomAnimal();

            //firstBear.Name = "First bear";
            //randomAnimal.Name = "Random animal";

            //firstBear.Weight = 15;
            //randomAnimal.Weight = 33;

            //BearCage bearCage = (new BearCageFactory().CreateCage() as BearCage);
            //zoo.Add(bearCage);
            //bearCage.Add(firstBear);
            //bearCage.Add(randomAnimal);

            //Console.WriteLine(firstBear);
            //Console.WriteLine(randomAnimal);

            //Console.WriteLine(bearCage + ":");
            //Console.WriteLine(bearCage.Voice());

            //Console.WriteLine(zoo.GetAmountOfAnimals());
        }

       
    }
}

/*
 TODO
    Back to main menu
    Work with container
        create container
        select container
            clear container
            move container to container
            get all in cont
            get all weight
            get all voice

    Work with animal
        create animal
        create random container
        select animal (to move, edit info etc)
            move animal to container
            edit animal info


 */