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
            bear = new BearFactory().CreateAnimal(Lab2Zoo.Models.Enums.MaleMode.Female) as Bear;            
        }

        [Fact]
        public void Add_WhenAddFemaleBear_ReturnsTrue()
        {            
            cage.Add(bear);

            Assert.NotEmpty(cage.Components);
            Assert.NotEmpty(cage.GetAnimals());
            Assert.Equal(bear, cage.Components[0]);
        }

        [Fact]
        public void Add_WhenAddMaleBear_ReturnsTypeAccesException()
        {
            bear.Male = Lab2Zoo.Models.Enums.MaleMode.Male;

            Assert.Throws<TypeAccessException>(() => cage.Add(bear));

            Assert.Empty(cage.Components);
            Assert.Empty(cage.GetAnimals());
        }

        [Fact]
        public void Add_WhenAddFemaleBearCage_ReturnsTrue()
        {
            BearFemaleCage innerCage = new FemaleBearCageFactory().CreateCage() as BearFemaleCage;
            cage.Add(innerCage);
            
            innerCage.Add(bear);

            Assert.NotEmpty(cage.Components);
            Assert.Equal(bear, cage.GetAnimals()[0]);            
        }
    }
}
