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

        static Zoo zoo;

        static void Main(string[] args)
        {
            zoo = new Zoo();
            BearCage bearCage = bearCageFactory.CreateCage() as BearCage;
            BearFemaleCage bearFemaleCage = femaleBearCageFactory.CreateCage() as BearFemaleCage;
            zoo.Add(bearCage);
            zoo.Add(bearFemaleCage);

            Bear femaleBear = bearFactory.CreateAnimal(Models.Enums.MaleMode.Female) as Bear;
            Bear maleBear = bearFactory.CreateAnimal(Models.Enums.MaleMode.Male) as Bear;
            femaleBear.Name = "Female bear";
            maleBear.Name = "Male bear";

            Container contForFemale = zoo.GetContainerForAnimal(femaleBear);
            contForFemale.Add(femaleBear);

            Container contForMale = zoo.GetContainerForAnimal(maleBear);
            contForMale.Add(maleBear);
            
            while (true)
            {
                DisplayMainSwitcher();
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
            if (container == null)
            {
                container = zoo;
            }
            StringBuilder stringBuilder = new StringBuilder();
            container.GetComponents()?.ToList().ForEach(component => stringBuilder.AppendLine(component.ToString()));
            Console.WriteLine(stringBuilder.Length > 0 ? stringBuilder.ToString() : "No one component in " + container);
        }

        private static void ShowInnerContainers(Container container)
        {
            if (container == null)
            {
                container = zoo;
            }
            StringBuilder stringBuilder = new StringBuilder();
            container.GetContainers()?.ToList().ForEach(cont => stringBuilder.AppendLine(cont.ToString()));
            Console.WriteLine(stringBuilder.Length > 0 ? stringBuilder.ToString() : "No one conteiner in " + container);
        }

        private static void ShowInnerAnimals(Container container)
        {
            if (container == null)
            {
                container = zoo;
            }
            StringBuilder stringBuilder = new StringBuilder();
            container.GetAnimals()?.ToList().ForEach(cont => stringBuilder.AppendLine(cont.ToString()));
            Console.WriteLine(stringBuilder.Length > 0 ? stringBuilder.ToString() : "No one animal in " + container);
        }
    }
}