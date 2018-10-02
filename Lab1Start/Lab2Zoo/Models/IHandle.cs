using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab2Zoo.Models;

namespace Lab2Zoo.Models
{
    public interface IHandle
    {
        void SetNext(Component component);

        object Handle(object component);
    }
}