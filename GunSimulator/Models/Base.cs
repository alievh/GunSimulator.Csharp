using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunSimulator.Models
{
    public abstract class Base
    {
        private static int _idCounter;

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateTime { get; set; }

        static Base()
        {
            _idCounter = 0;
        }

        public Base()
        {
            Id = ++_idCounter;
            CreateTime = DateTime.Now;
        }

        public Base(string name) : this()
        {
            Name = name;
            IsDeleted = false;
    }

        public abstract string FullInfo();
        public abstract string Info();
    }
}
