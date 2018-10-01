using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models
{
    public class BaseEntity
    {
        public readonly Guid Id;

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}