using CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]


        public void AddToDirectory_FingersCrossedBool()
        {
            MenuClass Items = new MenuClass();
            MenuRepoClass Repo = new MenuRepoClass();

            bool addResult = Repo.AddContentToDirectory(Items);

            Assert.IsTrue(addResult);
        }


        [TestMethod]
        public void GetDirectory_FingersCrossedCollection()
        {
            MenuClass Items = new MenuClass();

            MenuRepoClass Repoz = new MenuRepoClass();

            Repoz.AddContentToDirectory(Items);

            List<MenuClass> Item = Repoz.GetItems();

            bool directoriesGotItems = Item.Contains(Items);

            Assert.IsTrue(directoriesGotItems);
        }

        private MenuRepoClass _menuRepo;
        private MenuClass _menuClass;
        private MenuClass _menuClass2;

        [TestInitialize]

        public void Arrange()
        {
            _menuRepo = new MenuRepoClass();

            _menuClass = new MenuClass(1, "Supreme Steak",
                "A fillet mignon thickly cut from one of our Wagyu cows.",
                "Ingredients include: steak from our Wagyu cow, sauteed onions, and mushrooms.",
                100d);

            var _menuClass2 = new MenuClass();

            _menuClass2.MealNumber = 1;

            _menuRepo.AddContentToDirectory(_menuClass);
        }

        [TestMethod]
        public void GetByMealNumber_FingersCrossedCorrectItems()
        {
            MenuClass searchResult = _menuRepo.GetItemsByMealNumber(1);

            Assert.AreEqual(_menuClass, searchResult);
        }

        [TestMethod]
        public void DeleteCafeItems_ShouldReturnTrue()
        {
            MenuClass Items = _menuRepo.GetItemsByMealNumber(1);

            bool removeOutcome = _menuRepo.DeleteCafeItems(Items);

            Assert.IsTrue(removeOutcome);
        }
    }
}