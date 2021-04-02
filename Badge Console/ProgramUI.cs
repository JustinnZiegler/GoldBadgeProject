using Badge_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Console
{
    public class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            Seed();
            RunApp();
        }

        private void RunApp()
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("Hey Boss, What can I help you with?\n" +
                    "" +
                    "1. Create a New Badge\n" +
                    "" +
                    "2. Update a Badge\n" +
                    "" +
                    "3. View All Badges\n" +
                    "" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        isWorking = false;
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    default:
                        break;

                }
            }
        }

        private void CreateBadge()
        {
            Console.Clear();

            BadgeClass badgeID = new BadgeClass();

            Console.WriteLine("Please enter in a new badge ID number!");
            int userInputID = int.Parse(Console.ReadLine());
            badgeID.BadgeID = userInputID;

            Console.WriteLine("Please enter all doors this key will have access to. Seperate via a comma and a space. (Ex: A1, B2, C3, etc.)");
            string userInputDoorNames = Console.ReadLine();
            badgeID.ListOfDoorNames = userInputDoorNames;
            _badgeRepo.AddBadgeDB(badgeID);
        }

        private void UpdateBadge()
        {
            Console.Clear();

            Console.WriteLine("What badge ID do you want to update? Be sure to choose an already existing badge!");
            int userInputNewBadge = int.Parse(Console.ReadLine());

            BadgeClass newBadgeClass = new BadgeClass();

            Console.WriteLine("Please enter all doors this key will have access to. Seperate via a comma and a space. (Ex: A1, B2, C3, etc.)");
            string newBadgeDoorNames = Console.ReadLine();
            newBadgeClass.ListOfDoorNames = newBadgeDoorNames;

            _badgeRepo.UpdateBadge(userInputNewBadge, newBadgeClass);
        }

        private void ViewAllBadges()
        {
            Console.Clear();

            foreach (var badgeID in _badgeRepo.GetListOfDoorNames())
            {
                Console.WriteLine($"Badge ID: {badgeID.Value.BadgeID}\n" +
                    $"Door Access: {badgeID.Value.ListOfDoorNames}\n" +
                    $"\n" +
                    $"");
            }
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }

        private void Seed()
        {
            BadgeClass badgeOne = new BadgeClass(1, "A1, B1, C1");
            BadgeClass badgeTwo = new BadgeClass(2, "A5, B5, C5");
            BadgeClass badgeThree = new BadgeClass(3, "A10, B10, C10");

            _badgeRepo.AddBadgeDB(badgeOne);
            _badgeRepo.AddBadgeDB(badgeTwo);
            _badgeRepo.AddBadgeDB(badgeThree);

        }
    }
}