using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages;
using Lab2Zoo.Models.Cages.GiraffeCages;
using Lab2Zoo.Models.Factories.CageFactories.GiraffeCageFactory;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.CageFactoriesTestClasses.GiraffeCageFactoryTestClasses
{
    public class GiraffeCageFactoryTestClass
    {
        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedBearCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<GiraffeCage>(new GiraffeCageFactory().CreateCage());
        }

        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<Cage<Giraffe>>(new GiraffeCageFactory().CreateCage());
        }
    }
}
