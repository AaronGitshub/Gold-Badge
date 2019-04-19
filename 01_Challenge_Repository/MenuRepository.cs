using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Repository
{
    public class MenuRepository
    {
        private List<CafeMeal> _cafeMeals = new List<CafeMeal>();
        public void AddMenuItem(CafeMeal content)
        {
            _cafeMeals.Add(content);
        }

        public List<CafeMeal> GetMenuItems()
        {
            return _cafeMeals;
        }

        //remove from list

        public void RemoveFromList(int mealID)
        {
            foreach (CafeMeal prod in _cafeMeals)
            {
                if (prod.MealNumber == mealID)
                {
                    _cafeMeals.Remove(prod);
                    break;
                }
            }

        }
    }
}
