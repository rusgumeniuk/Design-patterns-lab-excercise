using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.AnimalTestClasses
{
    public class GreyWolfTestClass
    {
        readonly GreyWolfFactory greyWolfFactory;
        readonly GreyWolf greyWolf;

        public GreyWolfTestClass()
        {
            greyWolfFactory = new GreyWolfFactory();
            greyWolf = greyWolfFactory.CreateAnimal() as GreyWolf;
        }

        [Fact]
        public void IsWolf_ReturnsTrue()
        {
            Assert.IsAssignableFrom<Wolf>(greyWolf);
        }
    }
}
