using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Enums;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.AnimalFactoriesTestClasses
{
    public class BearFactoryTestClass
    {
        readonly BearFactory bearFactory;

        public BearFactoryTestClass()
        {
            bearFactory = new BearFactory();
        }

        [Fact]
        public void CreateAnimal_WhenCreatAnimal_ReturnsTrue()
        {
            Assert.IsType<Bear>(bearFactory.CreateAnimal());
        }        

        [Fact]
        public void CreateAnimal_WhenSetMale_ReturnsTrue()
        {
            Assert.Equal(MaleMode.Male, (bearFactory.CreateAnimal(MaleMode.Male) as Bear).Male);
        }
    }
}
