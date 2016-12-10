using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Logic
{
    public class Events
    {
        public List<Ship> ship = new List<Ship>();
        public enum shotStatus
        {
            miss,
            hit,
            kill,
            nth
        }
        
        public shotStatus Shot(Location loc)
        {
            foreach (var s1 in ship)
            {
                foreach (var s2 in s1.ShipLoc)
                {
                    if (s2 == loc)
                    {
                        s1.Hits++;
                        if (s1.Hits == s1.Lifes) return shotStatus.kill;
                        else return shotStatus.hit;
                    }

                    else return shotStatus.miss;
                }
            } return shotStatus.nth;
        }
 
    }
}
