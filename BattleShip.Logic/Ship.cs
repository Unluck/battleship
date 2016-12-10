using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Logic
{
    public class Ship
    {
        public int ID { get; set; }
        public bool status { get; set; }
        public int lifes { get; set; }
        public int hits { get; set; }
        public Location[] shipLoc { get; set;}

        public Ship(int ID, int lifes, int hits, Location[] shipLoc)
        {
            this.ID = ID;
            this.lifes = lifes;
            this.hits = hits;
            this.shipLoc = shipLoc;
        }

    }
}
