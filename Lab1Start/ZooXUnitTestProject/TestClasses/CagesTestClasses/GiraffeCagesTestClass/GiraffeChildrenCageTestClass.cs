using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.GiraffeCageFactory;
using Lab2Zoo.Models.Cages.GiraffeCages;

namespace ZooXUnitTestProject.TestClasses.CagesTestClasses.GiraffeCagesTestClasses
{
    public class GiraffeChildrenCageTestClass
    {
        readonly AdultGiraffeCageFactory adultGiraffeCageFactory;
        readonly ChildrenGiraffeCageFactory childrenGiraffeCageFactory;

        readonly GiraffeAdultCage giraffeAdultCage;
        readonly GiraffeChildrenCage giraffeChildrenCage;

        readonly GiraffeFactory giraffeFactory;
        readonly Giraffe giraffe;

        public GiraffeChildrenCageTestClass()
        {
            adultGiraffeCageFactory = new AdultGiraffeCageFactory();
            childrenGiraffeCageFactory = new ChildrenGiraffeCageFactory();
            giraffeFactory = new GiraffeFactory();

            giraffeAdultCage = adultGiraffeCageFactory.CreateCage() as GiraffeAdultCage;
            giraffeChildrenCage = childrenGiraffeCageFactory.CreateCage() as GiraffeChildrenCage;

            giraffe = giraffeFactory.CreateAnimal() as Giraffe;
        }

        [Fact]
        public void IsContainerCanContainsContainer_WhenCanNotContains_ReturnFalse()
        {
            Assert.False(giraffeChildrenCage.IsContainerCanContainsContainer(giraffeAdultCage));
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenAdult_ReturnFalse()
        {
            giraffe.Age = 15;
            Assert.False(giraffeChildrenCage.IsContainerCanContainsAnimal(giraffe));
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenChild_ReturnTrue()
        {
            giraffe.Age = 13;
            Assert.True(giraffeChildrenCage.IsContainerCanContainsAnimal(giraffe));
        }
    }
}
