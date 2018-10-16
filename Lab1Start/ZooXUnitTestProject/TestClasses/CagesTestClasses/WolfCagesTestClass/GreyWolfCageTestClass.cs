using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.WolfCageFactory;
using Lab2Zoo.Models.Cages.WolfCages;

namespace ZooXUnitTestProject.TestClasses.CagesTestClasses.WolfCagesTestClasses
{
    public class GreyWolfCageTestClass
    {
        readonly GreyWolfCage greyWolfCage;
        readonly WhiteWolfCage whiteWolfCage;

        readonly WhiteWolf whiteWolf;
        readonly GreyWolf greyWolf;

        public GreyWolfCageTestClass()
        {
            greyWolfCage = new GreyWolfCageFactory().CreateCage() as GreyWolfCage;
            whiteWolfCage = new WhiteWolfCageFactory().CreateCage() as WhiteWolfCage;

            whiteWolf = new WhiteWolfFactory().CreateAnimal() as WhiteWolf;
            greyWolf = new GreyWolfFactory().CreateAnimal() as GreyWolf;
        }


        [Fact]
        public void IsContainerCanContainsContainer_WhenInnerContainerIsGreyWolfCage_ReturnsTrue()
        {
            Assert.True(greyWolfCage.IsContainerCanContainsContainer(greyWolfCage));
        }

        [Fact]
        public void IsContainerCanContainsContainer_WhenInnerContainerIsWhiteWolfCage_ReturnsFalse()
        {
            Assert.False(greyWolfCage.IsContainerCanContainsContainer(whiteWolfCage));
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenComponentIsGreyWolf_ReturnsTrue()
        {
            Assert.True(greyWolfCage.IsContainerCanContainsAnimal(greyWolf));
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenComponentIsWhiteWolf_ReturnsFalse()
        {
            Assert.False(greyWolfCage.IsContainerCanContainsAnimal(whiteWolf));
        }
    }
}
