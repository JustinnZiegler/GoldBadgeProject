using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLibrary
{
    public class MenuRepoClass
    {
        protected readonly List<MenuClass> _contentDirectory = new List<MenuClass>();

        public bool AddContentToDirectory(MenuClass Items)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(Items);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<MenuClass> GetItems()
        {
            return _contentDirectory;
        }

        public MenuClass GetItemsByMealNumber(int mealNumber)
        {
            foreach (MenuClass Items in _contentDirectory)
            {
                if (Items.MealNumber == mealNumber)
                {
                    return Items;
                }
            }

            return null;

        }

        public MenuClass GetItemsByMealName(string mealName)
        {
            foreach (MenuClass Items in _contentDirectory)
            {
                if (Items.MealName.ToLower() == mealName.ToLower())
                {
                    return Items;
                }
            }

            return null;

        }

        public MenuClass GetItemsByDescription(string description)
        {
            foreach (MenuClass Items in _contentDirectory)
            {
                if (Items.Description.ToLower() == description.ToLower())
                {
                    return Items;
                }
            }

            return null;

        }

        public MenuClass GetItemsByIngredients(string ingredients)
        {
            foreach (MenuClass Items in _contentDirectory)
            {
                if (Items.Ingredients.ToLower() == ingredients.ToLower())
                {
                    return Items;
                }
            }

            return null;

        }

        public MenuClass GetItemsByPrice(double price)
        {
            foreach (MenuClass Items in _contentDirectory)
            {
                if (Items.Price == price)
                {
                    return Items;
                }
            }

            return null;

        }

        public bool DeleteCafeItems(MenuClass currentItems)
        {
            bool deleteOutcome = _contentDirectory.Remove(currentItems);
            return deleteOutcome;
        }
    }
}
