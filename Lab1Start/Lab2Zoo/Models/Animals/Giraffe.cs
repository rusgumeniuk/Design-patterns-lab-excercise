using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models.Animals
{
    public class Giraffe : Animal
    {
        private byte age = 0;
        public byte Age
        {
            get => age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("'" + value + "' can not be age");
                else
                    age = value;
            }
        }

        public override string Voice()
        {
            return "Huuum";
        }
    }
}