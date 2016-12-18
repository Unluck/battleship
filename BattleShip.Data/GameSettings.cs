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
    }
}
