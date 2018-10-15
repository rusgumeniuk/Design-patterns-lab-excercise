using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.GiraffeCageFactory;
using Lab2Zoo.Models.Cages.GiraffeCages;

namespace ZooXUnitTestProject.TestClasses.CagesTestClasses.GiraffeCagesTestClasses
{
    public class GiraffeCageTestClass
    {
        readonly GiraffeCageFactory giraffeCageFactory;
        readonly AdultGiraffeCageFactory adultGiraffeCageFactory;
        readonly ChildrenGiraffeCageFactory childrenGiraffeCageFactory;

        readonly GiraffeCage giraffeCage;
        readonly GiraffeAdultCage giraffeAdultCage;
        readonly GiraffeChildrenCage giraffeChildrenCage;

        readonly GiraffeFactory giraffeFactory;
        readonly Giraffe giraffe;

        public GiraffeCageTestClass()
        {
            adultGiraffeCageFactory = new AdultGiraffeCageFactory();
            childrenGiraffeCageFactory = new ChildrenGiraffeCageFactory();
            giraffeCageFactory = new GiraffeCageFactory();
            giraffeFactory = new GiraffeFactory();

            giraffeCage = giraffeCageFactory.CreateCage() as GiraffeCage;
            giraffeAdultCage = adultGiraffeCageFactory.CreateCage() as GiraffeAdultCage;
            giraffeChildrenCage = childrenGiraffeCageFactory.CreateCage() as GiraffeChildrenCage;

            giraffe = giraffeFactory.CreateAnimal() as Giraffe;
        }

        [Fact]
        public void IsContainerCanContainsContainer_WhenAddDerivedContainers_ReturnsTrue()
        {
            Assert.True(giraffeCage.IsContainerCanContainsContainer(giraffeAdultCage));
            Assert.True(giraffeCage.IsContainerCanContainsContainer(giraffeChildrenCage));
        }

        [Fact]
        public void Add_WhenAnimalIsBear_ReturnArgumentException()
        {
            Assert.Throws<TypeAccessException>(() => giraffeCage.Add(new BearFactory().CreateAnimal() as Bear))
;
        }
    }
}
