using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Repository
{
    public class CafeMeal
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string ListOfIngredients { get; set; }
        public decimal MealPrice { get; set; }

        public CafeMeal() { }

        public CafeMeal(int mealNumber, string mealName, string mealDescription, string listOfIngredients, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            MealPrice = mealPrice;
        }
    }
}
