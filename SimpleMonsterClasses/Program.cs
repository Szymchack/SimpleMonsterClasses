using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMonsterClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }


        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to Simple Monster Classes");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static SeaMonster InitializeSeaMonsterSid(string name)
        {
            SeaMonster sid = new SeaMonster("Sid");
            sid.Weight = 2.5;
            sid.CanUseFreshwater = true;
            sid.CurrentEmotionalState = SeaMonster.EmotionalState.Meloncoly;
            sid.HomeSea = "The Dead Sea";

            return sid;
        }

        static SeaMonster InitializeSeaMonsterSuzy()
        {
            SeaMonster suzy = new SeaMonster();

            suzy.Name = "Suzy";
            suzy.Weight = 1.2;
            suzy.CanUseFreshwater = true;
            suzy.CurrentEmotionalState = SeaMonster.EmotionalState.Happy;
            suzy.HomeSea = "The Baltic Sea";

            return suzy;
        }

        static void DisplaySeaMonsterInfo(List<SeaMonster> seaMonsters)
        {
            SeaMonster userSeaMonster = new SeaMonster();
            string seaMonsterName;

            DisplayHeader("Display Sea Monsters Info");

            //
            //display list of sea monster names
            //

            foreach (SeaMonster seaMonster in seaMonsters)
            {
                Console.WriteLine(seaMonster.Name);
            }

            Console.WriteLine();
            Console.Write("Enter Name:");
            seaMonsterName = Console.ReadLine();

            DisplayContinuePrompt();

            //
            // Get Seamonster from list
            //

            bool monsterFound = false;

            foreach (SeaMonster seaMonster in seaMonsters)
            {
                if (seaMonster.Name == seaMonsterName)
                {
                    Console.WriteLine(seaMonster.Name);
                    Console.WriteLine(seaMonster.Weight);
                    Console.WriteLine(seaMonster.CanUseFreshwater);
                    Console.WriteLine(seaMonster.CurrentEmotionalState);
                    Console.WriteLine(seaMonster.HomeSea);
                    monsterFound = true;
                    break;
                }
                //
                // Feedback - monster not found
                //
                if (!monsterFound)
                {
                    Console.WriteLine("Unable to Locate Monster");
                }


                DisplayContinuePrompt();

            }
            
        }

        static void DisplayDeleteSeaMonsterInfo(List<SeaMonster> seaMonsters)
        {
            SeaMonster userSeaMonster = new SeaMonster();
            string seaMonsterName;

            DisplayHeader("Delete Sea Monsters Info");

            //
            //display list of sea monster names
            //

            foreach (SeaMonster seaMonster in seaMonsters)
            {
                Console.WriteLine(seaMonster.Name);
            }

            Console.WriteLine();
            Console.Write("Enter Name:");
            seaMonsterName = Console.ReadLine();

            DisplayContinuePrompt();

            //
            // Get Seamonster from list
            //

            bool monsterFound = false;

            foreach (SeaMonster seaMonster in seaMonsters)
            {
                if (seaMonster.Name == seaMonsterName)
                {
                    seaMonsters.Remove(seaMonster);
                    monsterFound = true;
                    break;
                }
                //
                // Feedback - monster not found
                //
                if (!monsterFound)
                {
                    Console.WriteLine("Unable to Locate Monster");
                }


                DisplayContinuePrompt();

            }

        }


        static void DisplayAllSeaMonsters(List<SeaMonster> seaMonsters)
        {
            DisplayHeader("List of Sea Monsters");

            foreach (SeaMonster seaMonster in seaMonsters)
            {
                Console.WriteLine(seaMonster.SeaMonsterAttitude());
            }
        }

        static void DisplayGetUserSeaMonster(List<SeaMonster> seaMonsters)
        {
            //
            // create (instantieate) a new Seamonster object
            //

            SeaMonster newSeaMonster = new SeaMonster();

            DisplayHeader("Add a Sea Monster");
            //

            Console.Write("Enter Name:");
            newSeaMonster.Name = Console.ReadLine();
            Console.Write("Enter Weight:");
            double.TryParse(Console.ReadLine(), out double weight);
            newSeaMonster.Weight = weight;
            Console.Write("Can Use Freshwater:");
            if (Console.ReadLine().ToUpper()== "YES")
            {
                newSeaMonster.CanUseFreshwater = true;
            }
            Console.Write("Enter Emotional State");
            Enum.TryParse(Console.ReadLine(), out SeaMonster.EmotionalState emotionalState);
            newSeaMonster.CurrentEmotionalState = emotionalState;
            Console.Write("Enter Home Sea");
            newSeaMonster.HomeSea = Console.ReadLine();

            DisplayContinuePrompt();
        }

        static void DisplayMenu()
        {
            //
            // instantiate sea monsters
            //

            SeaMonster suzy = new SeaMonster();
            suzy = InitializeSeaMonsterSuzy();
            SeaMonster sid = new SeaMonster();
            sid = InitializeSeaMonsterSid("Sid");

            //
            // add sea monsters to list
            //

            List<SeaMonster> seaMonsters = new List<SeaMonster>();
            seaMonsters.Add(suzy);
            seaMonsters.Add(sid);



            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Display All Sea Monsters");
                Console.WriteLine("\tB) Add a Sea Monster");
                Console.WriteLine("\tC) Display Sea Monster Info");
                Console.WriteLine("\tE) Delete a Sea Monster) ");
                Console.WriteLine("\tF) Exit");

                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "A":
                    case "a":
                        DisplayAllSeaMonsters(seaMonsters);
                        break;

                    case "B":
                    case "b":
                        DisplayGetUserSeaMonster(seaMonsters);

                        break;

                    case "C":
                    case "c":
                        DisplaySeaMonsterInfo(seaMonsters);
                        break;

                    case "D":
                    case "d":
                        DisplayDeleteSeaMonsterInfo(seaMonsters);
                        break;

                    case "E":
                    case "e":

                        break;

                    case "F":
                    case "f":
                        exiting = true;
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tThanks for using Simple Monster Classes.");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display header
        /// </summary>
        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerTitle);
            Console.WriteLine();
        }
    }
}


