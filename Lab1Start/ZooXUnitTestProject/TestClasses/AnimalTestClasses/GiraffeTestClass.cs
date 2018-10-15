using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.AnimalTestClasses
{
    public class GiraffeTestClass
    {
        readonly GiraffeFactory giraffeFactory;
        readonly Giraffe giraffe;

        public GiraffeTestClass()
        {
            giraffeFactory = new GiraffeFactory();
            giraffe = giraffeFactory.CreateAnimal(10) as Giraffe;
        }

        [Fact]
        public void Age_WhenSet20_ReturnTrue() 
        {
            int newAge = 20;
            giraffe.Age = (byte)newAge;
            Assert.Equal(newAge, giraffe.Age);
        }

        [Fact]
        public void Age_WhenSet0_ReturnArgumentException()
        {
            Assert.Throws<ArgumentException>(() => giraffe.Age = 0); 
        }        
    }
}
