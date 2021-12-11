using ChallengeTwo.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwo.Tests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepo _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            _claim = new Claim(ClaimType.Car, "Car Accident", 1032.32m, new DateTime(2021, 3, 3), new DateTime(2021, 4, 30), true);

            _repo.CreateClaim(_claim);
        }

        [TestMethod]
        public void CreateClaim_ShouldNotGetNull()
        {
            List<Claim> claims = _repo.GetAllClaims();

            Assert.IsNotNull(claims);
        }

        [TestMethod]
        public void UpdateClaim_ShouldReturnTrue()
        {
            Claim updatedClaim = new Claim(ClaimType.Car, "Car Accident", 2032.32m, new DateTime(2021, 3, 3), new DateTime(2021, 4, 30), false);

            bool isSuccessful = _repo.UpdateClaim(1, updatedClaim);

            Assert.IsTrue(isSuccessful);
        }

        [TestMethod]
        public void DeleteClaim_ShouldReturnTrue()
        {
            bool isSuccessful = _repo.DeleteClaim(1);

            Assert.IsTrue(isSuccessful);
        }
    }
}
