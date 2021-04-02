using ClaimsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClaimsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]


        public void AddToDirectory_FingersCrossedBool()
        {
            ClaimClass claimContent = new ClaimClass();
            ClaimsRepo Repo = new ClaimsRepo();

            bool addResult = Repo.AddContentToDirectory(claimContent);

            Assert.IsTrue(addResult);
        }


        [TestMethod]
        public void GetDirectory_Hopefully()
        {
            ClaimClass claimContent = new ClaimClass();

            ClaimsRepo Repoz = new ClaimsRepo();

            Repoz.AddContentToDirectory(claimContent);

            List<ClaimClass> Content = Repoz.GetclaimContent();

            bool directoriesGotclaimContent = Content.Contains(claimContent);

            Assert.IsTrue(directoriesGotclaimContent);
        }

        private ClaimsRepo _claimsRepo;
        private ClaimClass _claimClass;

        [TestInitialize]

        public void Arrange()
        {
            _claimsRepo = new ClaimsRepo();

            _claimClass = new ClaimClass();

            _claimsRepo.AddContentToDirectory(_claimClass);
        } 
    }
}