using System;
using System.Collections.Generic;
using _05_Greet_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Greet_Tests
{
    [TestClass]
    public class GreetCustomerTests
    {
        [TestMethod]
        public void AddTest()
        {
            //This also tests the GetList

            //Arrange - 'new up' here
            CustomerRepository customerRepo = new CustomerRepository();


            Customer content = new Customer(CustomerType.Potential, 1, "Aaron", "Wood", "It's been a long time since we've heard from you, we want you back.");

            //CustomerType customerType, int customerID, string firstName, string lastName, string emailMessage

            //Act
            customerRepo.AddToList(content);
            List<Customer> list = customerRepo.GetListOfCustomers();

            //expect//actual
            var expected = 1;
            var actual = list.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        ///Test Remove 
        [TestMethod]
        public void DeleteTest()
        {
            CustomerRepository customerRepo = new CustomerRepository();
            //add 3
            Customer content = new Customer(CustomerType.Potential, 1, "Aaron", "Wood", "We currently have the lowest rates on Helicopter Insurance!");
            Customer content2 = new Customer(CustomerType.Current, 2, "Brian", "Fisher", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            Customer content3 = new Customer(CustomerType.Past, 3, "Steve", "Fisher", "It's been a long time since we've heard from you, we want you back.");

            customerRepo.AddToList(content);
            customerRepo.AddToList(content2);
            customerRepo.AddToList(content3);

            //remove 1
            customerRepo.RemoveCustomer(1);
            List<Customer> list = customerRepo.GetListOfCustomers();

            var expected = 2;
            var actual = list.Count;

            //test for 2
            Assert.AreEqual(expected, actual);
        }
    }
}
