using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Zoo.Models
{
    abstract class Animal : Base, IAnimal
    {
        private ushort weight = 0;        

        public ushort Weight
        {
            get => weight;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Weight should be non-negative");
                weight = value;
            }
        }
        public string Name { get; set; }
        public bool IsSleeping { get; set; }

        public void WakeUp()
        {
            IsSleeping = false;
        }
        public abstract string Voice();        
    }
}
