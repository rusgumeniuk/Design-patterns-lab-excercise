using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;
using Lab2Zoo.Models.Cages.BearCages;

namespace ZooXUnitTestProject.TestClasses.CagesTestClasses.BearCagesTestClasses
{
    public class BearCageTestClass
    {
        readonly BearCage mainBearCage;
        readonly BearCage innerCage;
        readonly BearFemaleCage femaleCage;
        readonly BearMaleCage maleCage;

        readonly Bear bear;

        public BearCageTestClass()
        {            
            mainBearCage = new BearCageFactory().CreateCage() as BearCage;
            innerCage = new BearCageFactory().CreateCage() as BearCage;
            femaleCage = new FemaleBearCageFactory().CreateCage() as BearFemaleCage;
            maleCage = new MaleBearCageFactory().CreateCage() as BearMaleCage;
            
            bear = new BearFactory().CreateAnimal() as Bear;
        }

        [Fact]
        public void IsContainerCanContainsComponent_WhenCompIsContainersAndCan_ReturnsTrue()
        {
            Assert.True(mainBearCage.IsContainerCanContainsComponent(innerCage));
            Assert.True(mainBearCage.IsContainerCanContainsComponent(femaleCage));
            Assert.True(mainBearCage.IsContainerCanContainsComponent(maleCage));

            Assert.True(innerCage.IsContainerCanContainsComponent(femaleCage));
            Assert.True(innerCage.IsContainerCanContainsComponent(maleCage));
        }

        [Fact]
        public void IsContainerCanContainsComponent_WhenCanNotContains_ReturnsFalse()
        {
            bear.Male = Lab2Zoo.Models.Enums.MaleMode.Female;
            Assert.False(femaleCage.IsContainerCanContainsComponent(maleCage));
            Assert.False(maleCage.IsContainerCanContainsComponent(bear));
        }
    }
}
