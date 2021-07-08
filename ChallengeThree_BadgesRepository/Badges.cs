using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_BadgesRepository
{
    public class Badges
    {
        public int BadgeID { get; set; }

        public List<string> Doors { get; set; } = new List<string>();

        //Constructor Empty
        public Badges() { }

        //Constructor Full
        public Badges(int badgeid, List<string> doors)
        {
            BadgeID = badgeid;
            Doors = doors;
        }
    }
}
