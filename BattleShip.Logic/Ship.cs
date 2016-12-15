namespace BattleShip.Logic
{
    public class Ship
    {
        public int Lifes { get; set; }
        public int Hits { get; set; }
        public Location[] ShipLoc { get; set;}

        public Ship(int lifes, int hits, Location[] shipLoc)
        {
            Lifes = lifes;
            Hits = hits;
            ShipLoc = shipLoc;
        }

    }
}
