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
            Badge badgeThree = new Badge(2874, new List<string> { "A1", "B2", "D5" }, "Echo Hong");

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

            Console.WriteLine("Enter user's first and last name:");
            newBadge.Name = Console.ReadLine();

            bool addAnotherDoor = true;

            while (addAnotherDoor)
            {
                Console.WriteLine("List a door that the user needs access to:");
                
                if(newBadge.DoorNames == null)
                {
                    newBadge.DoorNames = new List<string> { Console.ReadLine() };
                } else
                {
                    newBadge.DoorNames.Add(Console.ReadLine());
                }

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
            ListAllBadges();

            Console.WriteLine("Enter the BadgeID that you want to edit:");
            int badgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("What action would you like to do?\n" +
                "1. Add a Door\n" +
                "2. Remove a Door");

            string userAction = Console.ReadLine();

            if(userAction == "1")
            {
                Console.WriteLine("Enter door you would like access:");
                string newDoor = Console.ReadLine();

                bool isSuccessful = _repo.AddDoorToBadge(badgeId, newDoor);
                if (isSuccessful)
                {
                    Console.WriteLine("Door sucessfully added to user.");
                } else
                {
                    Console.WriteLine("Sorry, something went wrong.");
                }
            } else
            {
                Console.WriteLine("Enter the door you would like to remove:");
                string doorToRemove = Console.ReadLine();

                bool isSuccessful = _repo.RemoveDoorOnBadge(badgeId, doorToRemove);
                if (isSuccessful)
                {
                    Console.WriteLine("Door sucessfully removed from user.");
                }
                else
                {
                    Console.WriteLine("Sorry, something went wrong.");
                }
            }

            
        }   
        private void ListAllBadges()
        {
            Console.WriteLine("{0,-8} | {1,10}", "Badge ID", "Door Access");

            Dictionary<int, List<string>> badges = _repo.GetAllBadges();

            foreach(var badge in badges)
            {
                DisplayBadge(badge.Key, badge.Value);
            }
        }

        private void DisplayBadge(int badgeId, List<string> doors)
        {
            Console.Write("{0,-8} |", badgeId);
            doors.ForEach(i => Console.Write("{0}, ", i));
            Console.WriteLine();
            
        }

    }
}
