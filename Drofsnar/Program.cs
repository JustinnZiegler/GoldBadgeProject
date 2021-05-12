using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drofsnar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> encounterList = new List<string>() { "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird",
                                                          "Bird", "Bird", "Bird", "InvincibleBirdHunter",
                                                          "EveningGrosbeak", "GreaterPrairieChicken",
                                                          "VulnerableBirdHunter", "VulnerableBirdHunter", "Bird", "Bird",
                                                          "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird",
                                                          "IcelandGull", "CrestedIbis", "GreatKiskudee",
                                                          "InvincibleBirdHunter", "Bird", "Bird", "Bird", "Bird", "Bird",
                                                          "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird",
                                                          "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird",
                                                          "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird",
                                                          "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird", "Bird",
                                                          "Bird", "Bird", "Bird", "RedCrossbill", "Red-neckedPhalarope",
                                                          "InvincibleBirdHunter", "VulnerableBirdHunter",
                                                          "Orange-belliedParrot", "InvincibleBirdHunter", "Bird", "Bird",
                                                          "Bird", "Bird", "Bird", "VulnerableBirdHunter"};
            DrofsnarRepo drofsnar = new DrofsnarRepo();
            foreach (string encounter in encounterList)
            {
                drofsnar.Encounter(encounter);
                //Console.WriteLine($"Total Points: {drofsnar.Points()}");
                //Console.WriteLine($"Total Lives: {drofsnar.LivesLeft()}");
                if (drofsnar.LivesLeft() == 0)
                {
                    break;
                }
            }
            Console.WriteLine($"Total Points: {drofsnar.Points()}");
            Console.WriteLine($"Total Lives: {drofsnar.LivesLeft()}");
        }
    }
}
