﻿using GunSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunSimulator.Models
{
    public class Sniper : Guns, ISingleShot
    {
        public Sniper(string name, int capacity) : base(name, capacity)
        {
        }
    }
}
