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
        /*
         TODO GetAllContainers() to Cont         
         TODO GetAllComponents() to Component
         TODO ChangeParentCage() to Component
         TODO GetParentContainer() to Component
         TODO IsInParentContainer() to Component
         TODO Create List<Zoo> Zoos to Zoo
         TODO CreateZoo() 
        */

        #region Start info
        readonly BearCageFactory bearCageFactory;
        readonly FemaleBearCageFactory femaleBearCageFactory;
        readonly MaleBearCageFactory maleBearCageFactory;

        readonly GiraffeCageFactory giraffeCageFactory;
        readonly AdultGiraffeCageFactory adultGiraffeCageFactory;
        readonly ChildrenGiraffeCageFactory childrenGiraffeCageFactory;

        readonly WolfCageFactory wolfCageFactory;
        readonly WhiteWolfCageFactory whiteWolfCageFactory;
        readonly GreyWolfCageFactory greyWolfCageFactory;

        readonly BearFactory bearFactory;
        readonly GiraffeFactory giraffeFactory;
        readonly WhiteWolfFactory whiteWolfFactory;
        readonly GreyWolfFactory greyWolfFactory;

        public Program()
        {
            bearCageFactory = new BearCageFactory();
            femaleBearCageFactory = new FemaleBearCageFactory();
            maleBearCageFactory = new MaleBearCageFactory();

            giraffeCageFactory = new GiraffeCageFactory();
            adultGiraffeCageFactory = new AdultGiraffeCageFactory();
            childrenGiraffeCageFactory = new ChildrenGiraffeCageFactory();


            wolfCageFactory = new WolfCageFactory();
            whiteWolfCageFactory = new WhiteWolfCageFactory();
            greyWolfCageFactory = new GreyWolfCageFactory();

            bearFactory = new BearFactory();
            giraffeFactory = new GiraffeFactory();
            whiteWolfFactory = new WhiteWolfFactory();
            greyWolfFactory = new GreyWolfFactory();
        }
        #endregion

        static Zoo zoo;

        static void Main(string[] args)
        {
            zoo = new Zoo();

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

        private static void DisplayMainSwitcher()
        {
            while (true)
            {
                string info =
                               "Please input number of appropriate operation:" + "\n"
                               + "0 : Show all components" + "\n"
                               + "1 : Show all containers" + "\n"
                               + "2 : Show all animals" + "\n"
                               + "3 :"
                               ;
                Console.WriteLine(info);
                if (byte.TryParse(Console.ReadLine(), out byte selectedNumber) || selectedNumber > 3)
                {
                    switch (selectedNumber)
                    {
                        case 0:
                            {
                                ShowAllComponents(null);
                                break;
                            }
                        case 1:
                            {
                                ShowInnerContainers(null);
                                break;
                            }
                            case 2:
                            {
                                ShowInnerAnimals(null);
                                break;
                            }
                            case 3:
                            {
                                Console.WriteLine("not complete");
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong selected number. Try Again!");
                    continue;
                }
            }
        }

        private static void ShowAllComponents(Container container)
        {
            if(container == null)
            {
                container = zoo;
            }


        }

        private static void ShowInnerContainers(Container container)
        {
            if (container == null)
            {
                container = zoo;
            }

        }

        private static void ShowInnerAnimals(Container container)
        {
            if (container == null)
            {
                container = zoo;
            }
        }
    }
}