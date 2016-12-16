using BattleShip.Data;
using System.Collections.Generic;

namespace BattleShip.Logic
{
    public class Events
    {
        public enum shotStatus
        {
            miss,
            hit,
            kill
        }

        public shotStatus Shot(Location loc, List<Ship> listSh)
        {
            foreach (var s1 in listSh)
            {
                foreach (var s2 in s1.ShipLoc)
                {
                    if (s2.x == loc.x && s2.y==loc.y)
                    {
                        s1.Hits++;
                        if (s1.Hits == s1.Lifes) return shotStatus.kill;
                        else return shotStatus.hit;
                    }
                }
            }
            return shotStatus.miss;
        }
         
    }
}
