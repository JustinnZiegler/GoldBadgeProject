using ClaimsLibrary;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsConsole
{
    class ProgramUI
    {
        private readonly ClaimClass _claimClass = new ClaimClass();
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to Justinn's Claim Assistance!\n" +
                    "Please select the item you wish to execute!\n" +
                    "1: View All Current Claims\n" +
                    "2: Take Care of Next Claim\n" +
                    "3: Add a New Claim\n" +
                    "4: Delete a Claim\n" +
                    "5: Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        DeleteClaim();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n" +
                            "Press any key to continue...........");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ViewAllClaims()
        {
            Console.Clear();

            List<ClaimClass> listOfclaimContent = _claimsRepo.GetclaimContent();
            foreach (ClaimClass claimContent in listOfclaimContent)
            {
                DisplayItems(claimContent);
            }
            Console.WriteLine("Please press any key to continue....");
            Console.ReadKey();
        }
        private void NextClaim()
        {
            Console.Clear();

            ClaimClass claimClass = _claimsRepo.NextClaim();
            Console.WriteLine($"Claim: {claimClass.ClaimID} {claimClass.ClaimType} {claimClass.Description} {claimClass.ClaimAmount} {claimClass.DateOfIncident} {claimClass.DateOfClaim}");

            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            string userinput = Console.ReadLine();
            if (userinput == "y")
            {
                _claimsRepo.DeleteClaim(claimClass);
                Console.WriteLine("This claim was completed!");
            }
            Console.WriteLine("Please press any key to continue....");
            Console.ReadKey();
        }

        private void NewClaim()
        {
            Console.Clear();
            ClaimClass claimContent = new ClaimClass();

            Console.WriteLine("Claim Creation Page!");

            Console.WriteLine("Please enter a claim ID number.");
            claimContent.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the type of claim. Please select a number between 1-3.\n" +
                "1: Car\n" +
                "2: Home\n" +
                "3: Theft");
            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                    claimContent.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claimContent.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claimContent.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please select a number between 1 and 3.");
                    Console.ReadKey();
                    break;
            }

            Console.WriteLine("Please enter claim description.");
            claimContent.Description = Console.ReadLine();

            Console.WriteLine("Please enter the amount of claim.");
            claimContent.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Please set a date of incident in the format of YYYY/MM/DD.");
            claimContent.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please set a date of claim in the form of YYYY/MM/DD.");
            claimContent.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimsRepo.AddContentToDirectory(claimContent);
        }

        private void DeleteClaim()
        {
            Console.WriteLine("Which item would you like to delete?");
            List<ClaimClass> claimContentList = _claimsRepo.GetclaimContent();
            int count = 0;
            foreach (ClaimClass claimContent in claimContentList)
            {
                count++;
                Console.WriteLine($"{count}. {claimContent.ClaimID}");
            }

            int DesiredClaim = int.Parse(Console.ReadLine());
            int DesiredClaimT = DesiredClaim - 1;

            if (DesiredClaimT >= 0 && DesiredClaimT < claimContentList.Count)
            {
                ClaimClass DesiredclaimContent = claimContentList[DesiredClaimT];

                if (_claimsRepo.DeleteClaim(DesiredclaimContent))
                {
                    Console.WriteLine($"{DesiredclaimContent.ClaimID} was removed successfully!");
                }
                else
                {
                    Console.WriteLine("I'm Sorry, Mrs. Doe, I am unable to do that.");
                }
            }
            else
            {
                Console.WriteLine("No item has that number.");
            }
            Console.WriteLine("Press any key to continue.......");
            Console.ReadKey();
        }

        private void DisplayItems(ClaimClass claimContent)
        {
            Console.WriteLine($"ClaimID: {claimContent.ClaimID}\n" +
                $"ClaimType: {claimContent.ClaimType}\n" +
                $"Description: {claimContent.Description}\n" +
                $"ClaimAmount: ${claimContent.ClaimAmount}\n" +
                $"DateOfIncident: {claimContent.DateOfIncident.ToShortDateString()}\n" +
                $"DateOfClaim: {claimContent.DateOfClaim.ToShortDateString()}\n" +
                $"IsValid: {claimContent.IsValid}\n" +
                $"\n" +
                $"");
        }
        private void Seed()
        {
            DateTime incidents = new DateTime(2021, 03, 25);
            DateTime claims = new DateTime(2021, 03, 27);
            DateTime incidentsOne = new DateTime(2021, 03, 13);
            DateTime claimsOne = new DateTime(2021, 03, 15);
            DateTime incidentsTwo = new DateTime(2021, 02, 18);
            DateTime claimsTwo = new DateTime(2021, 02, 20);

            ClaimClass claimOne = new ClaimClass(1, ClaimType.Car, "Car accident on 465.", 400.00d, incidents, claims);
            ClaimClass claimTwo = new ClaimClass(2, ClaimType.Home, "House fire in kitchen.", 4000.00d, incidentsOne, claimsOne);
            ClaimClass claimThree = new ClaimClass(3, ClaimType.Theft, "Stolen bacon.", 40000000.00d, incidentsTwo, claimsTwo);

            _claimsRepo.AddContentToDirectory(claimOne);
            _claimsRepo.AddContentToDirectory(claimTwo);
            _claimsRepo.AddContentToDirectory(claimThree);
        }
    }
}
//{
    //var table = new ClaimClass(1, "Car", "Car accident on 465.", 400.00d, "3/25/21", "3/27/21");
    //table.AddRow(2, "Home", "House fire in kitchen.", 4000.00d, "3/1/21", "3/3/21");
      //           .AddRow(3, "Theft", "Stolen bacon.", 40000000.00d, "3/27/21", "3/29/21");
//}





//IEnumerable<Tuple<int, ClaimType, string, double, DateTime, DateTime>> authors = new[]
  //  {
    //            Tuple.Create(1, "Car", "Car accident on 465.", 400.00d, "3/25/21", "3/27/21"),
      //          Tuple.Create(2, "Home", "House fire in kitchen.", 4000.00d, "3/1/21", "3/3/21"),
        //        Tuple.Create(3, "Theft", "Stolen bacon.", 40000000.00d, "3/27/21", "3/29/21"),
          //  };

//Console.WriteLine(authors.ToStringtable(new[] {"ID", "Claim Type", "Description", "Claim Amount",
  //              "Date of Incident", "Date of Claim"}, a =);