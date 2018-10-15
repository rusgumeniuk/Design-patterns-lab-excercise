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
        public override bool IsContainerCanContainsContainer(Container innerContainer)
        {
            return innerContainer.GetType().GetBaseTypes().Contains(this.GetType());
        }  
        
        public override string Voice()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in Components)
            {
                if (item is Animal && (item as Animal).IsSleeping)
                    stringBuilder.Append((item as Animal).WakeUp());
                stringBuilder.AppendLine(item.Voice());
            }
            return stringBuilder.Length > 0 ? stringBuilder.ToString() : "Empty cage " + Id; 
        }
    }
}