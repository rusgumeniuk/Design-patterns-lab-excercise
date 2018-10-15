using System;
using Xunit;

using Lab2Zoo.Models;
using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Cages.BearCages;
using Lab2Zoo.Models.Cages.GiraffeCages;
using Lab2Zoo.Models.Factories.CageFactories.GiraffeCageFactory;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;
using Lab2Zoo.Models.Enums;
using System.Text;

namespace ZooXUnitTestProject.TestClasses.ContainersTestClasses
{
    public class ZooTest
    {
        #region StartInfo
        readonly Zoo zoo;

        readonly Giraffe giraffe;
        readonly Bear bear;

        readonly GiraffeFactory giraffeFactory;
        readonly BearFactory bearFactory;

        readonly BearCage bearCage;
        readonly GiraffeCage giraffeCage;

        readonly BearCageFactory bearCageFactory;
        readonly GiraffeCageFactory giraffeCageFactory;

        public ZooTest()
        {
            zoo = new Zoo();
            giraffeCageFactory = new GiraffeCageFactory();
            giraffeFactory = new GiraffeFactory();
            bearFactory = new BearFactory();
            bearCageFactory = new BearCageFactory();

            giraffe = giraffeFactory.CreateAnimal() as Giraffe;
            bear = bearFactory.CreateAnimal() as Bear;
            giraffeCage = giraffeCageFactory.CreateCage() as GiraffeCage;
            bearCage = bearCageFactory.CreateCage() as BearCage;

            zoo.Add(giraffeCage);
            zoo.Add(bearCage);

            giraffeCage.Add(giraffe);
            bearCage.Add(bear);
        }
        #endregion

        [Fact]
        public void ChangeDayMode_WhenChangeDayModeSomeTimes_ReturnsTrue()
        {
            zoo.ChangeDayMode();
            zoo.ChangeDayMode();
            zoo.ChangeDayMode(DayMode.Night);
            Assert.Equal(DayMode.Night, zoo.CurrentDayMode);
        }

        [Fact]
        public void WakeZooUp_WhenAllAnimalsHaveToWakeUp_ReturnsTrue()
        {
            zoo.ChangeDayMode(Lab2Zoo.Models.Enums.DayMode.Night);
            zoo.ChangeDayMode();

            Assert.All(zoo.GetAnimals(), animal => Assert.False(animal.IsSleeping));
        }

        [Fact]
        public void Voice_WhenAllAnimalsIsSleeping_ReturnsAllVoices()
        {
            zoo.ChangeDayMode(DayMode.Night);
            giraffe.IsSleeping = true;
            bear.IsSleeping = true;

            StringBuilder builder = new StringBuilder();
            builder.Append(giraffe.WakeUp()).AppendLine(giraffe.Voice()).AppendLine().Append(bear.WakeUp()).AppendLine(bear.Voice()).AppendLine();

            giraffe.IsSleeping = true;
            bear.IsSleeping = true;
            var result = zoo.Voice();

            Assert.Equal(builder.ToString(), result);
        }

        [Fact]
        public void Voice_WhenEmptyZoo_ReturnsNoOne()
        {
            zoo.Remove(bearCage);
            zoo.Remove(giraffeCage);
            Assert.Equal("No one in zoo", zoo.Voice());
        }

        [Fact]
        public void IsContainerCanContainsContainer_WhenAddZoo_ReturnsFalse()
        {
            Assert.False(zoo.IsContainerCanContainsContainer(new Zoo()));
        }

        [Fact]
        public void IsContainerCanContainsComponent_WhenAddAnyAnimal_ReturnsFalse()
        {
            Assert.False(zoo.IsContainerCanContainsAnimal(giraffe));
            Assert.False(zoo.IsContainerCanContainsAnimal(bear));
        }
    }
}
