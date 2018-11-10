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
            zoo = Lab2Zoo.Models.Factories.ZooFactory.CreateZoo();

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

        #region Add
        [Fact]
        public void Add_WhenCageAlreadyInZoo_ReturnsArgumentException()
        {
            Assert.Throws<TypeAccessException>(() => zoo.Add(mainBearCage));
        }

        [Fact]
        public void Add_WhenBearAlreadyInCage_ReturnsArgumentException()
        {
            bearMaleCage.Add(maleBear);
            Assert.Throws<TypeAccessException>(() => bearMaleCage.Add(maleBear));
        }

        [Fact]
        public void Add_WhenAddMaleBeartoFemaleCage_ReturnsTypeAccessException()
        {
            Assert.Throws<TypeAccessException>(() => bearFemaleCage.Add(maleBear));
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
            Assert.False(zoo.IsContainerCanContainsComponent(Lab2Zoo.Models.Factories.ZooFactory.CreateZoo()));
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

        #region GetAmountOfAnimals
        [Fact]
        public void GetAmountOfAnimals_WhenEmptyZoo_ReturnsTrue()
        {
            Assert.Equal(0, zoo.GetAmountOfAnimals());
        }

        [Fact]
        public void GetAmountOfAnimals_When1Animal_ReturnsTrue()
        {
            bearMaleCage.Add(maleBear);
            Assert.Equal(1, zoo.GetAmountOfAnimals());
        }

        [Fact]
        public void GetAmountOfAnimals_When2Animals_ReturnsTrue()
        {
            bearFemaleCage.Add(femaleBear);
            bearMaleCage.Add(maleBear);

            Assert.Equal(2, zoo.GetAmountOfAnimals());
            Assert.Equal(1, mainBearCage.GetAmountOfAnimals());
            Assert.Equal(1, bearMaleCage.GetAmountOfAnimals());

        }
        #endregion

        #region GetWeight
        [Fact]
        public void GetWeight_WhenEmptyZoo_ReturnsTrue()
        {
            Assert.Equal(0, zoo.GetWeight());
        }

        [Fact]
        public void GetWeight_When1Animal_ReturnsTrue()
        {
            bearMaleCage.Add(maleBear);
            maleBear.Weight = 20;

            Assert.Equal(20, zoo.GetWeight());
        }

        [Fact]
        public void GetWeight_When2Animals_ReturnsTrue()
        {
            bearFemaleCage.Add(femaleBear);
            bearMaleCage.Add(maleBear);

            femaleBear.Weight = 100;
            maleBear.Weight = 160;

            Assert.Equal(260, zoo.GetWeight());
            Assert.Equal(100, mainBearCage.GetWeight());
            Assert.Equal(160, bearMaleCage.GetWeight());

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

        #region GetAnimals
        [Fact]
        public void GetAnimals_WhenEmptyZoo_ReturnsTrue()
        {
            Assert.Empty(zoo.GetAnimals());
        }

        [Fact]
        public void GetAnimals_When1Animal_ReturnsTrue()
        {
            bearMaleCage.Add(maleBear);

            Assert.Equal(maleBear, zoo.GetAnimals()[0]);
        }

        [Fact]
        public void GetAnimals_When2Animals_ReturnsTrue()
        {
            bearFemaleCage.Add(femaleBear);
            bearMaleCage.Add(maleBear);

            Assert.Equal(2, zoo.GetAnimals().Length);
            Assert.Contains(maleBear, zoo.GetAnimals());
        }
        #endregion        
    }
}
