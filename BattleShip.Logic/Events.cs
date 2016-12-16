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
        
        public shotStatus Shot(Location loc)
        {
            foreach (var s1 in ComputerLogic.enemyShip)
            {
                foreach (var s2 in s1.ShipLoc)
                {
                    if (s2 == loc)
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
