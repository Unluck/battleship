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
        int[,] localShip = new int[10, 10];



        public void RandomPlaceShip()
        {
            Random r = new Random();
            for (int i = 4; i > 0; i--)
            {
                if (i == 4)
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
                            if (localShip[p1.x, p1.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p2.x, p2.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p3.x, p3.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p4.x, p4.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3, p4 }));
                            CheckUniqueShip(new Location[] { p1, p2, p3, p4 });
                        }
                        if (position == 1)
                        {
                            var p1 = new Location(r.Next(0, 10), r.Next(0, 7));
                            var p2 = new Location(p1.x, p1.y + 1);
                            var p3 = new Location(p1.x, p2.y + 1);
                            var p4 = new Location(p1.x, p3.y + 1);
                            if (localShip[p1.x, p1.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p2.x, p2.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p3.x, p3.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p4.x, p4.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3, p4 }));
                            CheckUniqueShip(new Location[] { p1, p2, p3, p4 });
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
                            if (localShip[p1.x, p1.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p2.x, p2.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p3.x, p3.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3 }));
                            CheckUniqueShip(new Location[] { p1, p2, p3 });
                        }
                        if (position == 1)
                        {
                            var p1 = new Location(r.Next(0, 10), r.Next(0, 8));
                            var p2 = new Location(p1.x, p1.y + 1);
                            var p3 = new Location(p1.x, p2.y + 1);
                            if (localShip[p1.x, p1.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p2.x, p2.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p3.x, p3.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3 }));
                            CheckUniqueShip(new Location[] { p1, p2, p3 });
                        }
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
                            if (localShip[p1.x, p1.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            if (localShip[p2.x, p2.y] == 1)
                            {
                                j = --j;
                                continue;
                            }
                            enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2 }));
                            CheckUniqueShip(new Location[] { p1, p2 });
                        }
                        if (position == 1)
                        {
                            {
                                var p1 = new Location(r.Next(0, 10), r.Next(0, 9));
                                var p2 = new Location(p1.x, p1.y + 1);
                                if (localShip[p1.x, p1.y] == 1)
                                {
                                    j = --j;
                                    continue;
                                }
                                if (localShip[p2.x, p2.y] == 1)
                                {
                                    j = --j;
                                    continue;
                                }
                                enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2 }));
                                CheckUniqueShip(new Location[] { p1, p2 });
                            }
                        }
                    }
                }
                if (i == 1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        var p1 = new Location(r.Next(0, 10), r.Next(0, 10));
                        if (localShip[p1.x, p1.y] == 1)
                        {
                            j = --j;
                            continue;
                        }
                        enemyShip.Add(new Ship(i, 0, new Location[] { p1 }));
                        CheckUniqueShip(new Location[] { p1 });
                    }
                }
            }
        }
                
           
        private void CheckUniqueShip(Location[] massloc)
        {
            foreach (var s in massloc)
            {
                if (s.x - 1 >= 0 & s.y - 1>=0 & s.x - 1<10 & s.y - 1 <10)
                    localShip[s.x - 1, s.y - 1] = 1;
                if(s.x>=0 & s.y - 1>=0 & s.x<10 & s.y-1<10)
                    localShip[s.x, s.y - 1] = 1;
                if(s.x + 1>=0 & s.y - 1>=0 & s.x+1<10 & s.y-1<10)
                    localShip[s.x + 1, s.y - 1] = 1;
                if(s.x - 1>=0 & s.y>=0 & s.x-1<10 & s.y<10)
                    localShip[s.x-1, s.y] = 1;
                if(s.x>=0 & s.y>=0 & s.x<10 & s.y<10)
                    localShip[s.x, s.y] = 1;
                if(s.x + 1>=0 & s.y>=0 & s.x+1<10 & s.y<10)
                    localShip[s.x + 1, s.y] = 1;
                if(s.x - 1>=0 & s.y + 1>=0 & s.x-1 <10 & s.y+1<10)
                    localShip[s.x - 1, s.y + 1] = 1;
                if(s.x>=0 & s.y + 1>=0 & s.x<10 & s.y+1<10)
                    localShip[s.x, s.y + 1] = 1;
                if(s.x + 1>=0 & s.y + 1>=0 & s.x+1<10 & s.y+1<10)
                    localShip[s.x + 1, s.y + 1] = 1;
            }

        }
    }
}
