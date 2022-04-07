using System;
using GunSimulator.Models;
using Indexer.IndexerFolder;

namespace GunSimulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //AssaultRifle ak47 = new AssaultRifle("ak-47", 30);
            //AssaultRifle ak48 = new AssaultRifle("ak-48", 30);
            //Sniper awp = new Sniper("Awp", 5);
            //Pistol deserteagle = new Pistol("DesertEagle", 7);

            //Indexer<Guns> guns = new Indexer<Guns>();
            //Indexer<AssaultRifle> assaultRifles = new Indexer<AssaultRifle>();

            //assaultRifles.Add(ak47);
            //guns.Add(ak47);
            //guns.Add(awp);
            //guns.Add(deserteagle);
            //for (int i = 0; i < guns.Length; i++)
            //{
            //    Console.WriteLine(guns[i].Info());
            //}
            Menu();
        }

        public static void Menu()
        {
            int useGunInput = 0;
            int createGunInput = 0;

            PrintPoster();
        START:
            Console.WriteLine("Press 1 - Use exist weapon\n" +
                              "Press 2 - Create new weapon\n" +
                              "Press 3 - Remove exist weapon\n" +
                              "Press 0 - Exit\n");
            Console.Write("Enter your answer: ");
            string menuIputString = Console.ReadLine();
            int menuInpit;
            try
            {
                menuInpit = Convert.ToInt32(menuIputString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!\n" +
                                  "Please try again\n");
                goto START;
            }

            switch (menuInpit)
            {
                case 1:
                    useGunInput = UseGunInput();
                    break;
                case 2:
                    createGunInput = CreateGunInput();
                    break;
                case 3:

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

            switch (useGunInput)
            {
                case 1:
                    break;
                case 2:
                    
                    break;
                case 3:

                    break;
                case 4:
                    break;
                case 0:
                    Console.Clear();
                    goto START;
            }

            switch (createGunInput)
            {
                case 1:
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    break;
                case 0:
                    Console.Clear();
                    goto START;
            }

        END:;
        }

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
        
        public static void PrintGunTypes()
        {
            Console.WriteLine("1 - Assault Rifle\n" +
                              "2 - Pistol\n" +
                              "3 - SMG\n" +
                              "4 - Assault Rifle\n" +
                              "0 - Go Back");
            Console.Write("Enter your answer: ");
        }

        public static int UseGunInput()
        {
            Console.Clear();
        ERROR1:
            Console.WriteLine("Which type gun will you use?");
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

        public static int CreateGunInput()
        {
            Console.Clear();
        ERROR2:
            Console.WriteLine("Which type gun will you create?");
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
                goto ERROR2;
            }

            return input;
        }
    }     
}
