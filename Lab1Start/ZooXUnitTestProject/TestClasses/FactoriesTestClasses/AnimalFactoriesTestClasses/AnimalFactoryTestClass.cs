using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.AnimalFactoriesTestClasses
{
    public class AnimalFactoryTestClass
    {
        [Fact]
        public void CreateRandomAnimal_ClassTest_ReturnsTrue()
        {            
            Assert.Throws<ArgumentException>(() => AnimalFactory.CreateRandomAnimal().Name = null);
        }
    }
}
