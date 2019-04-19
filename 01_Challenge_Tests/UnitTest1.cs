using System;
using System.Collections.Generic;
using _01_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange - 'new up' here
            MenuRepository menuRepo = new MenuRepository();

            CafeMeal content = new CafeMeal(1, "Roast Beef Combo", "Meat Burger and Fries", "Bun, burger, fries, special sauce", 9.99m);

            //Act
            //MenuRepository
            menuRepo.AddMenuItem(content);
            List<CafeMeal> list = menuRepo.GetMenuItems();
            ////List<CafeMeal> list = MenuRepository


            //expect //actual
            int expected = 1;
            ///content.count; need to count list
            int actual = list.Count;
                       
            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
