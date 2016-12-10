using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.Data.Properties;

namespace BattleShip.Data
{
    public class Settings
    {
        private static Settings _settings;

        public static Settings GetInstance()
        {
            if (_settings == null)
                _settings = new Settings();

            return _settings;
        }

        public string UserName
        {
            get { return Properties.Settings.Default.UserName; }
            set
            {
                Properties.Settings.Default.UserName = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool BackgroundMusic
        {
            get { return Properties.Settings.Default.BackgroundMusic; }
            set
            {
                Properties.Settings.Default.BackgroundMusic = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool GameplaySounds
        {
            get { return Properties.Settings.Default.GameplaySounds; }
            set
            {
                Properties.Settings.Default.GameplaySounds = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
