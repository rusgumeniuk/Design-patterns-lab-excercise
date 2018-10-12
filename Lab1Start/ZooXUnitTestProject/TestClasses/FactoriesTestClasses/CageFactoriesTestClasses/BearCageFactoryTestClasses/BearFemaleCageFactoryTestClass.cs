using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages.BearCages;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.CageFactoriesTestClasses.BearCageFactoryTestClasses
{
    public class BearFemaleCageFactoryTestClass
    {
        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedBearCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<BearCage>(new FemaleBearCageFactory().CreateCage());
        }

        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedBearFemaleCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<BearFemaleCage>(new FemaleBearCageFactory().CreateCage());
        }
    }
}
