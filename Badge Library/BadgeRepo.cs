using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Library
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, BadgeClass> _badgeDB = new Dictionary<int, BadgeClass>();

        int _Count = 0;

        public bool AddBadgeDB(BadgeClass badgeClass)
        {
            _Count++;
            badgeClass.BadgeID = _Count;
            _badgeDB.Add(_Count, badgeClass);
            return true;
        }

        public Dictionary<int, BadgeClass> GetListOfDoorNames()
        {
            return _badgeDB;
        }

        public BadgeClass GetBadgeIDByKey(int key)
        {
            foreach (var badgeClass in _badgeDB)
            {
                if (badgeClass.Key == key)
                {
                    return badgeClass.Value;
                }
            }
            return null;
        }

        public bool UpdateBadge(int oldBadge, BadgeClass newBadgeDB)
        {
            BadgeClass oldBadges = GetBadgeIDByKey(oldBadge);
            if (oldBadges == null)
            {
                return false;
            }
            else
            {
                oldBadges.ListOfDoorNames = newBadgeDB.ListOfDoorNames;
                return true;
            }
        }
    }
}