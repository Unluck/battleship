using BattleShip.Data;
using System;
using System.Collections.Generic;

namespace BattleShip.Logic
{
    public class ComputerLogic
    {
        Repository repo = Repository.GetInstance();
        Events ev = new Events();
        int[,] localShip = new int[10, 10];
        int[,] massShips = new int[10, 10];
        
        public void UserShip()
        {
            foreach (var s in repo.Ships)
            {
                foreach (var s1 in s.ShipLoc)
                {
                    massShips[s1.x, s1.y] = 1;
                }
            }
        }

        public void RandomPlaceShip(List<Ship> listShips)
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
                            listShips.Add(new Ship(i, 0, new Location[] { p1, p2, p3, p4 }));
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
                            listShips.Add(new Ship(i, 0, new Location[] { p1, p2, p3, p4 }));
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
                            listShips.Add(new Ship(i, 0, new Location[] { p1, p2, p3 }));
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
                            listShips.Add(new Ship(i, 0, new Location[] { p1, p2, p3 }));
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
                            listShips.Add(new Ship(i, 0, new Location[] { p1, p2 }));
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
                                listShips.Add(new Ship(i, 0, new Location[] { p1, p2 }));
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
                        listShips.Add(new Ship(i, 0, new Location[] { p1 }));
                        CheckUniqueShip(new Location[] { p1 });
                    }
                }
            }
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    localShip[i, j] = 0;
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

        public int[,] ComputerActionFirstShot()
        {
            restart:
            int shotNumber=0;
            Random r = new Random();
            int x = r.Next(0, 10);
            int y = r.Next(0, 10);
            while (massShips[x, y] == 2 | massShips[x,y]==3)
            {
                x = r.Next(0, 10);
                y = r.Next(0, 10);
            }
            var location = new Location(x, y);
            var statusFirst=ev.Shot(location, repo.Ships);
            shotNumber++;
            if(statusFirst==Events.shotStatus.miss)
            {
                massShips[x,y]=2;
                return massShips;
            }
            if (statusFirst == Events.shotStatus.kill)
            {
                massShips[x, y] = 3;
                ShowUnplayableDots(new Location[] { new Location(x, y) }, massShips);
                if (repo.Ships.Count != 0)
                {
                    goto restart;
                }
                else { return massShips; }
            }
            if (statusFirst==Events.shotStatus.hit)
            {
                shotNumber++;
                massShips[x, y] = 3;
                int randomPos = r.Next(0, 4);
                var statusSecond=AutoChecking(ref randomPos, x, y, repo.Ships,shotNumber);
                if(statusSecond.Item1==Events.shotStatus.miss)
                {
                    massShips[statusSecond.Item2.x, statusSecond.Item2.y] = 2;
                    return massShips;
                }
                if(statusSecond.Item1==Events.shotStatus.kill)
                {
                    massShips[statusSecond.Item2.x, statusSecond.Item2.y] = 3;
                    var massLoc = new Location[]
                    {
                        new Location(x,y),
                        new Location(statusSecond.Item2.x, statusSecond.Item2.y)
                    };
                    ShowUnplayableDots(massLoc, massShips);
                    if (repo.Ships.Count != 0)
                    {
                        goto restart;
                    }
                    else { return massShips; }
                }
                if(statusSecond.Item1==Events.shotStatus.hit)
                {
                    shotNumber++;
                    massShips[statusSecond.Item2.x, statusSecond.Item2.y] = 3;
                    var statusThird = AutoChecking(ref randomPos, statusSecond.Item2.x, statusSecond.Item2.y, repo.Ships,shotNumber);
                    if(statusThird.Item1==Events.shotStatus.miss)
                    {
                        massShips[statusThird.Item2.x, statusThird.Item2.y] = 2;
                        return massShips;
                    }
                    if (statusThird.Item1 == Events.shotStatus.kill)
                    {
                        massShips[statusThird.Item2.x, statusThird.Item2.y] = 3;
                        var massLoc = new Location[]
                         {
                            new Location(x,y),
                            new Location(statusSecond.Item2.x, statusSecond.Item2.y),
                            new Location(statusThird.Item2.x, statusThird.Item2.y)
                         };
                        ShowUnplayableDots(massLoc, massShips);
                        if (repo.Ships.Count != 0)
                        {
                            goto restart;
                        }
                        else { return massShips; }
                    }
                    if(statusThird.Item1==Events.shotStatus.hit)
                    {
                        shotNumber++;
                        massShips[statusThird.Item2.x, statusThird.Item2.y] = 3;
                        var statusFourth = AutoChecking(ref randomPos, statusThird.Item2.x, statusThird.Item2.y, repo.Ships, shotNumber);
                        if (statusFourth.Item1 == Events.shotStatus.miss)
                        {
                            massShips[statusFourth.Item2.x, statusFourth.Item2.y] = 2;
                            return massShips;
                        }
                        if (statusFourth.Item1 == Events.shotStatus.kill)
                        {
                            massShips[statusFourth.Item2.x, statusFourth.Item2.y] = 3;
                            var massLoc = new Location[]
                             {
                                 new Location(x,y),
                                 new Location(statusSecond.Item2.x, statusSecond.Item2.y),
                                 new Location(statusThird.Item2.x, statusThird.Item2.y),
                                 new Location(statusFourth.Item2.x, statusFourth.Item2.y)
                             };
                            ShowUnplayableDots(massLoc, massShips);
                            if (repo.Ships.Count != 0)
                            {
                                goto restart;
                            }
                            else { return massShips; }
                        }
                    }
                }
            }
            return massShips;
        }

        private Tuple<Events.shotStatus,Location> AutoChecking(ref int pos, int x, int y, List<Ship> list,int numShot)
        {
            Random r = new Random();
            start:
            if(pos==0)
            {
                var loc = new Location(x + 1, y);
                if (loc.x > 9)
                {
                    pos = 1;
                    x = x - numShot+2;
                    goto start;
                }
                if (massShips[x + 1, y] == 2)
                {
                    if (numShot == 2)
                    {
                        pos = r.Next(0, 4);
                        goto start;
                    }
                    if(numShot>2)
                    {
                        pos = 1;
                        x = x - numShot + 2;
                        goto start;
                    }
                }
                return Tuple.Create(ev.Shot(loc, list), new Location(x + 1, y));
            }
            if (pos == 1)
            {
                var loc = new Location(x - 1, y);
                if (loc.x < 0)
                {
                    pos = 0;
                    x = x + numShot-2;
                    goto start;
                }
                if (massShips[x - 1, y] == 2)
                {
                    if (numShot == 2)
                    {
                        pos = r.Next(0,4);
                        goto start;
                    }
                    if (numShot > 2)
                    {
                        pos = 0;
                        x = x + numShot - 2;
                        goto start;
                    }
                }
                return Tuple.Create(ev.Shot(loc, list), new Location(x-1,y));
            }
            if (pos == 2)
            {
                var loc = new Location(x , y+1);
                if (loc.y > 9)
                {
                    pos = 3;
                    y = y - numShot+2;
                    goto start;
                }
                if (massShips[x, y + 1] == 2)
                {
                    if (numShot == 2)
                    {
                        pos = r.Next(0, 4);
                        goto start;
                    }
                    if (numShot > 2)
                    {
                        pos = 3;
                        y = y - numShot + 2;
                        goto start;
                    }
                }
                return Tuple.Create(ev.Shot(loc, list), new Location(x, y+1));
            }
            if (pos == 3)
            {
                var loc = new Location(x , y-1);
                if (loc.y < 0)
                {
                    pos = 2;
                    y = y + numShot-2;
                    goto start;
                }
                if (massShips[x, y - 1] == 2)
                {
                    if (numShot == 2)
                    {
                        pos = r.Next(0, 4);
                        goto start;
                    }
                    if (numShot > 2)
                    {
                        pos = 2;
                        y = y + numShot - 2;
                        goto start;
                    }
                }
                return Tuple.Create(ev.Shot(loc, list), new Location(x, y-1));
            }
            return Tuple.Create(Events.shotStatus.miss, new Location(0,0));
        }

        private void ShowUnplayableDots(Location[] listLoc, int[,] mass)
        {
            foreach (var s in listLoc)
            {

                if (s.x - 1 >= 0 & s.y - 1 >= 0 & s.x - 1 < 10 & s.y - 1 < 10)
                    if (mass[s.x - 1, s.y - 1] != 3)
                        mass[s.x - 1, s.y - 1] = 2;
                if (s.x >= 0 & s.y - 1 >= 0 & s.x < 10 & s.y - 1 < 10)
                    if (mass[s.x, s.y - 1] != 3)
                        mass[s.x, s.y - 1] = 2;
                if (s.x + 1 >= 0 & s.y - 1 >= 0 & s.x + 1 < 10 & s.y - 1 < 10)
                    if (mass[s.x + 1, s.y - 1] != 3)
                        mass[s.x + 1, s.y - 1] = 2;
                if (s.x - 1 >= 0 & s.y >= 0 & s.x - 1 < 10 & s.y < 10)
                    if (mass[s.x - 1, s.y] != 3)
                        mass[s.x - 1, s.y] = 2;
                if (s.x + 1 >= 0 & s.y >= 0 & s.x + 1 < 10 & s.y < 10)
                    if (mass[s.x + 1,s.y] != 3)
                        mass[s.x + 1, s.y] = 2;
                if (s.x - 1 >= 0 & s.y + 1 >= 0 & s.x - 1 < 10 & s.y + 1 < 10)
                    if (mass[s.x - 1, s.y + 1] != 3)
                        mass[s.x - 1, s.y + 1] = 2;
                if (s.x >= 0 & s.y + 1 >= 0 & s.x < 10 & s.y + 1 < 10)
                    if (mass[s.x, s.y + 1] != 3)
                        mass[s.x, s.y + 1] = 2;
                if (s.x + 1 >= 0 & s.y + 1 >= 0 & s.x + 1 < 10 & s.y + 1 < 10)
                    if (mass[s.x + 1, s.y + 1] != 3)
                        mass[s.x + 1, s.y + 1] = 2;
            } 
        }

        public int[,] FinishedOffShip(Ship ship)
        {
            Random r = new Random();
            int num = ship.Hits;
            int shot = ship.Lifes - num;
            Location[] loc= new Location[ship.Lifes];
            if(num>1)
            {
                
                for (int i = 0; i < ship.Lifes; i++)
                {
                    loc[i] = new Location(ship.ShipLoc[i].x, ship.ShipLoc[i].y);
                    if (massShips[ship.ShipLoc[i].x, ship.ShipLoc[i].y] == 1)
                    {
                        ev.Shot(new Location(ship.ShipLoc[i].x, ship.ShipLoc[i].y), repo.Ships);
                        massShips[ship.ShipLoc[i].x, ship.ShipLoc[i].y] = 3;
                    }
                }
                ShowUnplayableDots(loc, massShips);
                return massShips;
            }
            else
            {
                Location dot=new Location(0,0);
                int randomPos = r.Next(0, 4);
                for (int i = 0; i < ship.Lifes; i++)
                {
                    if(massShips[ship.ShipLoc[i].x,ship.ShipLoc[i].y]==3)
                    {
                        dot.x = ship.ShipLoc[i].x;
                        dot.y = ship.ShipLoc[i].y;
                    }
                }
                var status = AutoChecking(ref randomPos, dot.x, dot.y, repo.Ships , 2);
                if (status.Item1 == Events.shotStatus.miss)
                {
                    massShips[status.Item2.x, status.Item2.y] = 2;
                    return massShips;
                }
                if (status.Item1 == Events.shotStatus.kill)
                {
                    massShips[status.Item2.x, status.Item2.y] = 3;
                    var massLoc = new Location[]
                    {
                        new Location(dot.x,dot.y),
                        new Location(status.Item2.x, status.Item2.y)
                    };
                    ShowUnplayableDots(massLoc, massShips);
                    if (repo.Ships.Count != 0)
                    {
                        return ComputerActionFirstShot();
                    }
                    else { return massShips; }
                }
                if (status.Item1 == Events.shotStatus.hit)
                {
                    massShips[status.Item2.x, status.Item2.y] = 3;
                    var statusSecond = AutoChecking(ref randomPos, status.Item2.x, status.Item2.y, repo.Ships, 3);
                    if (statusSecond.Item1 == Events.shotStatus.miss)
                    {
                        massShips[statusSecond.Item2.x, statusSecond.Item2.y] = 2;
                        return massShips;
                    }
                    if (statusSecond.Item1 == Events.shotStatus.kill)
                    {
                        massShips[statusSecond.Item2.x, statusSecond.Item2.y] = 3;
                        var massLoc = new Location[]
                         {
                            new Location(dot.x,dot.y),
                            new Location(status.Item2.x, status.Item2.y),
                            new Location(statusSecond.Item2.x, statusSecond.Item2.y)
                         };
                        ShowUnplayableDots(massLoc, massShips);
                        if (repo.Ships.Count != 0)
                        {
                            return ComputerActionFirstShot();
                        }
                        else { return massShips; }
                    }
                    if (statusSecond.Item1 == Events.shotStatus.hit)
                    {
                        massShips[statusSecond.Item2.x, statusSecond.Item2.y] = 3;
                        var statusThird = AutoChecking(ref randomPos, statusSecond.Item2.x, statusSecond.Item2.y, repo.Ships, 4);
                        if (statusThird.Item1 == Events.shotStatus.miss)
                        {
                            massShips[statusThird.Item2.x, statusThird.Item2.y] = 2;
                            return massShips;
                        }
                        if (statusThird.Item1 == Events.shotStatus.kill)
                        {
                            massShips[statusThird.Item2.x, statusThird.Item2.y] = 3;
                            var massLoc = new Location[]
                             {
                                 new Location(dot.x,dot.y),
                                 new Location(status.Item2.x, status.Item2.y),
                                 new Location(statusSecond.Item2.x, statusSecond.Item2.y),
                                 new Location(statusThird.Item2.x, statusThird.Item2.y)
                             };
                            ShowUnplayableDots(massLoc, massShips);
                            if (repo.Ships.Count != 0)
                            {
                                return ComputerActionFirstShot();
                            }
                            else { return massShips; }
                        }
                    }
                }
            }
            return massShips;
        }
    }
}
