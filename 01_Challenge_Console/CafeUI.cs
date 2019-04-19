using _01_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Console
{
    public class CafeUI
    {
        //private CafeMeal _menuRepo = new CafeMeal(); this pointed at the Meal method
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("What would you like to do?\n     " +
                    "1. Add a Menu Item\n" +
               "2. Print all Orders.\n" +
               "3. Remove an Order.\n" +
               "4. Exit\n");

                int input = ParseInput();

                switch (input)
                {
                    case 1:
                        //Add content (method call goes here)
                        AddMenuItem();
                        break;
                    case 2:
                        //Get list and print to screen/console
                        PrintMenuItem();
                        break;
                    case 3:
                        //Remove a menu item
                        RemoveMenu();
                        break;
                    case 4:
                        //exit
                        running = false;
                        break;

                }
            }
        }

        private void AddMenuItem()
        {
            //MealNumber = mealNumber;
            Console.WriteLine("What is the meal number?");
            int mealNumber = int.Parse(Console.ReadLine());

            //MealName = mealName;
            Console.WriteLine("What is the meal name?");
            string mealName = Console.ReadLine();

            //MealDescription = mealDescription;
            Console.WriteLine("Describe the meal, please.");
            string mealDescription = Console.ReadLine();

            //ListOfIngredients = listOfIngredients;
            Console.WriteLine("Write the Ingredients");
            string listOfIngredients = Console.ReadLine();

            //MealPrice = mealPrice;
            Console.WriteLine("What is the price of this meal?");
            decimal mealPrice = decimal.Parse(Console.ReadLine());

            CafeMeal order = new CafeMeal(mealNumber, mealName, mealDescription, listOfIngredients, mealPrice);

            _menuRepo.AddMenuItem(order);
                                 
        }

        private void PrintMenuItem()
        {
            List<CafeMeal> list = _menuRepo.GetMenuItems();

            foreach (CafeMeal order in list)
            {
                Console.WriteLine($"Meal Number: {order.MealNumber}\n Meal Name: {order.MealName}\n Meal Description: {order.MealDescription}\n List of Ingredients: {order.ListOfIngredients}\n Meal Price: {order.MealPrice}");
            }
            Console.ReadKey();
        }

        private void RemoveMenu()
        {
            //ask user which order they want to remove.
            //get orderID from baker
            // send the orderNumber to the repo method

            Console.WriteLine("What menu item would you like to remove? Please provide the menu item number.");
                int anynumber = int.Parse(Console.ReadLine());

            _menuRepo.RemoveFromList(anynumber);

        }

        private int ParseInput()
        {
            int input = int.Parse(Console.ReadLine());
            if (input < 1 || input > 4)
            {
                Console.WriteLine("Your input was invalid, please enter a valid menu number.");
                input = ParseInput();
            }
            return input;
        }


    }
}
