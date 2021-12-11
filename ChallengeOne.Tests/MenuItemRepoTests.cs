using ChallengeOne.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOne.Tests
{
    [TestClass]
    public class MenuItemRepoTests
    {
        private MenuItemRepo _repo;
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepo();
            _menuItem = new MenuItem("Cheese Pizza", "Cheese and Marinara Sauce", new List<string> { "cheese", "dough", "marinara sauce"}, 8.00m);

            _repo.AddMenuItem(_menuItem);
        }

        [TestMethod]
        public void AddToMenu_ShouldNotGetNull()
        {
            List<MenuItem> menuItem = _repo.GetAllMenuItems();

            Assert.IsNotNull(menuItem);
        }

        [TestMethod]
        public void UpdateMenuItem_ShouldReturnTrue()
        {
            MenuItem newMenuItem = new MenuItem("Sausage Pizza", "Cheese, Sausage and Marinara Sauce", new List<string> { "sausage", "cheese", "dough", "marinara sauce" }, 10.00m);

            bool isSuccessful = _repo.UpdateMenuItem(1, newMenuItem);

            Assert.IsTrue(isSuccessful);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            bool isSuccessful = _repo.DeleteMenuItem(1);

            Assert.IsTrue(isSuccessful);
        }
    }
}
