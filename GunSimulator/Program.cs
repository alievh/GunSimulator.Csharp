using GunSimulator.Models;
using Indexer.IndexerFolder;
using System;

namespace GunSimulator
{
    public class Program
    {
        static void Main(string[] args)
        {

            Menu();
        }

        public static void Menu()
        {
            #region CreatedAssaultRifles
            Indexer<AssaultRifle> assaultRifles = new Indexer<AssaultRifle>();

            assaultRifles.Add(new AssaultRifle("Famas", 25));
            assaultRifles.Add(new AssaultRifle("M4A4", 30));
            assaultRifles.Add(new AssaultRifle("AK-47", 25));
            assaultRifles.Add(new AssaultRifle("M4A1-S", 25));
            assaultRifles.Add(new AssaultRifle("AUG", 30));
            #endregion
            #region CreatedPistols
            Indexer<Pistol> pistols = new Indexer<Pistol>();

            pistols.Add(new Pistol("Glock-18", 25));
            pistols.Add(new Pistol("P250", 30));
            pistols.Add(new Pistol("Five-Seven", 25));
            pistols.Add(new Pistol("DesertEagle", 25));
            pistols.Add(new Pistol("DualBarettas", 30));
            #endregion
            #region CreatedSmg
            Indexer<Smg> smg = new Indexer<Smg>();

            smg.Add(new Smg("MP7", 25));
            smg.Add(new Smg("MP9", 30));
            smg.Add(new Smg("UMP-45", 25));
            smg.Add(new Smg("P90", 25));
            smg.Add(new Smg("PP-Bizon", 30));
            #endregion
            #region CreatedSniper
            Indexer<Sniper> sniper = new Indexer<Sniper>();

            sniper.Add(new Sniper("AWP", 25));
            sniper.Add(new Sniper("SSG 08", 30));
            sniper.Add(new Sniper("SCAR-20", 25));
            #endregion


            PrintPoster();
        START:
            Console.WriteLine("Press 1 - Use exist weapon\n" +
                              "Press 2 - Create new weapon\n" +
                              "Press 3 - Remove exist weapon\n" +
                              "Press 0 - Exit\n");
            Console.Write("Enter your answer: ");
            string menuIputString = Console.ReadLine();
            int menuInput;
            try
            {
                menuInput = Convert.ToInt32(menuIputString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!\n" +
                                  "Please try again\n");
                goto START;
            }

            switch (menuInput)
            {
                case 1:

                    switch (UseCreateRemove("use"))
                    {
                        case 1:
                            Console.Clear();
                        USE1:
                            for (int i = 0; i < assaultRifles.Length; i++)
                            {
                                Console.WriteLine(assaultRifles[i].FullInfo());
                            }
                            Console.WriteLine("\nPress 0 for Go Back");
                            string usingGunInputString = Console.ReadLine();
                            int? usingGunInput = null;
                            try
                            {
                                usingGunInput = Convert.ToInt32(usingGunInputString);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid Input!\n" +
                                                  "Please TryAgain!");
                                goto USE1;
                            }
                            switch (usingGunInput)
                            {
                                case 1:
                                SHOOTMODE1:
                                    Console.WriteLine("Select shooting mode: 1 - Single Mode | 2 - Burst Mode | 3 - Auto Mode");
                                    Console.Write("Your answer: ");
                                    string shootingModeString = Console.ReadLine();
                                    int? shootingMode = null;
                                    try
                                    {
                                        shootingMode = Convert.ToInt32(shootingModeString);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Invalid Input!\n" +
                                                          "Please TryAgain!");
                                        goto SHOOTMODE1;
                                    }
                                    PrintShotSection();
                                    SHOOTMODE2:
                                    ConsoleKeyInfo userInput = Console.ReadKey();
                                    switch (shootingMode)
                                    {
                                        case 1:
                                            switch (userInput.Key)
                                            {
                                                case ConsoleKey.Enter:
                                                    assaultRifles[0].ReduceSingleAmmo();
                                                    break;
                                                case ConsoleKey.R:
                                                    assaultRifles[0].Reload();
                                                    break;
                                                case ConsoleKey.Q:
                                                    Console.Clear();
                                                    goto START;
                                            }
                                            goto SHOOTMODE2;
                                        case 2:
                                            switch (userInput.Key)
                                            {
                                                case ConsoleKey.Enter:
                                                    assaultRifles[0].ReduceBurstAmmo();
                                                    break;
                                                case ConsoleKey.R:
                                                    assaultRifles[0].Reload();
                                                    break;
                                                case ConsoleKey.Q:
                                                    Console.Clear();
                                                    goto START;
                                            }
                                            goto SHOOTMODE2;
                                        case 3:
                                            switch (userInput.Key)
                                            {
                                                case ConsoleKey.Enter:
                                                    assaultRifles[0].ReduceAutoAmmo();
                                                    break;
                                                case ConsoleKey.R:
                                                    assaultRifles[0].Reload();
                                                    break;
                                                case ConsoleKey.Q:
                                                    Console.Clear();
                                                    goto START;
                                            }
                                            goto SHOOTMODE2;
                                        default:
                                            Console.WriteLine("Invalid Input!\n" +
                                                              "Please TryAgain!");
                                            goto SHOOTMODE1;
                                    }
                            }

                            break;
                        case 2:
                            Console.Clear();
                            for (int i = 0; i < pistols.Length; i++)
                            {
                                Console.WriteLine(pistols[i].FullInfo());
                            }
                            Console.WriteLine("\nPress 0 for Go Back");
                            break;
                        case 3:
                            Console.Clear();
                            for (int i = 0; i < smg.Length; i++)
                            {
                                Console.WriteLine(smg[i].FullInfo());
                            }
                            Console.WriteLine("\nPress 0 for Go Back");
                            break;
                        case 4:
                            Console.Clear();
                            for (int i = 0; i < sniper.Length; i++)
                            {
                                Console.WriteLine(sniper[i].FullInfo());
                            }
                            Console.WriteLine("\nPress 0 for Go Back");
                            break;
                        case 0:
                            Console.Clear();
                            goto START;
                    }
                    break;
                case 2:
                    switch (UseCreateRemove("create"))
                    {
                        case 1:
                            string assaultName = GunsNameCreatedByUser();
                            int assaultCapacity = GunsCapacityCreatedByUser();

                            assaultRifles.Add(new AssaultRifle(assaultName, assaultCapacity));
                            goto START;
                        case 2:
                            string pistolName = GunsNameCreatedByUser();
                            int pistolCapacity = GunsCapacityCreatedByUser();

                            pistols.Add(new Pistol(pistolName, pistolCapacity));
                            goto START;
                        case 3:
                            string smgName = GunsNameCreatedByUser();
                            int smgCapacity = GunsCapacityCreatedByUser();

                            smg.Add(new Smg(smgName, smgCapacity));
                            goto START;
                        case 4:
                            string sniperName = GunsNameCreatedByUser();
                            int sniperCapacity = GunsCapacityCreatedByUser();

                            sniper.Add(new Sniper(sniperName, sniperCapacity));
                            goto START;
                        case 0:
                            Console.Clear();
                            goto START;
                    }
                    break;
                case 3:
                    switch (UseCreateRemove("remove"))
                    {
                        case 1:
                        Remove1:
                            Console.Clear();
                            for (int i = 0; i < assaultRifles.Length; i++)
                            {
                                Console.WriteLine(assaultRifles[i].FullInfo());
                            }
                            Console.WriteLine("\nPress 0 for Go Back");
                            Console.Write("\nSelect ID which you want to delete: ");
                            string assaultRemoveIdString = Console.ReadLine();
                            int? assaultRemoveId = null;
                            try
                            {
                                assaultRemoveId = Convert.ToInt32(assaultRemoveIdString);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid value!\n" +
                                                  "Please try again!");
                                goto Remove1;
                            }
                            int assaultLoopCount = 0;
                            for (int i = 0; i < assaultRifles.Length; i++)
                            {
                                if (assaultRemoveId == assaultRifles[i].Id)
                                {
                                    assaultRifles.Remove(assaultRifles[assaultLoopCount]);
                                    Console.WriteLine("Selected gun removed!");
                                    goto START;

                                }
                                assaultLoopCount++;

                            }
                            if (assaultRemoveId == 0)
                            {
                                goto START;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID!\n" +
                                                  "Please try again!");
                                goto Remove1;
                            }
                        case 2:
                            Console.Clear();
                        Remove2:
                            for (int i = 0; i < pistols.Length; i++)
                            {
                                Console.WriteLine(pistols[i].FullInfo());
                            }
                            Console.WriteLine("\nPress 0 for Go Back");
                            Console.Write("\nSelect ID which you want to delete: ");
                            string pistolRemoveIdString = Console.ReadLine();
                            int? pistolRemoveId = null;
                            try
                            {
                                pistolRemoveId = Convert.ToInt32(pistolRemoveIdString);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid value!\n" +
                                                  "Please try again!");
                                goto Remove2;
                            }
                            int pistolLoopCount = 0;
                            for (int i = 0; i < pistols.Length; i++)
                            {
                                if (pistolRemoveId == pistols[i].Id)
                                {
                                    pistols.Remove(pistols[pistolLoopCount]);
                                    Console.WriteLine("Selected gun removed!");
                                    goto START;
                                }
                                pistolLoopCount++;

                            }
                            if (pistolRemoveId == 0)
                            {
                                goto START;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID!\n" +
                                                  "Please try again!");
                                goto Remove2;
                            }

                        case 3:
                            Console.Clear();
                        Remove3:
                            for (int i = 0; i < smg.Length; i++)
                            {
                                Console.WriteLine(smg[i].FullInfo());
                            }
                            Console.WriteLine("\nPress 0 for Go Back");
                            Console.Write("\nSelect ID which you want to delete: ");
                            string smgRemoveIdString = Console.ReadLine();
                            int? smgRemoveId = null;
                            try
                            {
                                smgRemoveId = Convert.ToInt32(smgRemoveIdString);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid value!\n" +
                                                  "Please try again!");
                                goto Remove3;
                            }
                            int smgLoopCount = 0;
                            for (int i = 0; i < smg.Length; i++)
                            {
                                if (smgRemoveId == smg[i].Id)
                                {
                                    smg.Remove(smg[smgLoopCount]);
                                    Console.WriteLine("Selected gun removed!");
                                    goto START;

                                }
                                smgLoopCount++;
                            }
                            if (smgRemoveId == 0)
                            {
                                goto START;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID!\n" +
                                                  "Please try again!");
                                goto Remove3;
                            }
                        case 4:
                            Console.Clear();
                        Remove4:
                            for (int i = 0; i < sniper.Length; i++)
                            {
                                Console.WriteLine(sniper[i].FullInfo());
                            }
                            Console.WriteLine("\nPress 0 for Go Back");
                            Console.Write("\nSelect ID which you want to delete: ");
                            string sniperRemoveIdString = Console.ReadLine();
                            int? sniperRemoveId = null;
                            try
                            {
                                sniperRemoveId = Convert.ToInt32(sniperRemoveIdString);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid value!\n" +
                                                  "Please try again!");
                                goto Remove4;
                            }
                            int sniperLoopCount = 0;
                            for (int i = 0; i < sniper.Length; i++)
                            {
                                if (sniperRemoveId == sniper[i].Id)
                                {
                                    sniper.Remove(sniper[sniperLoopCount]);
                                    Console.WriteLine("Selected gun removed!");
                                    goto START;
                                }
                                sniperLoopCount++;
                            }
                            if (sniperRemoveId is 0)
                            {
                                goto START;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID!\n" +
                                                  "Please try again!");
                                goto Remove4;
                            }
                        case 0:
                            Console.Clear();
                            goto START;
                        default:
                            break;
                    }
                    break;
                case 0:
                    Console.Clear();
                ERROR3:
                    Console.Write("Are you sure you want to exit?: 'yes' or 'no': ");
                    string exitInput = Console.ReadLine();
                    if (exitInput.ToLower() == "yes")
                    {
                        goto END;
                    }
                    else if (exitInput.ToLower() == "no")
                    {
                        goto START;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!\n" +
                                          "Please Try Again!\n");
                        goto ERROR3;
                    }
                default:
                    Console.WriteLine("Invalid Input!\n" +
                                      "Please Try Again!\n");
                    goto START;

            }


        END:;
        }

        /// <summary>
        /// Printing poster to console
        /// </summary>
        public static void PrintPoster()
        {
            Console.WriteLine(@"..#####..##..##..##..##...........####...######..##...##..##..##..##.......####...######...####...#####..
.##......##..##..###.##..........##........##....###.###..##..##..##......##..##....##....##..##..##..##.
.##.###..##..##..##.###...........####.....##....##.#.##..##..##..##......######....##....##..##..#####..
.##..##..##..##..##..##..............##....##....##...##..##..##..##......##..##....##....##..##..##..##.
..####....####...##..##..........#####...######..##...##...####...######..##..##....##.....####...##..##.
.........................................................................................................
");
        }

        /// <summary>
        /// Printing gun types to console
        /// </summary>
        public static void PrintGunTypes()
        {
            Console.WriteLine("1 - Assault Rifle\n" +
                              "2 - Pistol\n" +
                              "3 - SMG\n" +
                              "4 - Sniper\n" +
                              "0 - Go Back");
            Console.Write("Enter your answer: ");
        }

        /// <summary>
        /// Getting input from user for create, use, remove gun
        /// </summary>
        /// <param name="output">Enter what you want to do(create, use, remove)</param>
        /// <returns></returns>
        public static int UseCreateRemove(string output)
        {
            Console.Clear();
        ERROR1:
            Console.WriteLine($"Which type gun will you {output}?");
            PrintGunTypes();
            string inputString = Console.ReadLine();
            int input;
            try
            {
                input = Convert.ToInt32(inputString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input!\n" +
                                  "Please Try Again!\n");
                goto ERROR1;
            }

            return input;
        }

        /// <summary>
        /// Getting input gun's name which created by user
        /// </summary>
        /// <returns>Gun's name</returns>
        public static string GunsNameCreatedByUser()
        {
            Console.Clear();
            Console.Write("Enter your gun name: ");
            string gunNameCreatedByUser = Console.ReadLine();
            return gunNameCreatedByUser;
        }

        /// <summary>
        /// Getting input gun's capacity which created by user 
        /// </summary>
        /// <returns>Gun's capacity</returns>
        public static int GunsCapacityCreatedByUser()
        {
        TryAgain4:
            Console.Write("Enter weopan's capacity: ");
            string gunCapacityCreatedByUserString = Console.ReadLine();
            int gunCapacityCreatedByUser = 0;

            try
            {
                gunCapacityCreatedByUser = Convert.ToInt32(gunCapacityCreatedByUserString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid value!\n" +
                                  "Please Try Again!");
                goto TryAgain4;
            }

            return gunCapacityCreatedByUser;
        }

        public static void PrintShotSection()
        {
            Console.Clear();
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
      \/ \      \_________/   |\_________________,_ )        =>
       \/ \      /            |     ==== _______)__)    =>      =>
        \/ \    /           __/___  ====_/
         \/ \  /           (O____)\\_(_/
                          (O_ ____)
                           (O____)");
            Console.WriteLine("\n-Press Enter for Shooting-\n" +
                              "-Press R for Reload\n" +
                              "-Press Q for Go back to Main Menu-");
        }

    }
}
