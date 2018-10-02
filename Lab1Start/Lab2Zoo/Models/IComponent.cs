using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models
{
    public interface IComponent
    {
        void Add(Component component);
        Component GetChild(int index);
        string Voice();
        int GetWeight();
        void Remove(Component component);
    }
}