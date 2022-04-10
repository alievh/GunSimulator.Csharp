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
        private int _currentBulletCount;

        public int Capacity 
        { 
            get
            {
                return _capacity;
            } 
            set
            {
                if (value <= 0 && value >= 200)
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

        public Guns()
        {

        }

        public Guns(string name, int capacity, int currentBullet) : base(name)
        {
            Capacity = capacity;
            CurrentBulletCount = currentBullet;
        }

        public override string Info()
        {
            return $"Id: {Id} - Name: {Name}, Capacity: {Capacity}";
        }

        public override string FullInfo()
        {
            return $"Id: {Id} - Name: {Name}, Ammo Capacity: {Capacity}, CreateTime: {CreateTime}";
        }

        /// <summary>
        /// Reloading ammo
        /// </summary>
        public void Reload()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CurrentBulletCount = Capacity;
            Console.WriteLine("<= Gun Reloaded! You can use your gun now =>");
        }

        public static void PrintSingleShooter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"            ||||||||||||||
           =              \       ,
           =               |
          _=            ___/
         / _\           (o)\
        | | \            _  \
        | |/            (____)
         \__/          /   |
          /           /  ___)
         /    \       \    _)                       )
        \      \           /                       (
      \/ \      \_________/   |\_________________,_ )
       \/ \      /            |     ==== _______)__)       =>
        \/ \    /           __/___  ====_/
         \/ \  /           (O____)\\_(_/
                          (O_ ____)
                           (O____)");
        }

        public static void PrintBurstShooter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"            ||||||||||||||
           =              \       ,
           =               |
          _=            ___/
         / _\           (o)\
        | | \            _  \
        | |/            (____)
         \__/          /   |
          /           /  ___)
         /    \       \    _)                       )
        \      \           /                       (
      \/ \      \_________/   |\_________________,_ )           =>
       \/ \      /            |     ==== _______)__)       =>        =>
        \/ \    /           __/___  ====_/
         \/ \  /           (O____)\\_(_/
                          (O_ ____)
                           (O____)");
        }

        public static void PrintAutoShooter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"            ||||||||||||||
           =              \       ,
           =               |
          _=            ___/
         / _\           (o)\
        | | \            _  \
        | |/            (____)
         \__/          /   |
          /           /  ___)
         /    \       \    _)                       )
        \      \           /                       (
      \/ \      \_________/   |\_________________,_ )           =>        =>
       \/ \      /            |     ==== _______)__)       =>        =>
        \/ \    /           __/___  ====_/
         \/ \  /           (O____)\\_(_/
                          (O_ ____)
                           (O____)");
        }
    }
}
