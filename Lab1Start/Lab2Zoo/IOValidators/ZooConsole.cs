using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IOValidation.Interfaces;

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
using Lab2Zoo.Models.Enums;

namespace Lab2Zoo.IOValidators
{
    internal class ZooConsole : IConsole
    {
        #region Props and ctor
        private ZooReader reader;        

        private List<Component> helpedList;
        private static Zoo currentZoo;

        #region Singletone
        private static ZooConsole console;
        private static readonly object lockObj = new object();

        private ZooConsole()
        {
            reader = ZooReader.GetInstance();
            helpedList = new List<Component>();
        }
        public static ZooConsole GetInstance(Zoo zoo)
        {            
            lock (lockObj)
            {
                if (console == null)
                {
                    console = new ZooConsole();
                }
                currentZoo = zoo;
                return console;
            }
        }
        #endregion
        #endregion

        #region Main Menu and base methods        
        public void DisplayMainMenu()
        {
            string title = "Please input number of appropriate operation:";
            string description =
                                    "1 : Show all components"
                           + "\n" + "2 : Show all containers"
                           + "\n" + "3 : Show all animals"
                           + "\n" + "4 : Work with containers"
                           + "\n" + "5 : Work with animals"
                           + "\n" + "6 : Change day mode (day, night)"
                           + "\n" + "7 : Get all voices"
                           + "\n" + "8 : Get total weight"
                           + "\n" + "9 : Get average weight"
                           ;
            DisplayMenu(title, description);
            try
            {
                int selectedOperation = reader.GetIntNumber(0, 9);
                switch (selectedOperation)
                {
                    case 0:
                        {
                            DisplayMainMenu();
                            return;
                        }
                    case 1:
                        {
                            Console.WriteLine("\nAll components in " + currentZoo + ":");
                            ShowAllComponents(currentZoo);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\nAll conteiners in " + currentZoo + ":");
                            ShowInnerContainers(currentZoo);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nAll animals in " + currentZoo + ":");
                            ShowInnerAnimals(currentZoo);
                            break;
                        }
                    case 4:
                        {
                            DisplayWorkWithContainers();
                            break;
                        }
                    case 5:
                        {
                            DisplayWorkWithAnimals();
                            break;
                        }
                    case 6:
                        {
                            DisplayDayModeChanged();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine(currentZoo.Voice());
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Total weight : " + currentZoo.GetWeight());
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Average weight : " + currentZoo.GetAverageWeight());
                            break;
                        }
                }                
            }
            catch(Exception ex)
            {
                DisplayError(ex.Message);
                DisplayMainMenu();
            }          
        }

        public void DisplayMenu(string title, string description)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + title);
            Console.ForegroundColor = ConsoleColor.Yellow;
            DisplayBackToMainMenu();
            Console.WriteLine(description);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayComplete(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayBackToMainMenu()
        {
            Console.WriteLine("0 : Back to main menu");
        }

        public void ShowAllComponents(Container container)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;
            container.GetComponents()?.ToList().ForEach(component => stringBuilder.AppendLine(i++ + " : " + component.ToString()));
            Console.WriteLine(stringBuilder.Length > 0 ? stringBuilder.ToString() : "No one component in " + container);
        }

