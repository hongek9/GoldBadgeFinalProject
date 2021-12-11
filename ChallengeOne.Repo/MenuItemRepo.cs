using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Repo
{
    public class MenuItemRepo
    {
        private List<MenuItem> _listOfMenuItems = new List<MenuItem>();

        private int _count = 0;

        public void AddMenuItem(MenuItem menuItem)
        {
            _count++;
            menuItem.MealNumber = _count;
            _listOfMenuItems.Add(menuItem);
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _listOfMenuItems;
        }

        public MenuItem GetMenuItemByNumber(int number)
        {
            foreach(MenuItem menuItem in _listOfMenuItems)
            {
                if(number == menuItem.MealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }

        public bool UpdateMenuItem(int number, MenuItem updatedMenuItem)
        {
            MenuItem currentItem = GetMenuItemByNumber(number);

            if(currentItem != null)
            {
                currentItem.MealName = updatedMenuItem.MealName;
                currentItem.Description = updatedMenuItem.Description;
                currentItem.Ingredients = updatedMenuItem.Ingredients;
                currentItem.Price = updatedMenuItem.Price;
                return true;
            }

            return false;
        }

        public bool DeleteMenuItem(int number)
        {
            MenuItem menuItem = GetMenuItemByNumber(number);

            if(menuItem == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count();
            _listOfMenuItems.Remove(menuItem);

            if(_listOfMenuItems.Count() < initialCount)
            {
                return true;
            }

            return false;
        }


    }
}
