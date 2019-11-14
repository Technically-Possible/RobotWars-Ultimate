using RobotWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotsStore.Robots
{
    public class MedicRobot : IRobot
    {
        public Int64 Health { get; set; }

        public string GetName()
        {
            return "Medic Robot";
        }

        public List<RobotAction> MyTurn(List<RobotAction> competitors)
        {

            var Strongestvictim = competitors.OrderByDescending(c => c.Health).FirstOrDefault(); //FINDS THE STRONGEST
            var weakestVictim = competitors.OrderBy(c => c.Health).FirstOrDefault(); //FINDS THE WEAKEST
            if (weakestVictim.Name == "Vortex Robot")
            {
                if (weakestVictim.Name == "Vortex Robot")
                {
                    weakestVictim.Attacks = -100;
                    Console.Beep();
                    
                }
                else
                {
                    Strongestvictim.Attacks = -30;
                }
            }
            if (Strongestvictim.Name == "Vortex Robot")
            {
                if (Strongestvictim.Name == "Vortex Robot")
                {
                    Strongestvictim.Attacks = -20;
                    Console.Beep();

                }
                else
                {
                    Strongestvictim.Attacks = -30;
                }
            }
            return competitors;


        }

        public void UpdateHealth(Int64 health)
        {
            Health = health;
        }
    }
}
