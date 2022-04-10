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

            assaultRifles.Add(new AssaultRifle("Famas", 25, 25));
            assaultRifles.Add(new AssaultRifle("M4A4", 30, 30));
            assaultRifles.Add(new AssaultRifle("AK-47", 30, 30));
            assaultRifles.Add(new AssaultRifle("M4A1-S", 25, 25));
            assaultRifles.Add(new AssaultRifle("AUG", 30, 30));
            #endregion
            #region CreatedPistols
            Indexer<Pistol> pistols = new Indexer<Pistol>();

            pistols.Add(new Pistol("Glock-18", 20, 20));
            pistols.Add(new Pistol("P250", 12, 12));
            pistols.Add(new Pistol("Five-Seven", 20, 20));
            pistols.Add(new Pistol("DesertEagle", 7, 7));
            pistols.Add(new Pistol("DualBarettas", 30, 30));
            #endregion
            #region CreatedSmg
            Indexer<Smg> smg = new Indexer<Smg>();

            smg.Add(new Smg("MP7", 30, 30));
            smg.Add(new Smg("MP9", 30, 30));
            smg.Add(new Smg("UMP-45", 25, 25));
            smg.Add(new Smg("P90", 50, 50));
            smg.Add(new Smg("PP-Bizon", 38, 38));
            #endregion
            #region CreatedSniper
            Indexer<Sniper> sniper = new Indexer<Sniper>();

            sniper.Add(new Sniper("AWP", 5, 5));
            sniper.Add(new Sniper("SSG 08", 10, 10));
            sniper.Add(new Sniper("SCAR-20", 20, 20));
            #endregion


            PrintPoster();
        START:
            Console.WriteLine("Press 1 - Use exist weapon\n" +
                              "Press 2 - Create new weapon\n" +
                              "Press 3 - Remove exist weapon\n" +
                              "Press 0 - Exit\n");
            Console.Write("Enter your answer: ");
            ConsoleKeyInfo menuInput = Console.ReadKey(true);
        RETURN:
            switch (menuInput.Key)
            {
                case ConsoleKey.D1:
                    BACKTOUSE:
                    switch (UseCreateRemove("use").Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                        USE1:
                            for (int i = 0; i < assaultRifles.Length; i++)
                            {
                                Console.WriteLine(assaultRifles[i].FullInfo());
                            }
                            Console.WriteLine("\n-Press 0 for Go Back-");
                            Console.Write("\nSelect ID which you want to delete: ");
                            string usingAssaultInputString = Console.ReadLine();
                            int? usingAssaultInput = null;
                            try
                            {
                                usingAssaultInput = Convert.ToInt32(usingAssaultInputString);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid Input!\n" +
                                                  "Please TryAgain!");
                                goto USE1;
                            }

                        SHOOTMODE1:
                            int indexDetectorAssault = 0;
                            for (int i = 0; i < assaultRifles.Length; i++)
                            {
                                if (usingAssaultInput == assaultRifles[i].Id)
                                {
                                    indexDetectorAssault = i;
                                }
                            }
                            ConsoleKeyInfo shootingModeAssault;
                            if (indexDetectorAssault < assaultRifles.Length && usingAssaultInput > 0)
                            {
                                shootingModeAssault = ModeSelector(3);
                            }
                            else if (usingAssaultInput == 0)
                            {
                                goto BACKTOUSE;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\nInvalid Input!\n" +
                                                  "Please TryAgain!\n");
                                goto USE1;
                            }

                            PrintShotSection();

                        SHOOTMODE2:
                            ConsoleKeyInfo userAssaultInput = Console.ReadKey(true);

                            switch (shootingModeAssault.Key)
                            {
                                case ConsoleKey.D1:

                                    while (userAssaultInput.Key != ConsoleKey.Q)
                                    {
                                        if (userAssaultInput.Key == ConsoleKey.Enter)
                                        {
                                            assaultRifles[indexDetectorAssault].ReduceSingleAmmo();
                                        }
                                        else if (userAssaultInput.Key == ConsoleKey.R)
                                        {
                                            assaultRifles[indexDetectorAssault].Reload();
                                        }
                                        goto SHOOTMODE2;
                                    }
                                    goto START;
                                case ConsoleKey.D2:

                                    while (userAssaultInput.Key != ConsoleKey.Q)
                                    {
                                        if (userAssaultInput.Key == ConsoleKey.Enter)
                                        {
                                            assaultRifles[indexDetectorAssault].ReduceBurstAmmo();
                                        }
                                        else if (userAssaultInput.Key == ConsoleKey.R)
                                        {
                                            assaultRifles[indexDetectorAssault].Reload();
                                        }
                                        goto SHOOTMODE2;
                                    }
                                    goto START;
                                case ConsoleKey.D3:

                                    while (userAssaultInput.Key != ConsoleKey.Q)
                                    {
                                        if (userAssaultInput.Key == ConsoleKey.Enter)
                                        {
                                            assaultRifles[indexDetectorAssault].ReduceAutoAmmo();
                                        }
                                        else if (userAssaultInput.Key == ConsoleKey.R)
                                        {
                                            assaultRifles[indexDetectorAssault].Reload();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You can't use this keyword");
                                        }
                                        goto SHOOTMODE2;
                                    }
                                    goto START;
                                default:
                                    Console.WriteLine("Invalid Input!\n" +
                                                      "Please TryAgain!");
                                    goto SHOOTMODE1;
                            }

                        case ConsoleKey.D2:
                            Console.Clear();
                        USE2:
                            for (int i = 0; i < pistols.Length; i++)
                            {
                                Console.WriteLine(pistols[i].FullInfo());
                            }
                            Console.WriteLine("\n-Press 0 for Go Back-");
                            Console.Write("\nSelect ID which you want to delete: ");
                            string usingPistolInputString = Console.ReadLine();
                            int? usingPistolInput = null;
                            try
                            {
                                usingPistolInput = Convert.ToInt32(usingPistolInputString);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid Input!\n" +
                                                  "Please TryAgain!");
                                goto USE2;
                            }

                        SHOOTMODE3:
                            int indexDetectorPistol = 0;
                            for (int i = 0; i < pistols.Length; i++)
                            {
                                if (usingPistolInput == pistols[i].Id)
                                {
                                    indexDetectorPistol = i;
                                }
                            }
                            ConsoleKeyInfo shootingModePistol;
                            if (indexDetectorPistol < assaultRifles.Length && usingPistolInput > 0)
                            {
                                shootingModePistol = ModeSelector(2);
                            }
                            else if (usingPistolInput == 0)
                            {
                                goto BACKTOUSE;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\nInvalid Input!\n" +
                                                  "Please TryAgain!\n");
                                goto USE1;
                            }

                            PrintShotSection();

                        SHOOTMODE4:
                            ConsoleKeyInfo userPistolInput = Console.ReadKey(true);

                            switch (shootingModePistol.Key)
                            {
                                case ConsoleKey.D1:

                                    while (userPistolInput.Key != ConsoleKey.Q)
                                    {
                                        if (userPistolInput.Key == ConsoleKey.Enter)
                                        {
                                            pistols[indexDetectorPistol].ReduceSingleAmmo();
                                        }
                                        else if (userPistolInput.Key == ConsoleKey.R)
                                        {
                                            pistols[indexDetectorPistol].Reload();
                                        }
                                        goto SHOOTMODE4;
                                    }
                                    goto START;
                                case ConsoleKey.D2:

                                    while (userPistolInput.Key != ConsoleKey.Q)
                                    {
                                        if (userPistolInput.Key == ConsoleKey.Enter)
                                        {
                                            pistols[indexDetectorPistol].ReduceBurstAmmo();
                                        }
                                        else if (userPistolInput.Key == ConsoleKey.R)
                                        {
                                            pistols[indexDetectorPistol].Reload();
                                        }
                                        goto SHOOTMODE4;
                                    }
                                    goto START;
                                default:
                                    Console.WriteLine("Invalid Input!\n" +
                                                      "Please TryAgain!");
                                    goto SHOOTMODE3;
                            }
                        case ConsoleKey.D3:
                            Console.Clear();
                            for (int i = 0; i < smg.Length; i++)
                            {
                                Console.WriteLine(smg[i].FullInfo());
                            }
                            Console.WriteLine("\n-Press 0 for Go Back-");
                            Console.Write("\nSelect ID which you want to delete: ");
                            string usingSmgInputString = Console.ReadLine();
                            int? usingSmgInput = null;
                            try
                            {
                                usingSmgInput = Convert.ToInt32(usingSmgInputString);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid Input!\n" +
                                                  "Please TryAgain!");
                                goto USE2;
                            }

                        SHOOTMODE5:

                            int indexDetectorSmg = 0;
                            for (int i = 0; i < smg.Length; i++)
                            {
                                if (usingSmgInput == smg[i].Id)
                                {
                                    indexDetectorSmg = i;
                                }
                            }
                            ConsoleKeyInfo shootingModeSmg;
                            if (indexDetectorSmg < smg.Length && usingSmgInput > 0)
                            {
                                shootingModeSmg = ModeSelector(1);
                            }
                            else if (usingSmgInput == 0)
                            {
                                goto BACKTOUSE;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\nInvalid Input!\n" +
                                                  "Please TryAgain!\n");
                                goto USE1;
                            }

                            PrintShotSection();

                        SHOOTMODE6:
                            ConsoleKeyInfo userSmgInput = Console.ReadKey(true);

                            switch (shootingModeSmg.Key)
                            {
                                case ConsoleKey.D1:

                                    while (userSmgInput.Key != ConsoleKey.Q)
                                    {
                                        if (userSmgInput.Key == ConsoleKey.Enter)
                                        {
                                            smg[indexDetectorSmg].ReduceSingleAmmo();
                                        }
                                        else if (userSmgInput.Key == ConsoleKey.R)
                                        {
                                            smg[indexDetectorSmg].Reload();
                                        }
                                        goto SHOOTMODE6;
                                    }
                                    goto START;
                                case ConsoleKey.D2:

                                    while (userSmgInput.Key != ConsoleKey.Q)
                                    {
                                        if (userSmgInput.Key == ConsoleKey.Enter)
                                        {
                                            smg[indexDetectorSmg].ReduceAutoAmmo();
                                        }
                                        else if (userSmgInput.Key == ConsoleKey.R)
                                        {
                                            smg[indexDetectorSmg].Reload();
                                        }
                                        goto SHOOTMODE6;
                                    }
                                    goto START;
                                default:
                                    Console.WriteLine("Invalid Input!\n" +
                                                      "Please TryAgain!");
                                    goto SHOOTMODE5;
                            }
                        case ConsoleKey.D4:
                            Console.Clear();
                            for (int i = 0; i < sniper.Length; i++)
                            {
                                Console.WriteLine(sniper[i].FullInfo());
                            }
                            Console.WriteLine("\n-Press 0 for Go Back-");
                            Console.Write("\nSelect ID which you want to delete: ");
                            string usingSniperInputString = Console.ReadLine();
                            int? usingSniperInput = null;
                            try
                            {
                                usingSniperInput = Convert.ToInt32(usingSniperInputString);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid Input!\n" +
                                                  "Please TryAgain!");
                                goto USE2;
                            }

                            int indexDetectorSniper = 0;
                            for (int i = 0; i < sniper.Length; i++)
                            {
                                if (usingSniperInput == sniper[i].Id)
                                {
                                    indexDetectorSniper = i;
                                }
                            }

                            if (usingSniperInput == 0)
                            {
                                goto BACKTOUSE;
                            }
                            else if (indexDetectorSniper >= sniper.Length && usingSniperInput <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("\nInvalid Input!\n" +
                                                  "Please TryAgain!\n");
                                goto USE1;
                            }

                            PrintShotSection();

                        SHOOTMODE8:
                            ConsoleKeyInfo userSniperInput = Console.ReadKey(true);

                            while (userSniperInput.Key != ConsoleKey.Q)
                            {
                                if (userSniperInput.Key == ConsoleKey.Enter)
                                {
                                    sniper[indexDetectorSniper].ReduceSingleAmmo();
                                }
                                else if (userSniperInput.Key == ConsoleKey.R)
                                {
                                    sniper[indexDetectorSniper].Reload();
                                }
                                goto SHOOTMODE8;
                            }
                            goto START;
                        case ConsoleKey.D0:
                            Console.Clear();
                            goto START;
                        default:
                            Console.WriteLine("\nInvalid Input!\n" +
                                              "Please TryAgain!\n");
                            goto BACKTOUSE;
                    }
                case ConsoleKey.D2:
                    BACKTOCREATE:
                    switch (UseCreateRemove("create").Key)
                    {
                        case ConsoleKey.D1:
                            string assaultName = GunsNameCreatedByUser();
                            int assaultCapacity = GunsCapacityCreatedByUser();

                            assaultRifles.Add(new AssaultRifle(assaultName, assaultCapacity, assaultCapacity));
                            Console.WriteLine("\n-Gun Created!-\n");
                            goto START;
                        case ConsoleKey.D2:
                            string pistolName = GunsNameCreatedByUser();
                            int pistolCapacity = GunsCapacityCreatedByUser();

                            pistols.Add(new Pistol(pistolName, pistolCapacity, pistolCapacity));
                            Console.WriteLine("\n-Gun Created!-\n");
                            goto START;
                        case ConsoleKey.D3:
                            string smgName = GunsNameCreatedByUser();
                            int smgCapacity = GunsCapacityCreatedByUser();

                            smg.Add(new Smg(smgName, smgCapacity, smgCapacity));
                            Console.WriteLine("\n-Gun Created!-\n");
                            goto START;
                        case ConsoleKey.D4:
                            string sniperName = GunsNameCreatedByUser();
                            int sniperCapacity = GunsCapacityCreatedByUser();

                            sniper.Add(new Sniper(sniperName, sniperCapacity, sniperCapacity));
                            Console.WriteLine("\n-Gun Created!-\n");
                            goto START;
                        case ConsoleKey.D0:
                            Console.Clear();
                            goto START;
                        default:
                            Console.WriteLine("\nInvalid Input!\n" +
                                              "Please TryAgain!\n");
                            goto BACKTOCREATE;

                    }
                case ConsoleKey.D3:
                    BACKTOREMOVE:
                    switch (UseCreateRemove("remove").Key)
                    {
                        case ConsoleKey.D1:
                        Remove1:
                            Console.Clear();
                            for (int i = 0; i < assaultRifles.Length; i++)
                            {
                                Console.WriteLine(assaultRifles[i].FullInfo());
                            }
                            Console.WriteLine("\n-Press 0 for Go Back-");
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
                            for (int i = 0; i < assaultRifles.Length; i++)
                            {
                                if (assaultRemoveId == assaultRifles[i].Id)
                                {
                                    assaultRifles.Remove(assaultRifles[i]);
                                    Console.WriteLine("Selected gun removed!");
                                    goto START;

                                }

                            }
                            if (assaultRemoveId is 0)
                            {
                                Console.Clear();
                                goto RETURN;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID!\n" +
                                                  "Please try again!");
                                goto Remove1;
                            }
                        case ConsoleKey.D2:
                            Console.Clear();
                        Remove2:
                            for (int i = 0; i < pistols.Length; i++)
                            {
                                Console.WriteLine(pistols[i].FullInfo());
                            }
                            Console.WriteLine("\n-Press 0 for Go Back-");
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
                            for (int i = 0; i < pistols.Length; i++)
                            {
                                if (pistolRemoveId == pistols[i].Id)
                                {
                                    pistols.Remove(pistols[i]);
                                    Console.WriteLine("Selected gun removed!");
                                    goto START;
                                }
                            }
                            if (pistolRemoveId is 0)
                            {
                                Console.Clear();
                                goto RETURN;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID!\n" +
                                                  "Please try again!");
                                goto Remove2;
                            }

                        case ConsoleKey.D3:
                            Console.Clear();
                        Remove3:
                            for (int i = 0; i < smg.Length; i++)
                            {
                                Console.WriteLine(smg[i].FullInfo());
                            }
                            Console.WriteLine("\n-Press 0 for Go Back-");
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
                            for (int i = 0; i < smg.Length; i++)
                            {
                                if (smgRemoveId == smg[i].Id)
                                {
                                    smg.Remove(smg[i]);
                                    Console.WriteLine("Selected gun removed!");
                                    goto START;

                                }
                            }
                            if (smgRemoveId is 0)
                            {
                                Console.Clear();
                                goto RETURN;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID!\n" +
                                                  "Please try again!");
                                goto Remove3;
                            }
                        case ConsoleKey.D4:
                            Console.Clear();
                        Remove4:
                            for (int i = 0; i < sniper.Length; i++)
                            {
                                Console.WriteLine(sniper[i].FullInfo());
                            }
                            Console.WriteLine("\n-Press 0 for Go Back-");
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
                            for (int i = 0; i < sniper.Length; i++)
                            {
                                if (sniperRemoveId == sniper[i].Id)
                                {
                                    sniper.Remove(sniper[i]);
                                    Console.WriteLine("Selected gun removed!");
                                    goto START;
                                }
                            }
                            if (sniperRemoveId is 0)
                            {
                                Console.Clear();
                                goto RETURN;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID!\n" +
                                                  "Please try again!");
                                goto Remove4;
                            }
                        case ConsoleKey.D0:
                            Console.Clear();
                            goto START;
                        default:
                            Console.WriteLine("\nInvalid Input!\n" +
                                              "Please TryAgain!\n");
                            goto BACKTOREMOVE;
                    }
                case ConsoleKey.D0:
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
                    Console.Clear();
                    Console.WriteLine("\nInvalid Input!\n" +
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
            Console.ForegroundColor = ConsoleColor.Green;
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
        public static ConsoleKeyInfo UseCreateRemove(string output)
        {
            Console.Clear();
            Console.WriteLine($"Which type gun will you {output}?");
            PrintGunTypes();

            return Console.ReadKey();
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
            Console.ForegroundColor = ConsoleColor.Red;
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
       \/ \      /            |     ==== _______)__)
        \/ \    /           __/___  ====_/
         \/ \  /           (O____)\\_(_/
                          (O_ ____)
                           (O____)");
            Console.WriteLine("\n-Press Enter for Shooting-\n" +
                              "-Press R for Reload\n" +
                              "-Press Q for Go back to Main Menu-");
        }

        public static ConsoleKeyInfo ModeSelector(int value)
        {
            if (value == 3)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Select shooting mode: 1 - Single Mode | 2 - Burst Mode | 3 - Auto Mode");
                Console.Write("Your answer: ");
            }
            else if (value == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Select shooting mode: 1 - Single Mode | 2 - Burst Mode");
                Console.Write("Your answer: ");
            }
            else if (value == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Select shooting mode: 1 - Single Mode | 2 - Auto Mode");
                Console.Write("Your answer: ");
            }


            return Console.ReadKey(true);
        }

    }
}
