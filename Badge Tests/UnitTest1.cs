using Badge_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Badge_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]


        public void AddToBadgeDB_FingerXDBool()
        {
            BadgeClass badgeID = new BadgeClass();
            BadgeRepo repo = new BadgeRepo();

            bool addResult = repo.AddBadgeDB(badgeID);

            Assert.IsTrue(addResult);
        }

        private BadgeClass _badgeClass;
        private BadgeRepo _badgeRepo;

        [TestInitialize]

        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();

            _badgeClass = new BadgeClass();

            _badgeRepo.AddBadgeDB(_badgeClass);
        }
    }
}
