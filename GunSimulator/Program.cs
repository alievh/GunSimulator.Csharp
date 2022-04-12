using GunSimulator.Models;
using System;
using Exceptions.ExceptionsFolder;

namespace GunSimulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Initializer();
            Menu();
        }

        public static void Menu()
        {
        START:
            PrintPoster();
            switch (GetInputForMainMenu().Key)
            {

                #region InformationSection
                case ConsoleKey.D1:
                    InformationSection();
                    break;
                #endregion

                #region UseSection
                case ConsoleKey.D2:
                    UseSection();
                    break;
                #endregion

                #region CreateSection
                case ConsoleKey.D3:
                    CreateSection();
                    break;
                #endregion

                #region RemoveSection
                case ConsoleKey.D4:
                    RemoveSection();
                    break;
                #endregion

                #region ExitSection
                case ConsoleKey.D0:
                    ExitSection();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nInvalid Input!\n" +
                                      "Please Try Again!\n");
                    goto START;
                    #endregion

            }
        }

        /// <summary>
        /// Creating guns default
        /// </summary>
        public static void Initializer()
        {
            #region CreatedAssaultRifles
            new AssaultRifle("Famas", 25, 25);
            new AssaultRifle("M4A4", 30, 30);
            new AssaultRifle("AK-47", 30, 30);
            new AssaultRifle("M4A1-S", 25, 25);
            new AssaultRifle("AUG", 30, 30);
            #endregion
            #region CreatedPistols
            new Pistol("Glock-18", 20, 20);
            new Pistol("P250", 12, 12);
            new Pistol("Five-Seven", 20, 20);
            new Pistol("DesertEagle", 7, 7);
            new Pistol("DualBarettas", 30, 30);
            #endregion
            #region CreatedSmg
            new Smg("MP7", 30, 30);
            new Smg("MP9", 30, 30);
            new Smg("UMP-45", 25, 25);
            new Smg("P90", 50, 50);
            new Smg("PP-Bizon", 38, 38);
            #endregion
            #region CreatedSniper
            new Sniper("AWP", 5, 5);
            new Sniper("SSG 08", 10, 10);
            new Sniper("SCAR-20", 20, 20);
            #endregion
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

        #region PrintSections
        /// <summary>
        /// Printing Information Section to Console
        /// </summary>
        public static void InformationSection()
        {
        BACKTOINFORMATION:
            switch (UseCreateRemove("information about?").Key)
            {
                case ConsoleKey.D1:
                INFORMATION1:
                    Console.Clear();
                    PrintAssaultGuns();
                    if (GetInputFromInformation().Key == ConsoleKey.D0)
                    {
                        goto BACKTOINFORMATION;
                    }
                    else
                    {
                        goto INFORMATION1;
                    }
                case ConsoleKey.D2:
                INFORMATION2:
                    Console.Clear();
                    PrintPistolGuns();
                    if (GetInputFromInformation().Key == ConsoleKey.D0)
                    {
                        goto BACKTOINFORMATION;
                    }
                    else
                    {
                        goto INFORMATION2;
                    }
                case ConsoleKey.D3:
                INFORMATION3:
                    Console.Clear();
                    PrintSmgGuns();
                    if (GetInputFromInformation().Key == ConsoleKey.D0)
                    {
                        goto BACKTOINFORMATION;
                    }
                    else
                    {
                        goto INFORMATION3;
                    }
                case ConsoleKey.D4:
                INFORMATION4:
                    Console.Clear();
                    PrintSniperGuns();
                    if (GetInputFromInformation().Key == ConsoleKey.D0)
                    {
                        goto BACKTOINFORMATION;
                    }
                    else
                    {
                        goto INFORMATION4;
                    }
                case ConsoleKey.D0:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Invalid Input!\n" +
                                      "Please TryAgain!");
                    goto BACKTOINFORMATION;
            }

        }

        /// <summary>
        /// Printing Use Section to Console
        /// </summary>
        public static void UseSection()
        {
        BACKTOUSE:
            switch (UseCreateRemove("use?").Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                USE1:
                    int usingAssaultInput = GetUseRemoveInput(1, "use");
                    int indexDetectorAssault = AssaultRifle.AssaultRifles.Length + 1;
                    for (int i = 0; i < AssaultRifle.AssaultRifles.Length; i++)
                    {
                        if (usingAssaultInput == AssaultRifle.AssaultRifles[i].Id)
                        {
                            indexDetectorAssault = i;
                        }
                    }
                SHOOTMODE1:
                    ConsoleKeyInfo shootingModeAssault;
                    if (indexDetectorAssault < AssaultRifle.AssaultRifles.Length && usingAssaultInput >= AssaultRifle.AssaultRifles[0].Id)
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
                    ConsoleKeyInfo userAssaultInput;

                    switch (shootingModeAssault.Key)
                    {
                        case ConsoleKey.D1:
                            PrintShotSection();
                        SHOOT1:
                            userAssaultInput = Console.ReadKey(true);
                            while (userAssaultInput.Key != ConsoleKey.Q)
                            {
                                if (userAssaultInput.Key == ConsoleKey.Enter)
                                {
                                    AssaultRifle.AssaultRifles[indexDetectorAssault].ReduceSingleAmmo();
                                }
                                else if (userAssaultInput.Key == ConsoleKey.R)
                                {
                                    AssaultRifle.AssaultRifles[indexDetectorAssault].Reload();
                                }
                                goto SHOOT1;
                            }
                            Console.Clear();
                            Menu();
                            break;
                        case ConsoleKey.D2:
                            PrintShotSection();
                        SHOOT2:
                            userAssaultInput = Console.ReadKey(true);
                            while (userAssaultInput.Key != ConsoleKey.Q)
                            {
                                if (userAssaultInput.Key == ConsoleKey.Enter)
                                {
                                    AssaultRifle.AssaultRifles[indexDetectorAssault].ReduceBurstAmmo();
                                }
                                else if (userAssaultInput.Key == ConsoleKey.R)
                                {
                                    AssaultRifle.AssaultRifles[indexDetectorAssault].Reload();
                                }
                                goto SHOOT2;
                            }
                            Console.Clear();
                            Menu();
                            break;
                        case ConsoleKey.D3:
                            PrintShotSection();
                        SHOOT3:
                            userAssaultInput = Console.ReadKey(true);
                            while (userAssaultInput.Key != ConsoleKey.Q)
                            {
                                if (userAssaultInput.Key == ConsoleKey.Enter)
                                {
                                    AssaultRifle.AssaultRifles[indexDetectorAssault].ReduceAutoAmmo();
                                }
                                else if (userAssaultInput.Key == ConsoleKey.R)
                                {
                                    AssaultRifle.AssaultRifles[indexDetectorAssault].Reload();
                                }
                                goto SHOOT3;
                            }
                            Console.Clear();
                            Menu();
                            break;
                        default:
                            Console.WriteLine("Invalid Input!\n" +
                                              "Please TryAgain!");
                            goto SHOOTMODE1;
                    }
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                USE2:
                    int usingPistolInput = GetUseRemoveInput(2, "use");
                    int indexDetectorPistol = Pistol.Pistols.Length + 1;
                    for (int i = 0; i < Pistol.Pistols.Length; i++)
                    {
                        if (usingPistolInput == Pistol.Pistols[i].Id)
                        {
                            indexDetectorPistol = i;
                        }
                    }
                SHOOTMODE2:
                    ConsoleKeyInfo shootingModePistol;
                    if (indexDetectorPistol < Pistol.Pistols.Length && usingPistolInput >= Pistol.Pistols[0].Id)
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
                        goto USE2;
                    }

                    ConsoleKeyInfo userPistolInput;
                    switch (shootingModePistol.Key)
                    {
                        case ConsoleKey.D1:
                            PrintShotSection();
                        SHOOT4:
                            userPistolInput = Console.ReadKey(true);
                            while (userPistolInput.Key != ConsoleKey.Q)
                            {
                                if (userPistolInput.Key == ConsoleKey.Enter)
                                {
                                    Pistol.Pistols[indexDetectorPistol].ReduceSingleAmmo();
                                }
                                else if (userPistolInput.Key == ConsoleKey.R)
                                {
                                    Pistol.Pistols[indexDetectorPistol].Reload();
                                }
                                goto SHOOT4;
                            }
                            Console.Clear();
                            Menu();
                            break;
                        case ConsoleKey.D2:
                            PrintShotSection();
                        SHOOT5:
                            userPistolInput = Console.ReadKey(true);
                            while (userPistolInput.Key != ConsoleKey.Q)
                            {
                                if (userPistolInput.Key == ConsoleKey.Enter)
                                {
                                    Pistol.Pistols[indexDetectorPistol].ReduceBurstAmmo();
                                }
                                else if (userPistolInput.Key == ConsoleKey.R)
                                {
                                    Pistol.Pistols[indexDetectorPistol].Reload();
                                }
                                goto SHOOT5;
                            }
                            Console.Clear();
                            Menu();
                            break;
                        default:
                            Console.WriteLine("Invalid Input!\n" +
                                              "Please TryAgain!");
                            goto SHOOTMODE2;
                    }
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                USE3:
                    int usingSmgInput = GetUseRemoveInput(3, "use");
                    int indexDetectorSmg = Smg.SmgRifles.Length + 1;
                    for (int i = 0; i < Smg.SmgRifles.Length; i++)
                    {
                        if (usingSmgInput == Smg.SmgRifles[i].Id)
                        {
                            indexDetectorSmg = i;
                        }
                    }
                SHOOTMODE3:
                    ConsoleKeyInfo shootingModeSmg;
                    if (indexDetectorSmg < Smg.SmgRifles.Length && usingSmgInput >= Smg.SmgRifles[0].Id)
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
                        goto USE3;
                    }

                    ConsoleKeyInfo userSmgInput;

                    switch (shootingModeSmg.Key)
                    {
                        case ConsoleKey.D1:
                            PrintShotSection();
                        SHOT6:
                            userSmgInput = Console.ReadKey(true);
                            while (userSmgInput.Key != ConsoleKey.Q)
                            {
                                if (userSmgInput.Key == ConsoleKey.Enter)
                                {
                                    Smg.SmgRifles[indexDetectorSmg].ReduceSingleAmmo();
                                }
                                else if (userSmgInput.Key == ConsoleKey.R)
                                {
                                    Smg.SmgRifles[indexDetectorSmg].Reload();
                                }
                                goto SHOT6;
                            }
                            Console.Clear();
                            Menu();
                            break;
                        case ConsoleKey.D2:
                            PrintShotSection();
                        SHOT7:
                            userSmgInput = Console.ReadKey(true);
                            while (userSmgInput.Key != ConsoleKey.Q)
                            {
                                if (userSmgInput.Key == ConsoleKey.Enter)
                                {
                                    Smg.SmgRifles[indexDetectorSmg].ReduceAutoAmmo();
                                }
                                else if (userSmgInput.Key == ConsoleKey.R)
                                {
                                    Smg.SmgRifles[indexDetectorSmg].Reload();
                                }
                                goto SHOT7;
                            }
                            Console.Clear();
                            Menu();
                            break;
                        default:
                            Console.WriteLine("Invalid Input!\n" +
                                              "Please TryAgain!");
                            goto SHOOTMODE3;
                    }
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                USE4:
                    int usingSniperInput = GetUseRemoveInput(4, "use");

                    int indexDetectorSniper = Sniper.SniperRifles.Length + 1;
                    for (int i = 0; i < Sniper.SniperRifles.Length; i++)
                    {
                        if (usingSniperInput == Sniper.SniperRifles[i].Id)
                        {
                            indexDetectorSniper = i;
                        }
                    }

                    if (usingSniperInput == 0)
                    {
                        goto BACKTOUSE;
                    }
                    else if (indexDetectorSniper >= Sniper.SniperRifles.Length && usingSniperInput < Sniper.SniperRifles[0].Id)
                    {
                        Console.Clear();
                        Console.WriteLine("\nInvalid Input!\n" +
                                          "Please TryAgain!\n");
                        goto USE4;
                    }
                    PrintShotSection();
                SHOOTMODE8:
                    ConsoleKeyInfo userSniperInput = Console.ReadKey(true);

                    while (userSniperInput.Key != ConsoleKey.Q)
                    {
                        if (userSniperInput.Key == ConsoleKey.Enter)
                        {
                            Sniper.SniperRifles[indexDetectorSniper].ReduceSingleAmmo();
                        }
                        else if (userSniperInput.Key == ConsoleKey.R)
                        {
                            Sniper.SniperRifles[indexDetectorSniper].Reload();
                        }
                        goto SHOOTMODE8;
                    }
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.D0:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("\nInvalid Input!\n" +
                                      "Please TryAgain!\n");
                    goto BACKTOUSE;

            }

        }

        /// <summary>
        /// Printing Remove Section to Console
        /// </summary>
        public static void RemoveSection()
        {
        BACKTOREMOVE:
            switch (UseCreateRemove("remove?").Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                Remove1:
                    int assaultRemoveId = GetUseRemoveInput(1, "remove");
                    for (int i = 0; i < AssaultRifle.AssaultRifles.Length; i++)
                    {
                        if (assaultRemoveId == AssaultRifle.AssaultRifles[i].Id)
                        {
                            AssaultRifle.AssaultRifles.Remove(AssaultRifle.AssaultRifles[i]);
                            Console.Clear();
                            Console.WriteLine("\n- Selected gun removed! -\n");
                            Menu();
                            goto END;
                        }

                    }
                    if (assaultRemoveId is 0)
                    {
                        Console.Clear();
                        Menu();
                        break;
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
                    int pistolRemoveId = GetUseRemoveInput(2, "remove");

                    for (int i = 0; i < Pistol.Pistols.Length; i++)
                    {
                        if (pistolRemoveId == Pistol.Pistols[i].Id)
                        {
                            Pistol.Pistols.Remove(Pistol.Pistols[i]);
                            Console.Clear();
                            Console.WriteLine("\n- Selected gun removed! -\n");
                            Menu();
                            break;
                        }
                    }
                    if (pistolRemoveId is 0)
                    {
                        Console.Clear();
                        Menu();
                        break;
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
                    int smgRemoveId = GetUseRemoveInput(3, "remove");

                    for (int i = 0; i < Smg.SmgRifles.Length; i++)
                    {
                        if (smgRemoveId == Smg.SmgRifles[i].Id)
                        {
                            Smg.SmgRifles.Remove(Smg.SmgRifles[i]);
                            Console.Clear();
                            Console.WriteLine("\n- Selected gun removed! -\n");
                            Menu();
                            break;

                        }
                    }
                    if (smgRemoveId is 0)
                    {
                        Console.Clear();
                        Menu();
                        break;
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
                    int sniperRemoveId = GetUseRemoveInput(4, "remove");

                    for (int i = 0; i < Sniper.SniperRifles.Length; i++)
                    {
                        if (sniperRemoveId == Sniper.SniperRifles[i].Id)
                        {
                            Sniper.SniperRifles.Remove(Sniper.SniperRifles[i]);
                            Console.Clear();
                            Console.WriteLine("\n- Selected gun removed! -\n");
                            Menu();
                            break;
                        }
                    }
                    if (sniperRemoveId is 0)
                    {
                        Console.Clear();
                        Menu();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID!\n" +
                                          "Please try again!");
                        goto Remove4;
                    }
                case ConsoleKey.D0:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("\nInvalid Input!\n" +
                                      "Please TryAgain!\n");
                    goto BACKTOREMOVE;
            }
        END:;
        }

        /// <summary>
        /// Printing Create Section to Console
        /// </summary>
        public static void CreateSection()
        {
        BACKTOCREATE:
            switch (UseCreateRemove("create").Key)
            {
                case ConsoleKey.D1:
                    string assaultName = GunsNameCreatedByUser();
                    int assaultCapacity = GunsCapacityCreatedByUser();

                    new AssaultRifle(assaultName, assaultCapacity, assaultCapacity);
                    Console.Clear();
                    Console.WriteLine("\n-Gun Created!-\n");
                    Menu();
                    break;
                case ConsoleKey.D2:
                    string pistolName = GunsNameCreatedByUser();
                    int pistolCapacity = GunsCapacityCreatedByUser();

                    new Pistol(pistolName, pistolCapacity, pistolCapacity);
                    Console.Clear();
                    Console.WriteLine("\n-Gun Created!-\n");
                    Menu();
                    break;
                case ConsoleKey.D3:
                    string smgName = GunsNameCreatedByUser();
                    int smgCapacity = GunsCapacityCreatedByUser();

                    new Smg(smgName, smgCapacity, smgCapacity);
                    Console.Clear();
                    Console.WriteLine("\n-Gun Created!-\n");
                    Menu();
                    break;
                case ConsoleKey.D4:
                    string sniperName = GunsNameCreatedByUser();
                    int sniperCapacity = GunsCapacityCreatedByUser();

                    new Sniper(sniperName, sniperCapacity, sniperCapacity);
                    Console.Clear();
                    Console.WriteLine("\n-Gun Created!-\n");
                    Menu();
                    break;
                case ConsoleKey.D0:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("\nInvalid Input!\n" +
                                      "Please TryAgain!\n");
                    goto BACKTOCREATE;

            }
        }

        /// <summary>
        /// Exiting from ConsoleApp
        /// </summary>
        public static void ExitSection()
        {
            Console.Clear();
        ERROR3:
            Console.Write("Are you sure you want to exit?: 'yes' or 'no': ");
            string exitInput = Console.ReadLine();
            if (exitInput.ToLower() == "yes")
            {
            }
            else if (exitInput.ToLower() == "no")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Invalid Input!\n" +
                                  "Please Try Again!\n");
                goto ERROR3;
            }
        }

        #endregion

        /// <summary>
        /// Getting input from user for main menu
        /// </summary>
        /// <returns></returns>
        public static ConsoleKeyInfo GetInputForMainMenu()
        {
            Console.WriteLine("Press 1 - Information about guns\n" +
                              "Press 2 - Use exist weapon\n" +
                              "Press 3 - Create new weapon\n" +
                              "Press 4 - Remove exist weapon\n" +
                              "Press 0 - Exit\n");
            Console.Write(">> ");
            return Console.ReadKey(true);
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
            Console.Write("\n>>");
        }

        /// <summary>
        /// Getting input from user for create, use, remove gun
        /// </summary>
        /// <param name="output">Enter what you want to do(create, use, remove)</param>
        /// <returns></returns>
        public static ConsoleKeyInfo UseCreateRemove(string output)
        {
            Console.Clear();
            Console.WriteLine($"Which type gun you want {output}?");
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
            Console.Write("Enter weapon's capacity: ");
            string gunCapacityCreatedByUserString = Console.ReadLine();
            int gunCapacityCreatedByUser;

            try
            {
                gunCapacityCreatedByUser = Convert.ToInt32(gunCapacityCreatedByUserString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input! Please TryAgain!");
                goto TryAgain4;
            }
            if (gunCapacityCreatedByUser < 1 || gunCapacityCreatedByUser > 250)
            {
                Console.WriteLine("Invalid value!\n" +
                                  "Please choose from between 1 and 250!");
                goto TryAgain4;
            }

            return gunCapacityCreatedByUser;
        }

        /// <summary>
        /// Printing Shot Section to Console
        /// </summary>
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
            Console.WriteLine("\n - Press <Enter> for Shooting -\n" +
                              " - Press 'R' for Reload -\n" +
                              " - Press 'Q' for Go back to <Main Menu> -");
        }

        /// <summary>
        /// Taking input from user for Shot Mode
        /// </summary>
        /// <param name="value">Selection of Modes</param>
        /// <returns></returns>
        public static ConsoleKeyInfo ModeSelector(int value)
        {
            if (value == 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Select shooting mode: 1 - Single Mode | 2 - Burst Mode | 3 - Auto Mode");
                Console.Write("\n>>");
            }
            else if (value == 2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Select shooting mode: 1 - Single Mode | 2 - Burst Mode");
                Console.Write("\n>>");
            }
            else if (value == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Select shooting mode: 1 - Single Mode | 2 - Auto Mode");
                Console.Write("\n>>");
            }


            return Console.ReadKey(true);
        }

        /// <summary>
        /// Getting input from user in Information section
        /// </summary>
        /// <returns>User input</returns>
        public static ConsoleKeyInfo GetInputFromInformation()
        {
            Console.WriteLine("\n<= Press 0 for Go Back =>\n");
            Console.Write(">>");
            return Console.ReadKey(true);
        }

        /// <summary>
        /// Printing Assault Rifles to Console
        /// </summary>
        public static void PrintAssaultGuns()
        {
            for (int i = 0; i < AssaultRifle.AssaultRifles.Length; i++)
            {
                Console.WriteLine(AssaultRifle.AssaultRifles[i].FullInfo());
            }
        }

        /// <summary>
        /// Printing Pistols to Console
        /// </summary>
        public static void PrintPistolGuns()
        {
            for (int i = 0; i < Pistol.Pistols.Length; i++)
            {
                Console.WriteLine(Pistol.Pistols[i].FullInfo());
            }
        }

        /// <summary>
        /// Printing Smg Rifles to Console
        /// </summary>
        public static void PrintSmgGuns()
        {
            for (int i = 0; i < Smg.SmgRifles.Length; i++)
            {
                Console.WriteLine(Smg.SmgRifles[i].FullInfo());
            }
        }

        /// <summary>
        /// Printing Sniper Rifles to Console
        /// </summary>
        public static void PrintSniperGuns()
        {
            for (int i = 0; i < Sniper.SniperRifles.Length; i++)
            {
                Console.WriteLine(Sniper.SniperRifles[i].FullInfo());
            }
        }

        /// <summary>
        /// Getting input from user for Use and Remove
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public static int GetUseRemoveInput(int index, string output)
        {
        USEREMOVE:
            if (index == 1)
            {
                PrintAssaultGuns();
            }
            else if (index == 2)
            {
                PrintPistolGuns();
            }
            else if (index == 3)
            {
                PrintSmgGuns();
            }
            else if (index == 4)
            {
                PrintSniperGuns();
            }
            Console.WriteLine("\n-Press 0 for Go Back-");
            Console.Write($"\nSelect ID which you want to {output}: ");
            string inputString = Console.ReadLine();
            int input;
            try
            {
                input = Convert.ToInt32(inputString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input!\n" +
                                  "Please TryAgain!");
                goto USEREMOVE;
            }

            return input;
        }

    }
}
