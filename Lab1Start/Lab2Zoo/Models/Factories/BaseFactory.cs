using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models.Factories
{
    public abstract class BaseFactory
    {
        public abstract BaseEntity CreateNewObject();
    }
}