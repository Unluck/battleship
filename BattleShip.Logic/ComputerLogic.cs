using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Logic
{
    public class ComputerLogic
    {
        public List<Ship> enemyShip = new List<Ship>();
        int[,] shipField = new int[10,10];

        

        public void RandomPlaceShip()
        {
            Random r = new Random();
            for (int i = 1; i < 5; i++)
            {
                if(i==1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        
                        var p1 = new Location(r.Next(0, 10), r.Next(0, 10));
                        if (CheckUniqueShip(new Location[] { p1 }))
                        {

                            enemyShip.Add(new Ship(i, 0, new Location[] { p1 }));
                        }
                        else j=--j;

                    }
                }
                if (i==2)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        int position = r.Next(0, 2);
                        if (position == 0)
                        {
                            var p1 = new Location(r.Next(0, 9), r.Next(0, 10));
                            var p2 = new Location(p1.x + 1, p1.y);
                            if (CheckUniqueShip(new Location[] { p1, p2 }))
                            {
                                enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2 }));
                            }
                            else j = --j;
                        }
                        else
                        {
                            var p1 = new Location(r.Next(0, 10), r.Next(0, 9));
                            var p2 = new Location(p1.x, p1.y + 1);
                            if (CheckUniqueShip(new Location[] { p1, p2 }))
                            {
                                enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2 }));
                            }
                            else j = --j;
                        }
                    }
                }
                if (i==3) 
                {
                    for (int j = 0; j < 2; j++)
                    {
                        int position = r.Next(0, 2);
                        if (position == 0) 
                        {
                            var p1 = new Location(r.Next(0, 8), r.Next(0, 10));
                            var p2 = new Location(p1.x + 1, p1.y);
                            var p3 = new Location(p2.x + 1, p1.y);
                            if (CheckUniqueShip(new Location[] { p1, p2, p3 }))
                            {
                                enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3 } ));
                            }
                            else j = --j;
                        }
                        else 
                        {
                            var p1 = new Location(r.Next(0, 10), r.Next(0, 8));
                            var p2 = new Location(p1.x, p1.y + 1);
                            var p3 = new Location(p1.x, p2.y + 1);
                            if (CheckUniqueShip(new Location[] { p1, p2, p3 }))
                            {
                                enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3 }));
                            }
                            else j = --j;
                        }
                    }
                }
                if(i==4) 
                {
                    for (int j = 0; j < 1; j++)
                    {
                        int position = r.Next(0, 2);
                        if (position == 0)
                        {
                            var p1 = new Location(r.Next(0, 7), r.Next(0, 10));
                            var p2 = new Location(p1.x + 1, p1.y);
                            var p3 = new Location(p2.x + 1, p1.y);
                            var p4 = new Location(p3.x + 1, p1.y);
                            if (CheckUniqueShip(new Location[] { p1, p2, p3, p4 }))
                            {
                                enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3, p4 }));
                            }
                            else j = --j;
                        }
                        if (position == 1)
                        {
                            var p1 = new Location(r.Next(0, 10), r.Next(0, 7));
                            var p2 = new Location(p1.x, p1.y + 1);
                            var p3 = new Location(p1.x, p2.y + 1);
                            var p4 = new Location(p1.x, p3.y + 1);
                            if (CheckUniqueShip(new Location[] { p1, p2, p3, p4 }))
                            {
                                enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3, p4 }));
                            }
                            else j = --j;
                        }
                    }

                }
            }
        }

        private bool CheckUniqueShip(Location[] massloc)
        {

            List<Location> listloc = new List<Location>();


            foreach (var s in massloc)
            {
                listloc.Add(new Location(s.x - 1, s.y - 1));
                listloc.Add(new Location(s.x, s.y - 1));
                listloc.Add(new Location(s.x + 1, s.y - 1));
                listloc.Add(new Location(s.x - 1, s.y));
                listloc.Add(s);
                listloc.Add(new Location(s.x + 1, s.y));
                listloc.Add(new Location(s.x - 1, s.y + 1));
                listloc.Add(new Location(s.x, s.y + 1));
                listloc.Add(new Location(s.x + 1, s.y + 1));

            }
            //var newlist = listloc.Distinct();
            foreach (var k in listloc)
            {
                if (k.x >= 0 & k.x <= 9)
                    if (k.y >= 0 & k.y <= 9)
                        if (shipField[k.x, k.y] == 0)
                        {
                            shipField[k.x, k.y] = 1;
                        }
                        else
                        {
                            return false;
                        }
            }
            return true;
        }
    }
}
