using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models.Animals
{
    public class Giraffe : Animal
    {
        private byte age = 1;
        public byte Age
        {
            get => age;
            set
            {
                if (value < 1)
                    throw new ArgumentException("'" + value + "' can not be age");
                else
                    age = value;
            }
        }

        internal Giraffe() : base() { }
        internal Giraffe(byte age) : this() { Age = age; }

        public override string Voice()
        {
            return Id + ": Huuum";
        }
    }
}