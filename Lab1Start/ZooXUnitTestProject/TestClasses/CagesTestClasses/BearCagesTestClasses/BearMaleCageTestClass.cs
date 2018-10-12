using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;
using Lab2Zoo.Models.Cages.BearCages;

namespace ZooXUnitTestProject.TestClasses.CagesTestClasses.BearCagesTestClasses
{
    public class BearMaleCageTestClass
    {
        readonly BearMaleCage cage;
        readonly Bear bear;

        public BearMaleCageTestClass()
        {
            cage = new MaleBearCageFactory().CreateCage() as BearMaleCage;
            bear = new BearFactory().CreateAnimal(Lab2Zoo.Models.Enums.MaleMode.Male) as Bear;
        }

        [Fact]
        public void Add_WhenAddMaleBear_ReturnsTrue()
        {            
            cage.Add(bear);

            Assert.NotEmpty(cage.Components);
            Assert.NotEmpty(cage.GetAnimals());
            Assert.Equal(bear, cage.Components[0]);
        }

        [Fact]
        public void Add_WhenAddFemaleBear_ReturnsTypeAccesException()
        {
            bear.Male = Lab2Zoo.Models.Enums.MaleMode.Female;

            Assert.Throws<TypeAccessException>(() => cage.Add(bear));

            Assert.Empty(cage.Components);
            Assert.Empty(cage.GetAnimals());
        }

        [Fact]
        public void Add_WhenAddMaleBearCage_ReturnsTrue()
        {
            BearMaleCage innerCage = new MaleBearCageFactory().CreateCage() as BearMaleCage;
            cage.Add(innerCage);
            
            innerCage.Add(bear);

            Assert.NotEmpty(cage.Components);
            Assert.Equal(bear, cage.GetAnimals()[0]);
        }
    }
}
