using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.Data.Properties;

namespace BattleShip.Data
{
    public class GameSettings
    {
        private static GameSettings _settings;

        public static GameSettings GetInstance()
        {
            if (_settings == null)
                _settings = new GameSettings();

            return _settings;
        }

        public string UserName
        {
            get { return Settings.Default.UserName; }
            set
            {
                Settings.Default.UserName = value;
                Settings.Default.Save();
            }
        }

        public bool BackgroundMusic
        {
            get { return Settings.Default.BackgroundMusic; }
            set
            {
                Settings.Default.BackgroundMusic = value;
                Settings.Default.Save();
            }
        }

        public bool GameplaySounds
        {
            get { return Settings.Default.GameplaySounds; }
            set
            {
                Settings.Default.GameplaySounds = value;
                Settings.Default.Save();
            }
        }
    }
}
