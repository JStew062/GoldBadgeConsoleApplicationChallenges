using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_MenuRepository
{
    public class MenuItemRepository
    {
        //FakeDatabase
        protected readonly List<Menu> _menuItemDirectory = new List<Menu>();

        //CRUD
        //Create
        public bool AddContentToDirectory(Menu newContent)
        {
            int startingCount = _menuItemDirectory.Count;
            _menuItemDirectory.Add(newContent);
            bool wasAdded = (_menuItemDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public List<Menu> GetContents()
        {
            return _menuItemDirectory;
        }
        public Menu GetContentByMealID(int mealid)
        {
            foreach (Menu content in _menuItemDirectory)
            {
                if (content.MealID == Menu.mealid)
                {
                    return content;
                }
            }
            return null;
        }

        //Delete
        public bool DeleteExistingContent(Menu existingContent)
        {
            bool deleteResult = _menuItemDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}

