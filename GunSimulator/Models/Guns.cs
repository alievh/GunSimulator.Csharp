using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunSimulator.Models
{
    public class Guns : Base
    {

        public int Capacity { get; set; }
        public int CurrentBulletCount { get; set; }

        public Guns()
        {

        }

        public Guns(string name, int capacity) : base(name)
        {

        }

        public override string Info()
        {
            return $"Id: {Id} - Name: {Name}";
        }

        public override string FullInfo()
        {
            return $"Id: {Id} - Name: {Name}, ";
        }
    }
}
