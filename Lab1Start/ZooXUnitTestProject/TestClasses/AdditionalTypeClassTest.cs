using System;
using Xunit;

using Lab2Zoo.Models;

namespace ZooXUnitTestProject.TestClasses
{
    public class AdditionalTypeClassTest
    {
        [Fact]
        public void GetBaseTypes_WhenItemHasNotBaseType_ReturnsNull()
        {
            Assert.Null(typeof(object).GetBaseTypes());
        }

        [Fact]
        public void GetBaseTypes_WhenItemHas1BaseType_ReturnsTrue()
        {
            Assert.Equal(2, typeof(string).GetBaseTypes().Length);
        }

        [Fact]
        public void GetBaseTypes_WhenZoo_ReturnsTrue()
        {   //obj <- component <- container <- zoo
            Assert.Equal(4, new Zoo().GetType().GetBaseTypes().Length);
            Assert.Contains(typeof(Component), typeof(Zoo).GetBaseTypes());
            Assert.Contains(typeof(Zoo), typeof(Zoo).GetBaseTypes());
        }
    }
}
