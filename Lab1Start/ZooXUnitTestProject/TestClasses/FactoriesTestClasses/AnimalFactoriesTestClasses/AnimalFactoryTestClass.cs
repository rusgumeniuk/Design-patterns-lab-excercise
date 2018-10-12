using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.AnimalFactoriesTestClasses
{
    public class AnimalFactoryTestClass
    {
        [Fact]
        public void CreateRandomAnimal_IsCreatedObjectIsDerivedOfAnimal_ReturnsTrue()
        {
            Assert.IsAssignableFrom<Animal>(AnimalFactory.CreateRandomAnimal());
        }

        [Fact]
        public void CreateRandomAnimal_IsCreatedObjectNotNull_ReturnsTrue()
        {
            Assert.NotNull(AnimalFactory.CreateRandomAnimal());
        }
    }
}
