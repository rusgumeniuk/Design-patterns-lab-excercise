﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Zoo.Models
{
    class Base
    {
        public Guid Id { get; private set; }
        public Base()
        {
            Id = Guid.NewGuid();
        }
    }
}
