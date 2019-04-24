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
        

    }
}
