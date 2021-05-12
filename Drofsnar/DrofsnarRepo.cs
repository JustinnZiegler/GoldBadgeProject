using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drofsnar
{
    public class DrofsnarRepo
    {
        int lives = 3;
        int totalPoints = 5000;
        int vulnerableCounter = 1;
        int pointLifeLimit = 10000;
        public void Encounter(string encounterName)
        {
            Encounters encounter = new Encounters(encounterName);
            //Console.WriteLine(encounter.Name);
            if (encounterName == "VulnerableBirdHunter")
            {
                if (vulnerableCounter > 4)
                {
                    vulnerableCounter = 1;
                    totalPoints += 200;
                    vulnerableCounter++;
                    if (totalPoints >= pointLifeLimit)
                    {
                        lives++;
                        pointLifeLimit += 10000;
                    }
                }
                else
                {
                    switch (vulnerableCounter)
                    {
                        case 1:
                            totalPoints += 200;
                            break;
                        case 2:
                            totalPoints += 400;
                            break;
                        case 3:
                            totalPoints += 800;
                            break;
                        case 4:
                            totalPoints += 1600;
                            break;
                    }
                    vulnerableCounter++;
                    if (totalPoints >= pointLifeLimit)
                    {
                        lives++;
                        pointLifeLimit += 10000;
                    }
                }
            }
            else if (encounterName == "InvincibleBirdHunter")
            {
                lives--;
            }
            else
            {
                totalPoints += encounter.PointValue;
                if (totalPoints >= pointLifeLimit)
                {
                    lives++;
                    pointLifeLimit += 10000;
                }
            }
        }
        public int Points()
        {
            return totalPoints;
        }
        public int LivesLeft()
        {
            return lives;
        }
    }
}
