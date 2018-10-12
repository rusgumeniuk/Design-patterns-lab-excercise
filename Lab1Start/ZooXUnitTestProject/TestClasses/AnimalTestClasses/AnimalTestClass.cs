using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.AnimalTestClasses
{
    public class AnimalTestClass
    {
        [Fact]
        public void Name_WhenSetNull_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => AnimalFactory.CreateRandomAnimal().Name = null);
        }
    }
}
