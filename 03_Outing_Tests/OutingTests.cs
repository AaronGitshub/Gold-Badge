using System;
using System.Collections.Generic;
using _03_Outing_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Outing_Tests
{
    [TestClass]
    public class OutingTests
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange - 'new up' here
            OutingRepository outingRepo = new OutingRepository();


            Outing content = new Outing(TripType.Amusement, 5, DateTime.Now, 55.55m, 4000.22m);

            //Act
            outingRepo.AddToList(content);
            List<Outing> list = outingRepo.GetListOfOutings();

            //expect//actual
            var expected = 1;
            var actual = list.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateCost()
        {

            //Arrange
            OutingRepository productRepo = new OutingRepository();
            Outing content1 = new Outing(TripType.Amusement, 5, DateTime.Now, 50.00m, 4455.22m);
            Outing content2 = new Outing(TripType.Amusement, 5, DateTime.Now, 50.00m, 4455.22m);

            productRepo.AddToList(content1);
            productRepo.AddToList(content2);

            //Act

            //content1.CostOfEvent = productRepo.CalculateAllOutingsByType(3);
            ///STOPPED HERE/////


            ///expect ///Actual
            var expected = 8910.44m;
            var actual = productRepo.CalculateAllOutingsByType(3);

            ///Assert
            Assert.AreEqual(expected, actual);
            
        }




    }
}
