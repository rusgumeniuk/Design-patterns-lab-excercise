using System;
using Xunit;

using Lab2Zoo.Models.Cages;
using Lab2Zoo.Models.Cages.GiraffeCages;
using Lab2Zoo.Models.Factories.CageFactories.GiraffeCageFactory;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.CageFactoriesTestClasses.GiraffeCageFactoryTestClasses
{
    public class GiraffeChildrenCageFactoryTestClass
    {
        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedBearCage_ReturnsTrue()
        {
            Assert.IsAssignableFrom<GiraffeCage>(new ChildrenGiraffeCageFactory().CreateCage());
        }

        [Fact]
        public void CreateCage_WhenCreate_IsInstanceIsDerivedCage_ReturnsTrue()
        {
            Assert.IsType<GiraffeChildrenCage>(new ChildrenGiraffeCageFactory().CreateCage());
        }
    }
}
