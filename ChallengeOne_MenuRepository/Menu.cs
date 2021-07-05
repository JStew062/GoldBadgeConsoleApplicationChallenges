using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_MenuRepository
{
    public class Menu
    {
        internal static int mealid;

        //internal static object devid;

        public int MealID { get; set; }

        public string MealName { get; set; }

        public string MealDesc { get; set; }

        public string MealIng { get; set; }

        public decimal MealPrice { get; set; }

        //Constructor Empty
        public Menu() { }

        //Constructor Full
        public Menu(int mealid, string mealname, string mealdesc, string mealing, decimal mealprice)
        
        {
            MealID = mealid;
            MealName = mealname;
            MealDesc = mealdesc;
            MealIng = mealing;
            MealPrice = mealprice;
        }

    }
}
