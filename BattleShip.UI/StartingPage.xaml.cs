using BattleShip.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Page
    {
        public StartingPage()
        {
            InitializeComponent();
            checkBoxMusic.IsChecked = GameSettings.GetInstance().BackgroundMusic;
            checkBoxSound.IsChecked = GameSettings.GetInstance().GameplaySounds;
            //MusicSettings.BackgroundMusic();
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            ModeSelectionPage modeSelectionPage = new ModeSelectionPage();
            NavigationService.Navigate(modeSelectionPage);
        }

        private void buttonLeaderboard_Click(object sender, RoutedEventArgs e)
        {
        }

        #region Settings
        private void checkBoxSound_Click(object sender, RoutedEventArgs e)
        {
            GameSettings.GetInstance().GameplaySounds = checkBoxSound.IsChecked.Value;
        }

        private void checkBoxMusic_Click(object sender, RoutedEventArgs e)
        {
            GameSettings.GetInstance().BackgroundMusic = checkBoxMusic.IsChecked.Value;
        }
        #endregion
    }
}
