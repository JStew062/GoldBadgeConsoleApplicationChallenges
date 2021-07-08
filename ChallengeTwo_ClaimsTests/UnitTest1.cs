using ChallengeTwo_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeTwo_ClaimsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            void AddAClaimDescription_ShouldSetCorrectString()
            {
                //Arrange

                Claims newContent = new Claims(9, "claimtype", "claimdesc", 20, new DateTime(2018, 04, 25), new DateTime(2018, 05, 21));

                //Act
                newContent.ClaimDesc = "New Test Description";

                //Assert
                string expected = "New Test Description";
                string actual = newContent.ClaimDesc;
                Assert.AreEqual(expected, actual);
            }

        }

        [TestMethod]
        public void SetClaimlID_ShouldSetCorrectInt()
        {
            //Arrange
            Claims newContent = new Claims();

            //Act
            newContent.ClaimID = 9999;

            //Assert
            int expected = 9999;
            int actual = newContent.ClaimID;
            Assert.AreEqual(expected, actual);
        }
    }
}
