using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.WolfCageFactory;
using Lab2Zoo.Models.Cages.WolfCages;

namespace ZooXUnitTestProject.TestClasses.CagesTestClasses.WolfCagesTestClasses
{
    public class WolfCageTestClass
    {
        readonly GreyWolfCage greyWolfCage;
        readonly WhiteWolfCage whiteWolfCage;
        readonly WolfCage<Wolf> wolfCage;

        readonly WhiteWolf whiteWolf;
        readonly GreyWolf greyWolf;

        public WolfCageTestClass()
        {
            greyWolfCage = new GreyWolfCageFactory().CreateCage() as GreyWolfCage;
            whiteWolfCage = new WhiteWolfCageFactory().CreateCage() as WhiteWolfCage;
            wolfCage = new WolfCageFactory().CreateCage() as WolfCage<Wolf>;

            whiteWolf = new WhiteWolfFactory().CreateAnimal() as WhiteWolf;
            greyWolf = new GreyWolfFactory().CreateAnimal() as GreyWolf;
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenAnyWolf_ReturnsFalse()
        {
            Assert.All(new Wolf[] { greyWolf, whiteWolf }, wolf => { Assert.False(wolfCage.IsContainerCanContainsAnimal(wolf)); });
        }

        [Fact]
        public void IsContainerCanContainsContainer_WhenAnyWolfCage_ReturnsTrue()
        {
            Assert.True(wolfCage.IsContainerCanContainsContainer(whiteWolfCage));
            Assert.True(wolfCage.IsContainerCanContainsContainer(greyWolfCage));
            Assert.True(wolfCage.IsContainerCanContainsContainer(new WolfCageFactory().CreateCage() as WolfCage<Wolf>));
        }
    }
}
