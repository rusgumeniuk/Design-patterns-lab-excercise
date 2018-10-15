using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.AnimalTestClasses
{
    public class WhiteWolfTestClass
    {
        readonly WhiteWolfFactory whiteWolfFactory;
        readonly WhiteWolf whiteWolf;

        public WhiteWolfTestClass()
        {
            whiteWolfFactory = new WhiteWolfFactory();
            whiteWolf = whiteWolfFactory.CreateAnimal() as WhiteWolf;
        }

        [Fact]
        public void IsWolf_ReturnsTrue()
        {
            Assert.IsAssignableFrom<Wolf>(whiteWolf);
        }
    }
}
