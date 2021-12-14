using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Repo
{
    public class BadgeRepo
    {
        private Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();

        public void CreateBadge(int badgeId, List<string> doors)
        {
            _badges.Add(badgeId, doors);
        }

        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badges;
        }

        public bool AddDoorToBadge(int badgeId, string door)
        {
            if(!_badges.TryGetValue(badgeId, out List<string> doors))
            {
                return false;
            }

            _badges[badgeId].Add(door);

            return true;
        }

        public bool RemoveDoorOnBadge(int badgeId, string door)
        {
            if (!_badges.TryGetValue(badgeId, out List<string> doors))
            {
                return false;
            }

            int initialCount = _badges[badgeId].Count();
            _badges[badgeId].Remove(door);

            if(initialCount > _badges[badgeId].Count())
            {
                return true;
            }

            return false;
        }
    }
}
