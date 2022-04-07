﻿using GunSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunSimulator.Models
{
    public class Pistol : Guns, ISingleShot, IBurstShot
    {
        public Pistol(string name, int capacity) : base(name, capacity)
        {
        }
    }
}