using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indexer.IndexerFolder;
using Exceptions.ExceptionsFolder;

namespace GunSimulator.Models
{
    public abstract class Guns : Base
    {
        public static Indexer<AssaultRifle> AssaultRifles { get; protected set; }
        public static Indexer<Pistol> Pistols { get; protected set; }
        public static Indexer<Smg> SmgRifles { get; protected set; }
        public static Indexer<Sniper> SniperRifles { get; protected set; }

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
                    throw new NotAcceptableInput("You entered not a number! Please enter number!");
                }
                _capacity = value;
            }
        }

        static Guns()
        {
            AssaultRifles = new Indexer<AssaultRifle>();
            Pistols = new Indexer<Pistol>();
            SmgRifles = new Indexer<Smg>();
            SniperRifles = new Indexer<Sniper>();
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

        private Guns()
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press 'Q' for back to <Main Menu>\n");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press 'Q' for back to <Main Menu>\n");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press 'Q' for back to <Main Menu>\n");
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
