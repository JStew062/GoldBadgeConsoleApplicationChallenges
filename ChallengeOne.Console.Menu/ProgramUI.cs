using ChallengeOne_MenuRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_MenuConsole
{
    class ProgramUI
    {
        protected readonly MenuItemRepository _menuItemDirectory = new MenuItemRepository();

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
                    "Enter the number of the option you would like to select: \n" +
                    "1. List all menu items.\n" +
                    "2. Create a new menu item. \n" +
                    "3. Remove an item from the menu. \n" +
                    "4. Exit.. \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllMenuItems();
                        break;
                    case "2":
                        AddNewMenuItem();
                        break;
                    case "3":
                        RemoveMenuItem();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4 \n" +
                            "Press Enter to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllMenuItems()
        {
            Console.Clear();

            // Get Content
            List<Menu> listOfContent = _menuItemDirectory.GetContents();
            //Loop through Contents
            foreach (Menu content in listOfContent)
            {
                //Console Write (Dispaly Content)
                DisplayContent(content);
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
        //Add a New MenuItem
        private void AddNewMenuItem()
        {
            //int MealID
            Console.Write("Please enter a MealID: (1-10,000)" );
            int mealid = int.Parse(Console.ReadLine());

            //string Meal Name
            Console.Write("Please enter the name of the meal." );
            string mealname = Console.ReadLine();

            //string Meal Description
            Console.Write("Please enter a description of the meal." );
            string mealdesc = Console.ReadLine();

            //string Meal Ingredients
            Console.Write("Please enter the ingredients of the meal." );
            string mealing = Console.ReadLine();

            //decimal Meal Price
            Console.Write("Please enter the price of this meal." );
            decimal mealprice = Decimal.Parse(Console.ReadLine());


            Menu meal = new Menu(mealid, mealname, mealdesc, mealing, mealprice);
            _menuItemDirectory.AddContentToDirectory(meal);
        }
        //Delete Content
        private void RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Which Menu Item would you like to remove?");

            //setting up a counter for future use
            int count = 0;

            //DisplayAllContent
            List<Menu> contentList = _menuItemDirectory.GetContents();
            foreach (Menu content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.MealID}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            //Did I get valid input
            if (targetIndex >= 0 && targetIndex <= contentList.Count)
            {
                //Delete the content
                //Selecting object to be deleted
                Menu targetContent = contentList[targetIndex];
                _menuItemDirectory.DeleteExistingContent(targetContent);

                //check to see if deleted
                if (_menuItemDirectory.DeleteExistingContent(targetContent))
                {
                    //success Message
                    Console.WriteLine($"{targetContent.MealID} removed from repo:");
                }
                else
                {
                    //fail message
                    Console.WriteLine("Sorry, someting went wrong");
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
        }

        //Display Menu Content
        private void DisplayContent(Menu content)
        {
            Console.WriteLine($"Meal ID: {content.MealID}\n" +
                   $"Meal Name: {content.MealName}\n" +
                   $"Meal Description: {content.MealDesc}\n" +
                   $"Meal Ingredients: {content.MealIng}\n" +
                   $"Meal Price: {content.MealPrice.ToString("C2")}\n");
        }

        private void WriteAndRead()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        //Seed Method
        private void SeedContentList()
        {
            Menu meal1 = new Menu(1111, "Hamburger", "It's a delicious Hamburger", "Ground Steak Patty, & fixins if you want 'em, on a toasty bun", 2.50m);
            Menu meal2 = new Menu(2222, "Beans", "They're beans","Again - They're beans", 1.75m);
            Menu meal3 = new Menu(3333, "A Drink", "A frosty beverage","Probably a Diet Coke. I'm I right?", 2.00m);

            _menuItemDirectory.AddContentToDirectory(meal1);
            _menuItemDirectory.AddContentToDirectory(meal2);
            _menuItemDirectory.AddContentToDirectory(meal3);
        }
    }
}
