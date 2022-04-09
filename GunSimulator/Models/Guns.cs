using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunSimulator.Models
{
    public class Guns : Base
    {
        private int _capacity;
        private static int _currentBulletCount;

        public int Capacity 
        { 
            get
            {
                return _capacity;
            } 
            set
            {
                if (value <= 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _capacity = value;
            }
        }
        public int CurrentBulletCount 
        {
            get
            {
                return _currentBulletCount;
            }
            set
            {
                _currentBulletCount = value;
            }
        }

        static Guns()
        {
            _currentBulletCount = 25;
        }

        public Guns()
        {

        }

        public Guns(string name, int capacity) : base(name)
        {
            Capacity = capacity;
        }

        public override string Info()
        {
            return $"Id: {Id} - Name: {Name}";
        }

        public override string FullInfo()
        {
            return $"Id: {Id} - Name: {Name}, Ammo Capacity: {Capacity}";
        }

        public void Reload()
        {
            CurrentBulletCount = Capacity;
        }
    }
}
