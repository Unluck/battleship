﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Data
{
    public class LeaderBoard
    {
        public string[] DownLoadBoard()
        {
            string[] lines = File.ReadAllLines("../../../BattleShip.Data/LeaderBoard/leaderboard.txt", Encoding.UTF8);
            return lines;
        }
        
        public void UpLoadBoard(string str)
        {
            File.AppendAllText("../../../BattleShip.Data/LeaderBoard/leaderboard.txt", str, Encoding.UTF8);
        }
    }
}
