using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.AnimalFactoriesTestClasses
{
    public class WhiteWolfFactoryTestClass
    {
        [Fact]
        public void CreateAnimal_WhenCreatAnimal_ReturnsTrue()
        {
            Assert.IsType<WhiteWolf>(new WhiteWolfFactory().CreateAnimal());
        }
    }
}
