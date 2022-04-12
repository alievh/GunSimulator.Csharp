﻿using GunSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunSimulator.Models
{
    public class AssaultRifle : Guns, ISingleShot, IBurstShot, IAutoShot
    {
        public AssaultRifle(string name, int capacity, int currentBullet) : base(name, capacity, currentBullet)
        {
            AssaultRifles.Add(this);
        }

        /// <summary>
        /// Reducing all ammo in one shot
        /// </summary>
        public void ReduceAutoAmmo()
        {
            if (CurrentBulletCount > 0)
            {
                Console.Clear();
                CurrentBulletCount = 0;
                PrintAutoShooter();
                Console.WriteLine($"\nYour Gun: {Name} Ammo Count: {CurrentBulletCount}/{Capacity}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<= You don't have enough ammo press 'R' for reload =>");
            }
        }

        /// <summary>
        /// Reducing Ammo 3 time in one shot
        /// </summary>
        public void ReduceBurstAmmo()
        {
            if (CurrentBulletCount - 3 >= 0)
            {
                Console.Clear();
                CurrentBulletCount -= 3;
                PrintBurstShooter();
                Console.WriteLine($"\nYour Gun: {Name} Ammo Count: {CurrentBulletCount}/{Capacity}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<= You don't have enough ammo press 'R' for reload =>");
            }
        }

        /// <summary>
        /// Reducing Ammo count one by one
        /// </summary>
        public void ReduceSingleAmmo()
        {
            if (CurrentBulletCount > 0)
            {
                Console.Clear();
                CurrentBulletCount -= 1;
                PrintSingleShooter();
                Console.WriteLine($"\nYour Gun: {Name} Ammo Count: {CurrentBulletCount}/{Capacity}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<= You don't have enough ammo press 'R' for reload =>");
            }
        }

    }
}
