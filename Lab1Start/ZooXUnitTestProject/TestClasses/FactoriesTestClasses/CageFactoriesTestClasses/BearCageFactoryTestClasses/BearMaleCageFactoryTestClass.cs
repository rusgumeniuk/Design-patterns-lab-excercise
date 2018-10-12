using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Cages.BearCages;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.CageFactoriesTestClasses.BearCageFactoryTestClasses
{
    public class BearMaleCageFactoryTestClass
    {
        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedBearCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<BearCage>(new MaleBearCageFactory().CreateCage());
        }

        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedBeaMaleCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<BearMaleCage>(new MaleBearCageFactory().CreateCage());
        }
    }
}
