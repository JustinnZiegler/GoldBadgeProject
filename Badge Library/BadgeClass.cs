using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Library
{
    public class BadgeClass
    {
        public int BadgeID { get; set; }
        public string ListOfDoorNames { get; set; }

        public BadgeClass() { }

        public BadgeClass(int badgeID, string listOfDoorNames)
        {
            BadgeID = badgeID;
            ListOfDoorNames = listOfDoorNames;
        }
    }
}
