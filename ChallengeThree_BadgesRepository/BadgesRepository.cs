using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_BadgesRepository
{
    //Create
    public class BadgesRepository
    {
        Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();

        //AddBadgeToDirectory
        public bool AddBadgeToDirectory(Badges newBadge)
        {
            int startingCount = dict.Count;
            dict.Add(newBadge.BadgeID, newBadge.Doors);
            bool wasAdded = (dict.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Dictionary<int, List<string>> GetContents()
        {
            return dict;
        }


        //Read
        public Dictionary<int, List<string>> GetContents1()
        {
            return dict;
        }
        public List<string> GetContentByBadgeID(int badgeid)
        {
            dict = GetContents1();
            foreach (KeyValuePair<int, List<string>> kv in dict)
            {
                if (kv.Key == badgeid)
                {
                    return kv.Value;
                }

            }
            return null;
        }
    }
}

