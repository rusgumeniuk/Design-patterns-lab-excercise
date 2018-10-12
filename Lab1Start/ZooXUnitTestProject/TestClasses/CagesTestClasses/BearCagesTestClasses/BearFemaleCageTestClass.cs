using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;
using Lab2Zoo.Models.Cages.BearCages;

namespace ZooXUnitTestProject.TestClasses.CagesTestClasses.BearCagesTestClasses
{
    public class BearFemaleCageTestClass
    {
        readonly BearFemaleCage cage;
        readonly Bear bear;

        public BearFemaleCageTestClass()
        {
            cage = new FemaleBearCageFactory().CreateCage() as BearFemaleCage;
            bear = new BearFactory().CreateAnimal() as Bear;
        }

        [Fact]
        public void Add_WhenAddFemaleBear_ReturnsTrue()
        {
            bear.Male = Lab2Zoo.Models.Enums.MaleMode.Female;
            cage.Add(bear);

            Assert.NotEmpty(cage.Components);
            Assert.NotEmpty(cage.GetAnimals());
            Assert.Equal(bear, cage.Components[0]);
        }

        [Fact]
        public void Add_WhenAddMaleBear_ReturnsTrue()
        {
            bear.Male = Lab2Zoo.Models.Enums.MaleMode.Male;
            cage.Add(bear);

            Assert.Empty(cage.Components);
            Assert.Empty(cage.GetAnimals());
        }
    }
}
