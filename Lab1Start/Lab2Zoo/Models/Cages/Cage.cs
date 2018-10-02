using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models.Animals;

namespace Lab2Zoo.Models.Cages
{
    public abstract class Cage<T> : Container
        where T : Animal
    {
        public override string Voice()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var component in Components)
            {
                stringBuilder.AppendLine(component.Voice());
            }
            return stringBuilder.Length > 0 ? stringBuilder.ToString() : "Empty cage " + Id; 
        }
    }
}