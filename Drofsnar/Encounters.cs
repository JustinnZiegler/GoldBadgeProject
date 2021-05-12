using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drofsnar
{
    public class Encounters
    {
        public string Name { get; set; }
        public int PointValue
        {
            get
            {
                switch (Name)
                {
                    case "Bird":
                        return 10;
                    case "CrestedIbis":
                        return 100;
                    case "GreatKiskudee":
                        return 300;
                    case "RedCrossbill":
                        return 500;
                    case "Red-neckedPhalarope":
                        return 700;
                    case "EveningGrosbeak":
                        return 1000;
                    case "GreaterPrairieChicken":
                        return 2000;
                    case "IcelandGull":
                        return 3000;
                    case "Orange-belliedParrot":
                        return 5000;
                    default:
                        return 0;
                }
            }
        }
        public Encounters(string name)
        {
            Name = name;
        }
    }
}

