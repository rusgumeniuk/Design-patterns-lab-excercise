using System;
using Xunit;

using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;
using Lab2Zoo.Models.Cages.BearCages;
namespace ZooXUnitTestProject.TestClasses.ContainersTestClasses
{
    public class CageTest
    {
        readonly BearCageFactory cageFactory;
        readonly BearCage bearCage;

        public CageTest()
        {
            cageFactory = new BearCageFactory();
            bearCage = cageFactory.CreateCage() as BearCage;
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenCanContains_ReturnsTrue()
        {

        }

        [Fact]
        public void Voice_WhenEcmptyCage_ReturnsEmptyCage()
        {
            Assert.Equal("Empty cage " + bearCage.Id, bearCage.Voice());
        }
    }
}
