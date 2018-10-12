using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages;
using Lab2Zoo.Models.Cages.WolfCages;
using Lab2Zoo.Models.Factories.CageFactories.WolfCageFactory;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.CageFactoriesTestClasses.WolfCageFactoryTestClasses
{
    public class WhiteWolfCageFactoryTestClass
    {
        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedBearCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<WolfCage<WhiteWolf>>(new WhiteWolfCageFactory().CreateCage());
        }

        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedCage_ReturnsTrue()
        {
            Assert.IsType<WhiteWolfCage>(new WhiteWolfCageFactory().CreateCage());
        }
    }
}
