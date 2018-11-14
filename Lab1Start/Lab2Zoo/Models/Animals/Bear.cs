using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Enums;

namespace Lab2Zoo.Models.Animals
{
    public class Bear : Animal
    {
        public MaleMode Male = MaleMode.Female;
        
        internal Bear() : base() { }
        internal Bear(MaleMode male) : this() { Male = male; }

        public override string Voice()
        {
            return Id +  ": Grrrrr";
        }

        public override string ToString()
        {
            return base.ToString() + " male is " + Male;
        }
    }
}