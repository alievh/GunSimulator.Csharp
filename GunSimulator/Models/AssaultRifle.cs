using GunSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunSimulator.Models
{
    public class AssaultRifle : Guns, ISingleShot, IBurstShot, IAutoShot
    {

        public AssaultRifle(string name, int capacity) : base(name, capacity)
        {

        }
    }
}
