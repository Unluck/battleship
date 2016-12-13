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
        //int[,] shipField = new int[10,10];
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
                            for (int k = 0; k < localShip.GetLength(0); k++)
                            {
                                for (int l = 0; l < localShip.GetLength(1); l++)
                                {
                                    if (localShip[k, l] == 1)
                                    {
                                        if (p1.x == k & p1.y == l)
                                            j = --j;
                                        if (p2.x == k & p2.y == l)
                                            j = --j;
                                        if (p3.x == k & p3.y == l)
                                            j = --j;
                                        if (p4.x == k & p4.y == l)
                                            j = --j;
                                    }

                                }
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
                            for (int k = 0; k < localShip.GetLength(0); k++)
                            {
                                for (int l = 0; l < localShip.GetLength(1); l++)
                                {
                                    if (localShip[k, l] == 1)
                                    {
                                        if (p1.x == k & p1.y == l)
                                            j = --j;
                                        if (p2.x == k & p2.y == l)
                                            j = --j;
                                        if (p3.x == k & p3.y == l)
                                            j = --j;
                                        if (p4.x == k & p4.y == l)
                                            j = --j;
                                    }

                                }
                            }
                            enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3, p4 }));
                            CheckUniqueShip(new Location[] { p1, p2, p3, p4 });
                        }
                    }

                }
               /* if (i==1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        
                        var p1 = new Location(r.Next(0, 10), r.Next(0, 10));
                        for (int k = 0; k < localShip.GetLength(0); k++)
                        {
                            for (int l = 0; l < localShip.GetLength(1); l++)
                            {
                                if (localShip[k, l] == 1)
                                    if (p1.x == k & p1.y == l)
                                        j = --j;
                            }
                        }
                        enemyShip.Add(new Ship(i, 0, new Location[] { p1 }));
                        CheckUniqueShip(new Location[] { p1 });
                    }
                }
                if (i==2)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        // int position = r.Next(0, 2);
                        //if (position == 0)
                        //{
                        var p1 = new Location(r.Next(0, 9), r.Next(0, 10));
                        var p2 = new Location(p1.x + 1, p1.y);
                        for (int k = 0; k < localShip.GetLength(0); k++)
                        {
                            for (int l = 0; l < localShip.GetLength(1); l++)
                            {
                                if (localShip[k, l] == 1)
                                {
                                    if (p1.x == k & p1.y == l)
                                        j = --j;
                                    else if (p2.x == k & p2.y == l)
                                        j = --j;
                                }

                            }
                        }
                        enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2 }));
                        CheckUniqueShip(new Location[] { p1, p2 });

                    }



                         }
                      /*  else
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
                }*/
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
                            for (int k = 0; k < localShip.GetLength(0); k++)
                            {
                                for (int l = 0; l < localShip.GetLength(1); l++)
                                {
                                    if (localShip[k, l] == 1)
                                    {
                                        if (p1.x == k & p1.y == l)
                                            j = --j;
                                        if (p2.x == k & p2.y == l)
                                            j = --j;
                                        if (p3.x == k & p3.y == l)
                                            j = --j;
                                    }

                                }
                            }
                            enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3 }));
                            CheckUniqueShip(new Location[] { p1, p2, p3 });
                        }
                        else 
                        {
                            var p1 = new Location(r.Next(0, 10), r.Next(0, 8));
                            var p2 = new Location(p1.x, p1.y + 1);
                            var p3 = new Location(p1.x, p2.y + 1);
                            for (int k = 0; k < localShip.GetLength(0); k++)
                            {
                                for (int l = 0; l < localShip.GetLength(1); l++)
                                {
                                    if (localShip[k, l] == 1)
                                    {
                                        if (p1.x == k & p1.y == l)
                                            j = --j;
                                        if (p2.x == k & p2.y == l)
                                            j = --j;
                                        if (p3.x == k & p3.y == l)
                                            j = --j;
                                    }

                                }
                            }
                            enemyShip.Add(new Ship(i, 0, new Location[] { p1, p2, p3 }));
                            CheckUniqueShip(new Location[] { p1, p2, p3 });
                        }
                    }
                }
                /*
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

                }*/
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
