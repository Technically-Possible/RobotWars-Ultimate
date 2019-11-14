using RobotWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotsStore.Robots
{
    public class MyRobot : IRobot
    {
        public List<Robot> Robots { get; set; } = new List<Robot>();

        public Int64 Health { get; set; }

        public string GetName()
        {
            return "My Robot";
        }
     
        public List<RobotAction> MyTurn(List<RobotAction> competitors)
        {

            int count = 1;
            long healthDifference;
            long attacksLeft = 10;
            long totalcompetitorhealth = 0;

            //We want to go through the highest hp enemies first in our foreach loops.
            competitors.OrderByDescending(c => c.Health).FirstOrDefault();

            //If my robot has enough damage to finish off every enemy, do that rather than waste attacks.
            foreach (RobotAction d in competitors)
            {
                totalcompetitorhealth += d.Health;
               
            }           
            if (totalcompetitorhealth <= 10)
            {
              Console.WriteLine("My robot has enough damage to win!");
              foreach (RobotAction d in competitors)
              d.Attacks += d.Health;
              attacksLeft = 0;
            }

            //General strategy is to target high hp robots so that we don't end up in unwinnable situations.
            // If we have high hp and other robots are low, don't finish them as we are less likely to be randomly targeted.
            while (attacksLeft > 0)
            {
                

                foreach (RobotAction r in competitors.OrderByDescending(c => c.Health))
                {
                count++;
                    healthDifference = r.Health - this.Health;

                    if (attacksLeft > 0)
                    {
                       //If this enemy has a lot more hp than us, use all our attacks on them. This is the highest priority to prevent unwinnable fights later on.
                        if (healthDifference > 10)
                        {
                            r.Attacks = 10;
                            attacksLeft = 0;
                        }

                        //We want to be second highest hp so that we're not targeted by compassionate robot.
                        else if (healthDifference > 0)
                        {
                            for (int i = 0; i < attacksLeft && i < healthDifference; i++)
                            {
                                r.Attacks += 1;
                                attacksLeft -= 1;
                            }
                           
                        }

                        //When there are only a few enemies left, the strategy becomes to get the enemy to within one turn kill range.
                        else if (r.Health > 10 && competitors.Count() <= 3)
                        {
                            r.Attacks += (r.Health - 10);
                            if (r.Attacks > 10)
                                r.Attacks = 10;
                            attacksLeft -= (r.Health - 10);
                        }
                        //If no other conditions are met, attack the robot with the highest hp.
                        else if (count == competitors.Count())
                        {
                            competitors.OrderByDescending(c => c.Health).FirstOrDefault().Attacks += attacksLeft;
                            attacksLeft = 0;
                        }
                    }
                    if (attacksLeft < 0)
                        attacksLeft = 0;

                }
                
            }



            if (attacksLeft > 0)
            {
                //Checking to see if robot is wasting attacks.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Why didn't I use all my attacks?");
                    Console.ForegroundColor = ConsoleColor.White;
            }
            return competitors;            
        }

        public void UpdateHealth(Int64 health)
        {
            Health = health;
        }
    }
}
