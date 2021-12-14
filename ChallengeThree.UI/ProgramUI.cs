using ChallengeThree.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.UI
{
    public class ProgramUI
    {
        private BadgeRepo _repo;
        public void Run()
        {
            Seed();
            Menu();
        }

        private void Seed()
        {
            _repo = new BadgeRepo();
            Badge badgeOne = new Badge(5817, new List<string> { "A1", "B2" }, "Ellie Hong");
            Badge badgeTwo = new Badge(3418, new List<string> { "A1", "B2", "C4" }, "Brian Leppert");
            Badge badgeThree = new Badge(5817, new List<string> { "A1", "B2", "D5" }, "Echo Hong");

            _repo.CreateBadge(badgeOne.BadgeID, badgeOne.DoorNames);
            _repo.CreateBadge(badgeTwo.BadgeID, badgeTwo.DoorNames);
            _repo.CreateBadge(badgeThree.BadgeID, badgeThree.DoorNames);
        }

        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("See you again soon!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, that is not an option, please select again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewBadge()
        {
            Badge newBadge = new Badge();

            Console.WriteLine("Enter user's badge ID:");
            newBadge.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine(("Enter user's first and last name:");
            newBadge.Name = Console.ReadLine();

            bool addAnotherDoor = true;

            while (addAnotherDoor)
            {
                Console.WriteLine("List a door that the user needs access to:");
                newBadge.DoorNames.Add(Console.ReadLine());

                Console.WriteLine("Any other doors? (y/n)");
                string input = Console.ReadLine().ToLower();

                if(input == "n")
                {
                    addAnotherDoor = false;
                }
            }

            _repo.CreateBadge(newBadge.BadgeID, newBadge.DoorNames);

        }
        private void EditBadge()
        {

        }   
        private void ListAllBadges()
        {

        }

    }
}
