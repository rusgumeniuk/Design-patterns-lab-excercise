using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Zoo.Models.Cages
{
    abstract class Cage<T> : Base
        where T : Animal
    {
        public List<T> Animals = new List<T>();
        public List<Cage<T>> Cages = new List<Cage<T>>();
    }
}
