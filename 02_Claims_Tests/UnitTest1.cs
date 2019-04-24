using System;
using _02_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ClaimQueue_AddToQueue_ShouldSeeContentOnQueue()
        {
            // Arrange
            ClaimQueueRepository claimRepo = new ClaimQueueRepository();

            Claim content = new Claim(1, "House", "Fire", 400.00m, new DateTime(2019, 4, 15), new DateTime(2019, 4, 22), true);

            // Act
            claimRepo.AddToQueue(content);
            Claim claimContent = claimRepo.PeekNextContent();


            //expect //actual
           // int actual = list.Count;
           // int expected = 1;

            //Assert
            Assert.AreSame(content, claimContent);

            ///left off here.
        }
        
        [TestMethod]
        public void ClaimContent_GetQueueCount_ShouldReturnCorrectInt()
        {
            //arrange
            ClaimQueueRepository claimRepo = new ClaimQueueRepository();
              Claim content = new Claim(1, "House", "Fire", 400.00m, new DateTime(2019, 4, 15), new DateTime(2019, 4, 22), true);

            //Act
            claimRepo.AddToQueue(content);
           
              //expect //actual
              var expected = 1;
              var actual = claimRepo.GetQueueContentsCount();

              //Assert
              Assert.AreEqual(expected, actual);

          }
          
        }


