﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Zoo.Models.Animals
{
    public class WhiteWolf : Wolf
    {
        public override string Voice()
        {
            return base.Voice() + "auuu";
        }
    }
}