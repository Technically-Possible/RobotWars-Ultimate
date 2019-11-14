using RobotWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotsStore.Robots
{
    public class Hybridbot : IRobot
    {
        public Int64 Health { get; set; }
        private int attacksLeft = 10;

        public string GetName()
        {
            return "Hybridbot";
        }
        public List<RobotAction> MyTurn(List<RobotAction> competitors)
        {
            for (int i = 0; i < attacksLeft; i++)
            {
                if (Health > 50)
                {
                    var target = competitors.Where(c => c.Health < Health).OrderBy(c => c.Health).FirstOrDefault();
                    Console.WriteLine("Hybridbot is currently targetting " + target.Name);
                    AttackingFunction(target, attacksLeft);
                }

                else
                {
                    var target = competitors.OrderBy(c => c.Health).FirstOrDefault();
                    Console.WriteLine("Hybridbot is currently targetting " + target.Name);
                    AttackingFunction(target, attacksLeft);
                }
            }
            return competitors;
        }

        public void UpdateHealth(Int64 health)
        {
            Health = health;
        }

        public void AttackingFunction(RobotAction target, int attacksLeft)
        {
            if (target.Health > 10)
            {
                target.Attacks = attacksLeft;
            }

            else
            {
                attacksLeft -= (int)target.Health;
                target.Attacks = target.Health;
            }
        }
    }
}
