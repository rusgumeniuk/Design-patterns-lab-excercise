using System;
using Xunit;

using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;
using Lab2Zoo.Models.Cages.BearCages;
using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.ContainersTestClasses
{
    public class CageTest
    {
        readonly BearCageFactory bearCageFactory;
        readonly FemaleBearCageFactory femaleBearCageFactory;
        readonly BearCage bearCage;
        readonly BearFemaleCage bearFemaleCage;

        public CageTest()
        {
            bearCageFactory = new BearCageFactory();
            femaleBearCageFactory = new FemaleBearCageFactory();
            bearCage = bearCageFactory.CreateCage() as BearCage;
            bearFemaleCage = femaleBearCageFactory.CreateCage() as BearFemaleCage;
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenCanContains_ReturnsTrue()
        {
            Assert.True(bearCage.IsContainerCanContainsContainer(bearFemaleCage));
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenCanNotContains_ReturnsFalse()
        {
            Assert.False(bearFemaleCage.IsContainerCanContainsContainer(bearCage));
        }


        [Fact]
        public void Voice_WhenEcmptyCage_ReturnsEmptyCage()
        {
            Assert.Equal("Empty cage " + bearCage.Id, bearCage.Voice());
        }


        [Fact]
        public void IsContainerIsParentContainer_WhenUserTryToAddToContainerOtherContainerWhichIsParentContainer_ReturnsTrue()
        {
            bearCage.Add(bearFemaleCage);
            Assert.True(bearFemaleCage.IsContainerIsParentContainer(bearCage));
        }

        [Fact]
        public void IsContainerIsParentContainer_WhenCheckInnerCage_ReturnsFalse()
        {
            bearCage.Add(bearFemaleCage);
            Assert.False(bearCage.IsContainerIsParentContainer(bearFemaleCage));
        }


        [Fact]
        public void IsContainerAlreadyContainsComponent_WhenTryToAddAlreadyExistingAnimal_ReturnsTrue()
        {
            bearCage.Add(bearFemaleCage);
            Bear bear = new BearFactory().CreateAnimal(Lab2Zoo.Models.Enums.MaleMode.Female) as Bear;

            bearFemaleCage.Add(bear);

            Assert.True(bearCage.IsContainerAlreadyContainsComponent(bear));
        }

        [Fact]
        public void IsContainerAlreadyContainsComponent_WhenAnimalNotInAnyContainer_ReturnsFalse()
        {
            bearCage.Add(bearFemaleCage);
            Bear bear = new BearFactory().CreateAnimal(Lab2Zoo.Models.Enums.MaleMode.Female) as Bear;            

            Assert.False(bearCage.IsContainerAlreadyContainsComponent(bear));
        }
    }
}
