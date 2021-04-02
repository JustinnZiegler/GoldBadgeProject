using CafeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ProgramUI
    {
        private readonly MenuClass _menuClass = new MenuClass();
        private readonly MenuRepoClass _menuRepo = new MenuRepoClass();

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

                Console.WriteLine("Welcome to Justinn's Cafe!\n" +
                    "Please select the item you wish to learn more about!\n" +
                    "1: Display All Cafe Meals\n" +
                    "2: Choose Meal By Name\n" +
                    "3: Add New Menu Items\n" +
                    "4: Delete Menu Items\n" +
                    "5: Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AllCafeMeals();
                        break;
                    case "2":
                        MealByName();
                        break;
                    case "3":
                        AddMenuItems();
                        break;
                    case "4":
                        DeleteCafeItems();
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

        private void AllCafeMeals()
        {
            Console.Clear();

            List<MenuClass> listOfItems = _menuRepo.GetItems();
            foreach (MenuClass Items in listOfItems)
            {
                DisplayItems(Items);
            }
            Console.WriteLine("Please press any key to continue....");
            Console.ReadKey();
        }

        private void MealByName()
        {
            Console.Clear();
            Console.WriteLine("Please enter a Meal Name!");
            string mealName = Console.ReadLine();
            MenuClass Items = _menuRepo.GetItemsByMealName(mealName);
            if (Items != null)
            {
                DisplayItems(Items);
            }
            else
            {
                Console.WriteLine("Not a Meal Name. Please try again.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void AddMenuItems()
        {
            Console.Clear();
            MenuClass Items = new MenuClass();

            Console.WriteLine("Cafe Meal Creation Page!");

            Console.WriteLine("Please enter a meal number.");
            Items.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a meal name.");
            Items.MealName = Console.ReadLine();

            Console.WriteLine("Please enter meal description.");
            Items.Description = Console.ReadLine();

            Console.WriteLine("Please enter a list of ingredients.");
            Items.Ingredients = Console.ReadLine();

            Console.WriteLine("Please set a price for the meal.");
            Items.Price = double.Parse(Console.ReadLine());

            _menuRepo.AddContentToDirectory(Items);
        }

        private void DeleteCafeItems()
        {
            Console.WriteLine("Which item would you like to delete?");
            List<MenuClass> ItemsList = _menuRepo.GetItems();
            int count = 0;
            foreach (MenuClass Items in ItemsList)
            {
                count++;
                Console.WriteLine($"{count}. {Items.MealNumber}");
            }

            int DesiredMealNum = int.Parse(Console.ReadLine());
            int DesiredMealNa = DesiredMealNum - 1;

            if (DesiredMealNa >= 0 && DesiredMealNa < ItemsList.Count)
            {
                MenuClass DesiredItems = ItemsList[DesiredMealNa];

                if (_menuRepo.DeleteCafeItems(DesiredItems))
                {
                    Console.WriteLine($"{DesiredItems.MealNumber} was removed successfully!");
                }
                else
                {
                    Console.WriteLine("I'm Sorry, Mr. Doe, I am unable to do that.");
                }
            }
            else
            {
                Console.WriteLine("No item has that number.");
            }
            Console.WriteLine("Press any key to continue.......");
            Console.ReadKey();
        }

        private void DisplayItems(MenuClass Items)
        {
            Console.WriteLine($"MealNumber: {Items.MealNumber}\n" +
                $"MealName: {Items.MealName}\n" +
                $"Description: {Items.Description}\n" +
                $"Ingredients: {Items.Ingredients}\n" +
                $"Price: {Items.Price}");
        }
        private void Seed()
        {
            MenuClass supremesteak = new MenuClass(1, "Supreme Steak",
                "A fillet mignon thickly cut from one of our Wagyu cows.",
                "Ingredients include: steak from our Wagyu cows, sauteed onions, and mushrooms.",
                99.99d);
            
            MenuClass meatynachos = new MenuClass(2, "Meaty Nachos",
                "A variety of delicous meats served with various scrumptious toppings.",
                "A heaping pile of steak, beef, chicken, and shrimp, served atop a plethora of nachos, and doused in our 5-cheese queso, pico de gallo, sour cream, and mild salsa.",
                49.99d);
            
            MenuClass monsterburger = new MenuClass(3, "Monster Burger",
                "A Wagyu burger grilled to perfection and smattered with select toppings.",
                "Ingredients include: two pounds of ground beef from out Wagyu cows, aged cheese, lettuce, onions, pickles, special house sauce, all served on a sesame seed bun.",
                24.99d);
            _menuRepo.AddContentToDirectory(supremesteak);
            _menuRepo.AddContentToDirectory(meatynachos);
            _menuRepo.AddContentToDirectory(monsterburger);
        }
    }
}
