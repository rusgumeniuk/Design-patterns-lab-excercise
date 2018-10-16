using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.WolfCageFactory;
using Lab2Zoo.Models.Cages.WolfCages;

namespace ZooXUnitTestProject.TestClasses.CagesTestClasses.WolfCagesTestClasses
{
    public class WhiteWolfCageTestClass
    {
        readonly GreyWolfCage greyWolfCage;
        readonly WhiteWolfCage whiteWolfCage;

        readonly WhiteWolf whiteWolf;
        readonly GreyWolf greyWolf;

        public WhiteWolfCageTestClass()
        {
            greyWolfCage = new GreyWolfCageFactory().CreateCage() as GreyWolfCage;
            whiteWolfCage = new WhiteWolfCageFactory().CreateCage() as WhiteWolfCage;            

            whiteWolf = new WhiteWolfFactory().CreateAnimal() as WhiteWolf;
            greyWolf = new GreyWolfFactory().CreateAnimal() as GreyWolf;
        }

        [Fact]
        public void IsContainerCanContainsContainer_WhenInnerContainerIsGreyWolfCage_ReturnsFalse()
        {
            Assert.False(whiteWolfCage.IsContainerCanContainsContainer(greyWolfCage));
        }

        [Fact]
        public void IsContainerCanContainsContainer_WhenInnerContainerIsWhiteWolfCage_ReturnsTrue()
        {
            Assert.True(whiteWolfCage.IsContainerCanContainsContainer(whiteWolfCage));
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenComponentIsGreyWolf_ReturnsFalse()
        {
            Assert.False(whiteWolfCage.IsContainerCanContainsAnimal(greyWolf));
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenComponentIsWhiteWolf_ReturnsTrue()
        {
            Assert.True(whiteWolfCage.IsContainerCanContainsAnimal(whiteWolf));
        }
    }
}
