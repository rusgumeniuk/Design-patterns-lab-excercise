using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.FactoriesTestClasses.AnimalFactoriesTestClasses
{
    public class GiraffeFactoryTestClass
    {
        readonly GiraffeFactory giraffeFactory;

        public GiraffeFactoryTestClass()
        {
            giraffeFactory = new GiraffeFactory();
        }

        [Fact]
        public void CreateAnimal_WhenCreatAnimal_ReturnsTrue()
        {
            Assert.IsType<Giraffe>(giraffeFactory.CreateAnimal());
        }

        [Theory]        
        [InlineData(5)]
        [InlineData(25)]
        public void CreateAnimal_WhenSetAge_ReturnsTrue(byte age)
        {
            Assert.Equal(age, (giraffeFactory.CreateAnimal(age) as Giraffe).Age);
        }

        [Fact]
        public void CreateAnimal_WhenSetWrognAge_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => giraffeFactory.CreateAnimal(0));
        }

        [Fact]
        public void CreateAnimal_WhenCreate_ReturnsTrue()
        {
            Giraffe giraffe = giraffeFactory.CreateAnimal() as Giraffe;

            Assert.True(giraffe.Age < 31);
            Assert.True(giraffe.Age > 0);
        }
    }
}
