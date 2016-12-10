using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Logic
{
    public class Ship
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int Lifes { get; set; }
        public int Hits { get; set; }
        public Location[] ShipLoc { get; set;}
        public bool[] HitLoc{get;set;}

        public Ship(int id, int lifes, int hits, Location[] shipLoc)
        {
            Id = id;
            Lifes = lifes;
            Hits = hits;
            ShipLoc = shipLoc;
        }

    }
}
