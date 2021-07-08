using ChallengeOne_MenuRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeOne_Tests
{
    [TestClass]
    public class UnitTest1
    {

         [TestMethod]
        public void AddMealName_ShouldSetCorrectString()
        {
            //Arrange
            Menu newContent = new Menu(2222, "mealname", "mealdesc", "mealing", 200m);

            //Act
            newContent.MealName = "The Tasty Burger";

            //Assert
            string expected = "The Tasty Burger";
            string actual = newContent.MealName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetMealID_ShouldSetCorrectInt()
        {
            //Arrange
            Menu newContent = new Menu();

            //Act
            newContent.MealID = 9999;

            //Assert
            int expected = 9999;
            int actual = newContent.MealID;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange
            Menu testContent = new Menu(2222, "mealname", "mealdesc", "mealing", 200m);
            MenuItemRepository repo = new MenuItemRepository();
            repo.AddContentToDirectory(testContent);
            Menu foundContent = repo.GetContentByMealID(2222);

            //Act
            bool removeResult = repo.DeleteExistingContent(testContent);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
