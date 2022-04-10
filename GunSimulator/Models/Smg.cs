﻿using GunSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunSimulator.Models
{
    public class Smg : Guns, ISingleShot, IAutoShot
    {
        public Smg(string name, int capacity, int currentBullet) : base(name, capacity, currentBullet)
        {
        }

        public void ReduceAutoAmmo()
        {
            if (CurrentBulletCount > 0)
            {
                CurrentBulletCount = 0;
                Console.WriteLine($"\nYour Gun: {Name} Ammo Count: {CurrentBulletCount}/{Capacity}");
            }
            else
            {
                Console.WriteLine("-You don't have enough ammo press 'R' for reload-");
            }
        }

        public void ReduceSingleAmmo()
        {
            if (CurrentBulletCount > 0)
            {
                CurrentBulletCount -= 1;
                Console.WriteLine($"\nYour Gun: {Name} Ammo Count: {CurrentBulletCount}/{Capacity}");
            }
            else
            {
                Console.WriteLine("-You don't have enough ammo press 'R' for reload-");
            }
        }
    }
}
