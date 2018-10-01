using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models
{
    public interface IComponent
    {
        void Add(IComponent component);
        IComponent GetChild(int index);
        string Voice();
        void Remove(IComponent component);
    }
}