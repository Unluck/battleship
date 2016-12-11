using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Logic
{
    class ComputerLogic
    {
        public List<Ship> enemyShip = new List<Ship>();

        public void RandomPlaceShip()
        {
            Random r = new Random();
            for (int i = 1; i < 5; i++)
            {
                if(i==1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        enemyShip.Add(new Ship(i, 0, new Location[]
                            {
                                new Location(r.Next(0,10),r.Next(0,10))
                            }
                            ));
                    }
                }
                if (i == 2)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int position = r.Next(0, 2);
                        if (position == 0) 
                        {
                            var p1 = new Location(r.Next(0, 9), r.Next(0, 10));
                            var p2 = new Location(p1.x + 1, p1.y);
                            enemyShip.Add(new Ship(i, 0, new Location[]
                            {
                                p1,
                                p2
                            }
                            ));
                        }
                        else 
                        {
                            var p1 = new Location(r.Next(0, 10), r.Next(0, 9));
                            var p2 = new Location(p1.x, p1.y + 1);
                            enemyShip.Add(new Ship(i, 0, new Location[]
                                {
                                    p1,
                                    p2
                                }
                                ));
                        }
                    }
                }
                if (i == 3) 
                {
                    for (int j = 0; j < 2; j++)
                    {
                        int position = r.Next(0, 2);
                        if (position == 0) 
                        {
                            var p1 = new Location(r.Next(0, 8), r.Next(0, 10));
                            var p2 = new Location(p1.x + 1, p1.y);
                            var p3 = new Location(p2.x + 1, p1.y);
                            enemyShip.Add(new Ship(i, 0, new Location[]
                                {
                                       p1,
                                       p2,
                                       p3
                                }
                                    ));
                        }
                        else 
                        {
                            var p1 = new Location(r.Next(0, 10), r.Next(0, 8));
                            var p2 = new Location(p1.x, p1.y + 1);
                            var p3 = new Location(p1.x, p2.y + 1);
                            enemyShip.Add(new Ship(i, 0, new Location[]
                                {
                                       p1,
                                       p2,
                                       p3
                                }
                                    ));
                        }
                    }
                }
                if(i==4) 
                {
                    int position = r.Next(0, 2);
                    if (position == 0) 
                    {
                        var p1 = new Location(r.Next(0, 7), r.Next(0, 10));
                        var p2 = new Location(p1.x + 1, p1.y);
                        var p3 = new Location(p2.x + 1, p1.y);
                        var p4 = new Location(p3.x + 1, p1.y);
                        enemyShip.Add(new Ship(i, 0, new Location[]
                        {
                            p1,
                            p2,
                            p3,
                            p4
                        }
                        ));
                    }
                    if(position==1) 
                    {
                        var p1 = new Location(r.Next(0, 10), r.Next(0, 7));
                        var p2 = new Location(p1.x, p1.y+1);
                        var p3 = new Location(p1.x, p2.y+1);
                        var p4 = new Location(p1.x, p3.y+1);
                        enemyShip.Add(new Ship(i, 0, new Location[]
                        {
                            p1,
                            p2,
                            p3,
                            p4
                        }
                        ));
                    }

                }
            }
        }
    }
}
