using ChallengeTwo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.UI
{
    class ProgramUI
    {
        private ClaimRepo _repo = new ClaimRepo();

        public void Run()
        {
            Seed();
            Menu();
        }

        private void Seed()
        {
            Claim claimOne = new Claim(ClaimType.Car, "Car Accident", 1032.32m, new DateTime(2021, 3, 3), new DateTime(2021, 4, 30), true);
            Claim claimTwo = new Claim(ClaimType.Home, "Home Fire", 10032.87m, new DateTime(2021, 5, 12), new DateTime(2021, 6, 29), true);
            Claim claimThree = new Claim(ClaimType.Theft, "Car Stolen", 50032.59m, new DateTime(2020, 12, 4), new DateTime(2020, 12, 17), true);

            _repo.CreateClaim(claimOne);
            _repo.CreateClaim(claimTwo);
            _repo.CreateClaim(claimThree);
        }

        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Choose a selection:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("See you again soon!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, that is not a selection. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }       
        }

        private void SeeAllClaims()
        {
            List<Claim> claims = _repo.GetAllClaims();

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-8} | {1,-5} | {2,-15} | {3,-12}  | {4,-15} | {5,-12} | {6,-5}", "ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            foreach (Claim claim in claims)
            {
                DisplayClaim(claim);
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------");

        }
        private void TakeCareOfNextClaim()
        {
            List<Claim> claims = _repo.GetAllClaims();

            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-8} | {1,-5} | {2,-15} | {3,-12}  | {4,-15} | {5,-12} | {6,-5}", "ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            DisplayClaim(claims[0]);
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            Console.WriteLine("Would you like to handle this claim now? (y/n)");

            string userInput = Console.ReadLine().ToLower();

            if(userInput == "y")
            {
                _repo.DeleteClaim(claims[0].ClaimID); // maybe this is right?
            } 
        }
        private void EnterNewClaim()
        {
            Claim newClaim = new Claim();

            Console.WriteLine("Enter number for Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            newClaim.TypeOfClaim = (ClaimType)int.Parse(Console.ReadLine());

            Console.WriteLine("Enter claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter Amount of Damage:");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Month Accident Occurred: (1-12)");
            int accidentMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Day Accident Occurred: (1-31)");
            int accidentDay = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Year Accident Occurred: (e.g.2021)");
            int accidentYear = int.Parse(Console.ReadLine());

            newClaim.DateOfIncident = new DateTime(accidentYear, accidentMonth, accidentDay);

            Console.WriteLine("Enter Month Claim Filed: (1-12)");
            int claimMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Day Claim Filed: (1-31)");
            int claimDay = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Year Claim Filed: (e.g.2021)");
            int claimYear = int.Parse(Console.ReadLine());

            newClaim.DateOfClaim = new DateTime(claimYear, claimMonth, claimDay);

            Console.WriteLine("Is this claim valid? (y/n)");
            string claimValid = Console.ReadLine().ToLower();

            if(claimValid == "y")
            {
                newClaim.IsValid = true;
            } else
            {
                newClaim.IsValid = false;
            }

            _repo.CreateClaim(newClaim);
            
        }
        private void DisplayClaim(Claim claim)
        {
            Console.WriteLine("{0,-8} | {1,-5} | {2,-15} | ${3,-12} | {4,-15} | {5,-12} | {6,-5}", claim.ClaimID, claim.TypeOfClaim, claim.Description, claim.ClaimAmount, claim.DateOfIncident.ToString("MM/dd/yyyy"), claim.DateOfClaim.ToString("MM/dd/yyyy"), claim.IsValid);
        }
    }
}
