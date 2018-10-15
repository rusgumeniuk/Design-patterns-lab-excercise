using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;
using Lab2Zoo.Models.Cages.BearCages;

namespace ZooXUnitTestProject.TestClasses.CagesTestClasses.BearCagesTestClasses
{
    public class BearCageTestClass
    {
        readonly BearCage mainBearCage;
        readonly BearCage innerCage;
        readonly BearFemaleCage femaleCage;
        readonly BearMaleCage maleCage;

        readonly Bear bear;

        public BearCageTestClass()
        {            
            mainBearCage = new BearCageFactory().CreateCage() as BearCage;
            innerCage = new BearCageFactory().CreateCage() as BearCage;
            femaleCage = new FemaleBearCageFactory().CreateCage() as BearFemaleCage;
            maleCage = new MaleBearCageFactory().CreateCage() as BearMaleCage;

            bear = new BearFactory().CreateAnimal() as Bear;
        }

        [Fact]
        public void Add_WhenAddAnimalToRandomCage_ReturnsTrue()
        {
            mainBearCage.Add(innerCage);
            mainBearCage.Add(maleCage);
            innerCage.Add(femaleCage);

            bear.Male = Lab2Zoo.Models.Enums.MaleMode.Female;

            Lab2Zoo.Models.Container container = mainBearCage.GetContainerForAnimal(bear);

            Assert.Equal(femaleCage, container);
        }
    }
}
