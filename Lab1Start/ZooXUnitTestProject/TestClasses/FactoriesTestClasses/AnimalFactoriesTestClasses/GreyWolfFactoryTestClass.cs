using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.AnimalFactoriesTestClasses
{
    public class GreyWolfFactoryTestClass
    {
        [Fact]
        public void CreateAnimal_WhenCreatAnimal_ReturnsTrue()
        {
            Assert.IsType<GreyWolf>(new WhiteWolfFactory().CreateAnimal());
        }
    }
}
