using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.AnimalTestClasses
{
    public class BearTestClass
    {
        readonly BearFactory bearFactory;
        readonly Bear bear;

        public BearTestClass()
        {
            bearFactory = new BearFactory();
            bear = bearFactory.CreateAnimal(Lab2Zoo.Models.Enums.MaleMode.Female) as Bear;
        }

        [Fact]
        public void MaleMode_WhenChangeMale_ReturnsTrue()
        {
            bear.Male = Lab2Zoo.Models.Enums.MaleMode.Male;
            Assert.Equal(Lab2Zoo.Models.Enums.MaleMode.Male, bear.Male);
        }

        [Fact]
        public void Voice_WhenGetVoice_ReturnsTrue()
        {
            Assert.Equal(bear.Id + ": Grrrrr", bear.Voice());
        }
    }
}
