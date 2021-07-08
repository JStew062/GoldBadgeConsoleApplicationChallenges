using ChallengeThree_BadgesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_BadgesConsole
{
    class ProgramUI
    {
        protected readonly BadgesRepository _badgesItemDirectory = new BadgesRepository();

        public void Run()
        {
            SeedContentList();
            DisplayFormat();
        }
        private void DisplayFormat()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Hello Security Admin.  What would you like to do? \n" +
                    "1. Create a new badge.\n" +
                    "2. Update doors on an existing badge. \n" +
                    "3. Delete all doors from an existing badge. \n" +
                    "4. Show a list with all badge numbers and the doors they access. \n" +
                    "5. Exit.. \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        //UpdateBadge();
                        break;
                    case "3":
                        //RemoveDoorsFromBadge();
                        break;
                    case "4":
                        ListAllBadges();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5 \n" +
                            "Press Enter to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreateNewBadge()
        {
            Badges badges = new Badges();
            Console.Write("What is the number on the badge?");
            badges.BadgeID = int.Parse(Console.ReadLine());

            Console.Write("List a door it needs access to:");
            List<string> doorlist = new List<string>();
            string door = (Console.ReadLine());
            doorlist.Add(door);

            bool doorlisty = true;
            while (doorlisty)
            {
                Console.Write("Any other doors?");
                string option = Console.ReadLine();
                if (option == "y")
                {
                    Console.Write("List a door it needs access to:");
                    string doors = (Console.ReadLine());
                    doorlist.Add(doors);
                }
                else
                {
                    doorlisty = false;
                }
            }
            badges.Doors.AddRange(doorlist);
            _badgesItemDirectory.AddBadgeToDirectory(badges);
        }


        private void UpdateBadge()
        {
            Console.WriteLine("What is the number on the badge?");
            int badgeid = int.Parse(Console.ReadLine());

        }

        private void ListAllBadges()
        {
            Console.Clear();

            // Get Content
            Dictionary<int, List<string>> listOfContent = _badgesItemDirectory.GetContents();
            //Loop through Contents
            foreach (KeyValuePair<int, List<string>> kv in listOfContent)
            {
                Console.WriteLine(kv.Key.ToString());
                foreach (string doorname in kv.Value)
                {
                    Console.WriteLine(doorname);
                }
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        //Seed Method
        public void SeedContentList()
        {
            List<string> Doors = new List<string>();

            Badges badge1 = new Badges(1111, Doors = new List<string> { "A1" });
            Badges badge2 = new Badges(2222, Doors = new List<string> { "B2", "C3" });
            Badges badge3 = new Badges(3333, Doors = new List<string> { "B2", "C3", "D4" });

            _badgesItemDirectory.AddBadgeToDirectory(badge1);
            _badgesItemDirectory.AddBadgeToDirectory(badge2);
            _badgesItemDirectory.AddBadgeToDirectory(badge3);
        }
    }
}

