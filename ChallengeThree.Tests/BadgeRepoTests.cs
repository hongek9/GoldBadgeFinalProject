using ChallengeThree.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThree.Tests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private BadgeRepo _repo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _badge = new Badge(5817, new List<string> { "A1", "B2" }, "Ellie Hong");

            _repo.CreateBadge(_badge.BadgeID, _badge.DoorNames);
        }

        [TestMethod]
        public void CreateBadge_ShouldNotGetNull()
        {
            Dictionary<int, List<string>> badges = _repo.GetAllBadges();

            Assert.IsNotNull(badges);
        }

        [TestMethod]
        public void AddDoorToBadge_ShouldReturnTrue()
        {
            bool isSuccessful = _repo.AddDoorToBadge(5817, "C2");

            Assert.IsTrue(isSuccessful);
        }

        [TestMethod]
        public void RemoveDoorFromBadge_ShouldReturnTrue()
        {
            bool isSuccessful = _repo.RemoveDoorOnBadge(5817, "A1");

            Assert.IsTrue(isSuccessful);
        }
    }
}
