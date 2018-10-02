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
        
        public override string Voice()
        {
            return "Grrrrr";
        }
    }
}