        public void ShowInnerContainers(Container container)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;
            container.GetContainers()?.ToList().ForEach(cont => stringBuilder.AppendLine(i++ + " : " + cont.ToString()));
            Console.WriteLine(stringBuilder.Length > 0 ? stringBuilder.ToString() : "No one conteiner in " + container);
        }

        public void ShowInnerAnimals(Container container)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;
            container.GetAnimals()?.ToList().ForEach(cont => stringBuilder.AppendLine(i++ + " : " + cont.ToString()));
            Console.WriteLine(stringBuilder.Length > 0 ? stringBuilder.ToString() : "No one animal in " + container);
        }

        private void DisplayDayModeChanged()
        {
            currentZoo.ChangeDayMode();
            DisplayComplete("Day mode changed!\nCurrent day mode - " + currentZoo.CurrentDayMode);
        }

        private void ComponentIsCreated(Component component)
        {
            DisplayComplete(component + " is created!");
        }

        #endregion

        #region Work with container
        private void DisplayWorkWithContainers()
        {
            string title = "What do u want to do?";
            string description =
                         "1 : Create container"
                + "\n" + "2 : Select some container (to remove, to move to other container, to get voices etc)"                
                ;
            DisplayMenu(title, description);
            try
            {
                int selectedOperations = reader.GetIntNumber(0, 2);
                switch (selectedOperations)
                {
                    case 0:
                        {
                            DisplayMainMenu();
                            return;
                        }
                    case 1:
                        {
                            DisplayCreateContainer();
                            break;
                        }
                    case 2:
                        {
                            DisplaySelectContainer(currentZoo);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                DisplayWorkWithContainers();
            }
           
        }

        private void DisplaySelectContainer(Container container, Animal animal = null, Container containMe = null)
        {
            string title = "Input number of container:";
            this.helpedList = container.GetContainers().ToList<Component>();
            if(containMe != null)
            {
                helpedList.Add(currentZoo);
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < helpedList.Count; i++)
            {
                stringBuilder.AppendLine((i + 1) + " : " + (helpedList[i] as Container));
            }
            DisplayMenu(title, stringBuilder.ToString());

            try
            {
                int selected = reader.GetIntNumber(0, helpedList.Count);
                Component movedComponent = null;

                if (selected == 0)
                {
                    DisplayMainMenu();
                    return;
                }
                else if (containMe == null && animal == null)
                {
                    DisplayOperationsWithSelectedContainer(helpedList[selected - 1] as Container);
                    return;
                }
                else if(containMe != null)
                {
                    movedComponent = containMe;
                }
                else if(animal != null)
                {
                    movedComponent = animal;                                       
                }

                try
                {
                    Container selectedContainer = helpedList[selected - 1] as Container;
                    if (selectedContainer.IsContainerCanContainsComponent(movedComponent))
                        DisplayComponentToContainer(movedComponent, selectedContainer);
                    else
                    {
                        DisplayError("This component can not be placed to " + selectedContainer);
                        DisplaySelectContainer(currentZoo, animal, containMe);
                    }
                }
                catch (Exception ex)
                {
                    DisplayError(ex.Message);
                    DisplaySelectContainer(currentZoo, animal);
                }

            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                DisplaySelectContainer(container);
            }          
        }

        private void DisplayOperationsWithSelectedContainer(Container container)
        {
            string title = "Select some operation with " + container;
            string description =
                             "1 : Remove container (animals will be moved to other containers or removed from zoo :c)"
                    + "\n" + "2 : Move container to other container"
                    + "\n" + "3 : Get all components"
                    + "\n" + "4 : Get all animals"
                    + "\n" + "5 : Get all voices"
                    ;            
            DisplayMenu(title, description);
            try
            {
                int selectedOperation = reader.GetIntNumber(0, 5);
                switch (selectedOperation)
                {
                    case 0:
                        {
                            DisplayMainMenu();
                            return;
                        }
                    case 1:
                        {
                            DisplayRemoveComponent(container);
                            break;
                        }
                    case 2:
                        {
                            DisplaySelectContainer(currentZoo, containMe: container);
                            break;
                        }
                    case 3:
                        {
                            ShowAllComponents(container);
                            DisplayOperationsWithSelectedContainer(container);
                            break;
                        }
                    case 4:
                        {
                            ShowInnerAnimals(container);
                            DisplayOperationsWithSelectedContainer(container);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine(container.Voice());
                            DisplayOperationsWithSelectedContainer(container);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                DisplayOperationsWithSelectedContainer(container);
            }          
        }
      
        private void DisplayCreateContainer()
        {
            string title = "Select type of cage:";
            string description =
                              "1 : Bear cage"
                     + "\n" + "2 : Bear female cage"
                     + "\n" + "3 : Bear male cage"
                     + "\n" + "4 : Wolf cage"
                     + "\n" + "5 : White Wolf cage"
                     + "\n" + "6 : Grey Wolf cage"
                     + "\n" + "7 : Giraffe cage"
                     + "\n" + "8 : Giraffe children cage"
                     + "\n" + "9 : Giraffe adult cage"
                     ;
            DisplayMenu(title, description);
            try
            {
                Container newContainer = null;
                switch (reader.GetIntNumber(0,9))
                {
                    case 0:
                        {
                            DisplayMainMenu();
                            return;                            
                        }
                    case 1:
                        {
                            newContainer = new BearCageFactory().CreateCage();
                            break;
                        }
                    case 2:
                        {
                            newContainer = new FemaleBearCageFactory().CreateCage();
                            break;
                        }
                    case 3:
                        {
                            newContainer = new MaleBearCageFactory().CreateCage();
                            break;
                        }
                    case 4:
                        {
                            newContainer = new WolfCageFactory().CreateCage();
                            break;
                        }
                    case 5:
                        {
                            newContainer = new WhiteWolfCageFactory().CreateCage();
                            break;
                        }
                    case 6:
                        {
                            newContainer = new GreyWolfCageFactory().CreateCage();
                            break;
                        }
                    case 7:
                        {
                            newContainer = new GiraffeCageFactory().CreateCage();
                            break;
                        }
                    case 8:
                        {
                            newContainer = new ChildrenGiraffeCageFactory().CreateCage();
                            break;
                        }
                    case 9:
                        {
                            newContainer = new AdultGiraffeCageFactory().CreateCage();
                            break;
                        }
                }
                DisplaySelectContainer(currentZoo, containMe: newContainer);                
            }
            catch (Exception)
            {

                throw;
            }          
        }
        #endregion

        #region Work with animal
        private void DisplayWorkWithAnimals()
        {
            string title = "What do u want to do?";
            string description =
                         "1 : Create animal"
                + "\n" + "2 : Create random animal"
                + "\n" + "3 : Select animal (to move to some container, edit info etc)"
                ;
            DisplayMenu(title, description);
            try
            {
                int selectedOperations = reader.GetIntNumber(0, 3);
                switch (selectedOperations)
                {
                    case 0:
                        {
                            DisplayMainMenu();
                            return;
                        }
                    case 1:
                        {
                            CreateAnimal();
                            break;
                        }
                    case 2:
                        {
                            DisplayCreateRandomAnimal();
                            break;
                        }
                    case 3:
                        {
                            DisplaySelectAnimal();
                            break;
                        }

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                DisplayWorkWithAnimals();
            }
        }

        private void DisplaySelectAnimal()
        {
            string title = "Input number of animal:";
            this.helpedList = currentZoo.GetAnimals().ToList<Component>();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < helpedList.Count; i++)
            {
                stringBuilder.AppendLine((i + 1) + " : " + (helpedList[i] as Animal));
            }
            DisplayMenu(title, stringBuilder.ToString());

            try
            {
                int selected = reader.GetIntNumber(0, helpedList.Count);
                if (selected == 0)
                {
                    DisplayMainMenu();
                    return;
                }
                else
                    DisplayEditAnimal(helpedList[selected - 1] as Animal);
            }
            catch(Exception ex)
            {
                DisplayError(ex.Message);
                DisplaySelectAnimal();
            }
        }     

        private void DisplayCreateRandomAnimal()
        {
            Animal randomAnimal = AnimalFactory.CreateRandomAnimal();
            ComponentIsCreated(randomAnimal);
            DisplayHowSelectContainerForAnimal(randomAnimal);
        }

        #region Manual creating

        private void CreateAnimal()
        {
            byte typeOfAnimal = DisplaySelectTypeOfNewAnimal();
            if (typeOfAnimal == 0)
            {
                DisplayMainMenu();
                return;
            }

            string name = DisplayInputName();
            ushort weight = DisplayInputWeight();

            Animal newAnimal = null;

            switch (typeOfAnimal)
            {
                case 1:
                    {
                        newAnimal = new BearFactory().CreateAnimal(DisplaySelectMaleOfBear());                        
                        break;
                    }
                case 2:
                    {
                        newAnimal = new GiraffeFactory().CreateAnimal(DisplaySelectAgeOfGiraffe());                        
                        break;
                    }
                case 3:
                    {
                        newAnimal = new WhiteWolfFactory().CreateAnimal();
                        break;
                    }
                case 4:
                    {
                        newAnimal = new GreyWolfFactory().CreateAnimal();                           
                        break;
                    }
            }
            
            newAnimal.Name = name;
            newAnimal.Weight = weight;

            ComponentIsCreated(newAnimal);
            DisplayHowSelectContainerForAnimal(newAnimal);
        }

        private byte DisplaySelectTypeOfNewAnimal()
        {
            string title = "Select type of animals:";
            string desk =
                            "1 : Bear"                   
                   + "\n" + "2 : Giraffe"                   
                   + "\n" + "3 : White wolf"
                   + "\n" + "4 : Grey wolf"
                   ;
            DisplayMenu(title, desk);
            try
            {
                return (byte)reader.GetIntNumber(0, 4);                
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                return DisplaySelectTypeOfNewAnimal();
            }         
        }

        private byte DisplaySelectAgeOfGiraffe()
        {
            string title = "Input age of giraffe:";
            Console.WriteLine(title);
            byte age;
            try
            {
                return (byte)reader.GetIntNumber(0, 255);
            }
            catch (Exception ex)
            {
                age = (byte)(new Random().Next(1, 30));
                DisplayError(ex.Message + "\nSo random age is " + age);
                return age;
            }            
        }

        private MaleMode DisplaySelectMaleOfBear()
        {
            string title = "Selecte male of bear:"
                + "\n" + "0 : female"
                + "\n" + "1 : male"
                ;
            Console.WriteLine(title);            
            try
            {
                return (MaleMode)reader.GetIntNumber(0, 1);                
            }
            catch (Exception ex)
            {
                MaleMode mode = (MaleMode)(new Random().Next(0, 1));
                DisplayError(ex.Message + "\n So random male is " + mode);
                return mode;
            }
        }

        private ushort DisplayInputWeight(Animal animal = null)
        {
            string title = "Input new weight of " + (animal?.Name ?? "new animal") + " :";
            Console.WriteLine(title);
            try
            {
                return (byte)reader.GetIntNumber(0);
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                if (animal != null)
                {
                    DisplayError("Weight not changed.");
                    return animal.Weight;
                }
                else
                {
                    ushort randomWeight = (ushort)new Random().Next(1, 100);
                    Console.WriteLine("Wrong input, so animal weight will be " + randomWeight);
                    return randomWeight;
                }
            }
        }

        private string DisplayInputName(Animal animal = null)
        {
            string title = "Input new name of " + (animal?.Name ?? "new animal") + " :";
            Console.WriteLine(title);
            try
            {
                return reader.GetNotEmptyString();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                if (animal != null)
                {
                    DisplayError("Name not changed.");
                    return animal.Name;
                }
                else
                {
                    int seconds = DateTime.Now.Millisecond;
                    Console.WriteLine("Wrong input, so animal will be named 'Unknown" + seconds + "'");
                    return "Unknown" + seconds;
                }
            }
        }

        private void DisplayHowSelectContainerForAnimal(Animal animal)
        {
            Container container = currentZoo.GetContainerForAnimal(animal);
            if (container == null)
            {
                DisplayError("We can not move animal to this zoo. Please firstly create appropriate container");
                DisplayMainMenu();
                return;
            }

            string title = "Where u want to place " + animal + "?";                   
            string description = 
                             "1 : Place auto (it means that if zoo contains some appropriate container - animal will be placed there"
                    + "\n" + "2 : Select container manually"
                    ;
            DisplayMenu(title, description);

            try
            {
                byte selectedOp = (byte)reader.GetIntNumber(0, 2);
                switch (selectedOp)
                {
                    case 0:
                        {
                            DisplayMainMenu();
                            break;
                        }
                    case 1:
                        {
                            DisplayComponentToContainer(animal, container);
                            break;
                        }
                    case 2:
                        {
                            DisplaySelectContainer(currentZoo, animal);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
                DisplayHowSelectContainerForAnimal(animal);                
            }            
        }
        #endregion
        
        public void DisplayEditAnimal(Animal animal)
        {
            string title = "Please select how u want to edit animal";
            string desc =
                        "1 : Change container"
               + "\n" + "2 : Edit name and weight"
               + "\n" + "3 : Remove animal"
               ;
            DisplayMenu(title, desc);
            try
            {
                switch (reader.GetIntNumber(0,3))
                {
                    case 0:
                        {
                            DisplayMainMenu();
                            return;
                        }
                    case 1:
                        {
                            DisplayHowSelectContainerForAnimal(animal);
                            break;
                        }
                    case 2:
                        {
                            string newName = DisplayInputName(animal);
                            ushort weight = DisplayInputWeight(animal);
                            animal.Name = newName;
                            animal.Weight = weight;
                            DisplayComplete("Now name is " + newName + " and weight smt like " + weight);
                            break;
                        }
                    case 3:
                        {
                            DisplayRemoveComponent(animal);
                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                DisplayError(ex.Message);
                DisplayEditAnimal(animal);
            }
        }        

        private void DisplayComponentToContainer(Component component, Container container)
        {
            component.ChangeContainer(currentZoo, container);
            DisplayComplete(component + " was moved to " + container);
            DisplayMainMenu();
        }
        #endregion

        private void DisplayRemoveComponent(Component component)
        {
            Container container = currentZoo.GetContainerWithComponent(component);
            if (container != null)
            {
                container.Remove(component);
                DisplayComplete(component + " was removed from " + container);
            }
        }
    }
}
/*
 case 0:
                    {
                        DisplayMainMenu();
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
 */
