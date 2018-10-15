using System;
using Xunit;

using Lab2Zoo.Models;
using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Cages.BearCages;
using Lab2Zoo.Models.Factories.AnimalFactories;
using Lab2Zoo.Models.Factories.CageFactories.BearCageFactory;

namespace ZooXUnitTestProject.TestClasses.ContainersTestClasses
{
    public class ContainerTest
    {
        #region Start
        readonly Zoo zoo;

        readonly BearCageFactory bearCageFactory;
        readonly FemaleBearCageFactory bearFemaleCageFactory;
        readonly MaleBearCageFactory bearMaleCageFactory;

        readonly BearCage mainBearCage;
        readonly BearMaleCage bearMaleCage;
        readonly BearFemaleCage bearFemaleCage;

        readonly BearFactory bearFactory;
        readonly GiraffeFactory giraffeFactory;
        readonly Bear maleBear;
        readonly Bear femaleBear;
        readonly Giraffe giraffe;


        public ContainerTest()
        {
            zoo = new Zoo();

            bearCageFactory = new BearCageFactory();
            bearFemaleCageFactory = new FemaleBearCageFactory();
            bearMaleCageFactory = new MaleBearCageFactory();

            bearFactory = new BearFactory();
            giraffeFactory = new GiraffeFactory();

            mainBearCage = bearCageFactory.CreateCage() as BearCage;
            bearFemaleCage = bearFemaleCageFactory.CreateCage() as BearFemaleCage;
            bearMaleCage = bearMaleCageFactory.CreateCage() as BearMaleCage;

            maleBear = bearFactory.CreateAnimal(Lab2Zoo.Models.Enums.MaleMode.Male) as Bear;
            femaleBear = bearFactory.CreateAnimal(Lab2Zoo.Models.Enums.MaleMode.Female) as Bear;

            giraffe = giraffeFactory.CreateAnimal(15) as Giraffe;

            zoo.Add(bearMaleCage);
            zoo.Add(mainBearCage);
            mainBearCage.Add(bearFemaleCage);
        }
        #endregion

        #region IsContainerCanContainsComponent
        [Fact]
        public void IsContainerCanContainsComponent_WhenCompIsBears_ReturnsTrue()
        {
            Assert.True(mainBearCage.IsContainerCanContainsComponent(maleBear));
            Assert.True(bearFemaleCage.IsContainerCanContainsComponent(femaleBear));
        }

        [Fact]
        public void IsContainerCanContainsComponent_WhenCompIsGiraffe_ReturnsFalse()
        {
            Assert.False(zoo.IsContainerCanContainsComponent(giraffe));
            Assert.False(mainBearCage.IsContainerCanContainsComponent(giraffe));
        }

        [Fact]
        public void IsContainerCanContainsComponent_WhenComponentIsCage_ReturnsTrue()
        {
            Assert.True(zoo.IsContainerCanContainsComponent(bearCageFactory.CreateCage() as BearCage));
            Assert.True(bearMaleCage.IsContainerCanContainsComponent(bearMaleCageFactory.CreateCage() as BearMaleCage));
        }

        [Fact]
        public void IsContainerCanContainsComponent_WhenComponentIsZoo_ReturnFalse()
        {
            Assert.False(zoo.IsContainerCanContainsComponent(new Zoo()));
        }
        #endregion

        #region IsChildCanContainsAnimal
        [Fact]
        public void IsChildCanContainsAnimal_WhenCanContain_ReturnsTrue()
        {
            Assert.True(zoo.IsChildCanContainsAnimal(maleBear));
            Assert.True(zoo.IsChildCanContainsAnimal(femaleBear));
        }

        [Fact]
        public void IsChildCanContainsAnimal_WhenCanNotContain_ReturnsFalse()
        {
            Assert.False(zoo.IsChildCanContainsAnimal(giraffe));
        }
        #endregion

        #region GetContainerForAnimal
        [Fact]
        public void GetContainerForAnimal_WhenAnimalIsMaleBear_ReturnsTrue()
        {
            Container maleBearContainer = zoo.GetContainerForAnimal(maleBear);

            Assert.NotNull(maleBearContainer);
            Assert.Equal(bearMaleCage, maleBearContainer);
        }

        [Fact]
        public void GetContainerForAnimal_WhenAnimalIsFemaleBear_ReturnsTrue()
        {
            Container femaleBearContainer = zoo.GetContainerForAnimal(femaleBear);

            Assert.NotNull(femaleBearContainer);
            Assert.Equal(bearFemaleCage, femaleBearContainer);
        }

        [Fact]
        public void GetContainerForAnimal_WhenAnimalIsGiraffe_ReturnsNull()
        {
            Container container = zoo.GetContainerForAnimal(giraffe);

            Assert.Null(container);
        }
        #endregion     

        #region GetAverageWeight
        [Fact]
        public void GetAverageWeight_WhenEmptyZoo_ReturnMinus1()
        {
            Assert.Equal(-1, zoo.GetAverageWeight());
        }

        [Fact]
        public void GetAverageWeight_When1Animal_ReturnsTrue()
        {
            bearMaleCage.Add(maleBear);
            maleBear.Weight = 20;
            Assert.Equal(20, zoo.GetAverageWeight());
        }

        [Fact]
        public void GetAverageWeight_When2Animals_ReturnsTrue()
        {
            bearMaleCage.Add(maleBear);
            bearFemaleCage.Add(femaleBear);
            maleBear.Weight = 25;
            femaleBear.Weight = 15;
            Assert.Equal(20, zoo.GetAverageWeight());
            
        }
        #endregion
    }
}
