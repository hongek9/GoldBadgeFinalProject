using ChallengeOne.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.UI
{
    public class ProgramUI
    {
        private MenuItemRepo _menuRepo = new MenuItemRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Select your action:\n" +
                    "1. Get All Menu Items\n" +
                    "2. Add a Menu Item\n" +
                    "3. Delete A Menu Item\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        GetAllMenuItems();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Hope to see you again soon!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, that is not an option, please select again.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void GetAllMenuItems()
        {
            List<MenuItem> menuItems = _menuRepo.GetAllMenuItems();
            
            foreach(MenuItem item in menuItems)
            {
                DisplayMenuItem(item);
            }

        }

        private void AddMenuItem()
        {
            MenuItem newMenuItem = new MenuItem();

            Console.WriteLine("Enter Meal Name:");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter Description:");
            newMenuItem.Description = Console.ReadLine();

            bool isDone = false;
            while (!isDone)
            {
                Console.WriteLine("Enter Ingrediant:");
                string ingrediant = Console.ReadLine();
                if(newMenuItem.Ingredients == null)
                {
                    newMenuItem.Ingredients = new List<string> { ingrediant };
                }
                else
                {
                    newMenuItem.Ingredients.Add(ingrediant);
                }
                Console.WriteLine("Add another ingrediant? (y/n");
                string addAnotherIngrediant = Console.ReadLine().ToLower();
                if(addAnotherIngrediant == "n")
                {
                    isDone = true;
                }
            }

            Console.WriteLine("Enter Meal Price:");
            newMenuItem.Price = Decimal.Parse(Console.ReadLine());

            _menuRepo.AddMenuItem(newMenuItem);
        }

        private void DeleteMenuItem()
        {
            GetAllMenuItems();

            Console.WriteLine("Enter the Meal Number you want to delete:");

            int mealNumber = int.Parse(Console.ReadLine());

            bool isSuccessful = _menuRepo.DeleteMenuItem(mealNumber);

            if (isSuccessful)
            {
                Console.WriteLine("Delete successful");
            } else
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        private void DisplayMenuItem(MenuItem menuItem)
        {
            Console.WriteLine("*******************************");
            Console.WriteLine($"Meal Number: {menuItem.MealNumber}");
            Console.WriteLine($"Meal Name: {menuItem.MealName}");
            Console.WriteLine($"Description: {menuItem.Description}");
            Console.WriteLine("Ingrediants:");
            foreach(string ingrediant in menuItem.Ingredients)
            {
                int count = 1;
                Console.WriteLine($"       Ingrediant {count}: {ingrediant}");
            }
            Console.WriteLine($"Price: {menuItem.Price}");
            Console.WriteLine("*******************************");

        }
    }
}
