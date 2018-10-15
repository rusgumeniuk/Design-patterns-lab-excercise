using System;
using Xunit;

using Lab2Zoo.Models.Animals;
using Lab2Zoo.Models.Factories.AnimalFactories;

namespace ZooXUnitTestProject.TestClasses.AnimalTestClasses
{
    public class AnimalTestClass
    {
        readonly GreyWolfFactory greyWolfFactory;
        readonly GreyWolf greyWolf;

        public AnimalTestClass()
        {
            greyWolfFactory = new GreyWolfFactory();
            greyWolf = greyWolfFactory.CreateAnimal() as GreyWolf;
        }

        #region Name       
        [Fact]
        public void Name_WhenChangeNameOnNull_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => greyWolf.Name = null);
        }

        [Fact]
        public void Name_WhenChangeNameOnEmptyString_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => greyWolf.Name = String.Empty);
        }

        [Fact]
        public void Name_WhenSetNullNameInCreatingProccess_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => greyWolfFactory.CreateAnimal().Name = null);
        }

        [Fact]
        public void Name_WhenSetRealString_ReturnsTrue()
        {
            string newName = "NameTest";
            greyWolf.Name = newName;
            Assert.Equal(newName, greyWolf.Name);
        }
        #endregion

        #region Weight
        [Fact]
        public void Weight_WhenSetZeroWeight_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => greyWolf.Weight = 0);
        }

        [Fact]
        public void Weight_WhenSet50Weight_ReturnsTrue()
        {
            int weight = 50;
            ushort convertedWeight = Convert.ToUInt16(weight);
            greyWolf.Weight = convertedWeight;
            Assert.Equal(weight, greyWolf.Weight);
        }
        #endregion

        [Fact]
        public void Add_ReturnsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => greyWolf.Add(greyWolf));
        }

        [Fact]
        public void Remove_ReturnsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => greyWolf.Remove(greyWolf));
        }

        [Fact]
        public void GetAnimals_ReturnsListWithItself()
        {
            var result = greyWolf.GetAnimals();

            Assert.Single(result);
            Assert.Equal(greyWolf, result[0]);
        }

        [Fact]
        public void GetAmountOfAnimals_Returns1()
        {
            Assert.Equal(1, greyWolf.GetAmountOfAnimals());
        }

        [Fact]
        public void GetWeight_ReturnsTrue()
        {
            Assert.Equal(greyWolf.Weight, greyWolf.GetWeight());
        }
    }
}
