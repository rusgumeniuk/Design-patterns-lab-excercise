using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models.Factories
{
    public abstract class BaseFactory<T> : BaseEntity
        where T : BaseEntity
    {
        public abstract T CreateNewObject();
    }
}