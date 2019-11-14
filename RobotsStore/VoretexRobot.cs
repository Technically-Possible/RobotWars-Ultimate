using RobotWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotsStore.Robots
{
    public class VortexRobot : IRobot
    {
        public Int64 Health { get; set; }

        public string GetName()
        {
            return "Vortex Robot";
        }
        //i Want My Software To Act Like A Vulture, Orginal Idea Was A Medic That Could Heal Itself,
        //but I Haven't Been Able To Find A Way Of Healing Myself
        // up To Now I Have Tried 
        //attacking The Highest For 10 Success Rate (50%)
        //attacking The Lowest For 10 Success Rate (60%)
        //attacking Both The Highest & The Lowest For 5 Success Rate (20%)
        //attacking The Highest & Healing The Lowest For 10 Success Rate (0%)
        //switching From Attacking The Highest To The Lowest For 10 Each Turn Success Rate (40%)
                public List<RobotAction> MyTurn(List<RobotAction> competitors)
        {

            var weakestVictim = competitors.OrderBy(c => c.Health).FirstOrDefault(); //FINDS THE WEAKEST
            var Strongestvictim = competitors.OrderByDescending(c => c.Health).FirstOrDefault(); //FINDS THE STRONGEST
            if (weakestVictim.Health <= 70)
            {
                if (weakestVictim.Health <= 30)
                {
                    //weakestVictim.Attacks = 10;

                    weakestVictim.Attacks = 10;
                }
                else
                {
                    Strongestvictim.Attacks = 10;
                }
            }
            else
            {
                if (Strongestvictim.Health >= 75)
                {
                    Strongestvictim.Attacks = 10;
                }
                else
                {
                    Strongestvictim.Attacks = 10;
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
/*------------------Old--Code------------------------/*
 * This code below shows the old ideas and attempts 
 * some ideas where as follows
 Swarm- create loads of bots that heal each other and attack everyone else controlled by a 'Swarm Controler'
 SelfHeal- as the name suggest's a bot that attacked for one round and healed for the next
 Reflectbot- any damage taken in a previous round is sent back to the bot who attacked.
 these ideas were not implemented due to rusty knowledge or low success rate
 these ideas were not implemented due to rusty knowledge or low success rate
    
    var weakestVictim = competitors.Where(c => (c.Name == "Stupid Robot" || c.Name == "Lazy Robot" || c.Name == "Very Stupid Robot" || c.Name == "Bully Robot" || c.Name == "Compassionate Robot") && c.Health > 0);
 * /*if (weakestVictim.Health <= 50)
{
    weakestVictim.Attacks = 5;
    Console.Beep();
    Strongestvictim.Attacks = 5;


    /*long QuickAttack = weakestVictim.Health;

    weakestVictim.Attacks = possibleAttacks;
    possibleAttacks = possibleAttacks - QuickAttack;
    Console.WriteLine(QuickAttack);
    Console.Beep();*/
//}
// else 
//{
// weakestVictim.Attacks = 10;


/*long QuickAttack = Strongestvictim.Health;

Strongestvictim.Attacks = possibleAttacks;
possibleAttacks = possibleAttacks - QuickAttack;*/
//   }

/*____________________________________STRONG___________________________________*/
//   if (Strongestvictim.Health >= 60)
//    {
//      Strongestvictim.Attacks = 10;


/*long QuickAttack = Strongestvictim.Health;

Strongestvictim.Attacks = possibleAttacks;
possibleAttacks = possibleAttacks - QuickAttack;*/
//}



/*________________________________________________________*/


/*{
    Strongestvictim.Attacks = 5;
    weakestVictim.Attacks = 5;

}*/
/*
return competitors;


}


}
}
/* var i = 0;
if (i != 0)
{
    i++;
    victim.Attacks = 10;
    return competitors;
}
else
{
    i--;

    victim.Attacks = 10;
}
return competitors;
*/
