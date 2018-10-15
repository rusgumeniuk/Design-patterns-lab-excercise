using System;
using Xunit;

using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;
using Lab2Zoo.Models.Cages.BearCages;

namespace ZooXUnitTestProject.TestClasses.ContainersTestClasses
{
    public class CageTest
    {
        readonly BearCageFactory bearCageFactory;
        readonly FemaleBearCageFactory femaleBearCageFactory;
        readonly BearCage bearCage;
        readonly BearFemaleCage bearFemaleCage;

        public CageTest()
        {
            bearCageFactory = new BearCageFactory();
            femaleBearCageFactory = new FemaleBearCageFactory();
            bearCage = bearCageFactory.CreateCage() as BearCage;
            bearFemaleCage = femaleBearCageFactory.CreateCage() as BearFemaleCage;
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenCanContains_ReturnsTrue()
        {
            Assert.True(bearCage.IsContainerCanContainsContainer(bearFemaleCage));
        }

        [Fact]
        public void IsContainerCanContainsAnimal_WhenCanNotContains_ReturnsFalse()
        {
            Assert.False(bearFemaleCage.IsContainerCanContainsContainer(bearCage));
        }

        [Fact]
        public void Voice_WhenEcmptyCage_ReturnsEmptyCage()
        {
            Assert.Equal("Empty cage " + bearCage.Id, bearCage.Voice());
        }
    }
}
