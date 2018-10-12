using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Cages;
using Lab2Zoo.Models.Cages.BearCages;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.CageFactoriesTestClasses.BearCageFactoryTestClasses
{
    public class BearCageFactoryTestClass
    {
        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedBearCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<BearCage>(new BearCageFactory().CreateCage());
        }

        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<Cage<Bear>>(new BearCageFactory().CreateCage());
        }
    }
}
