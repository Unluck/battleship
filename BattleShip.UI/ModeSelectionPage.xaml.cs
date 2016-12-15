using BattleShip.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для ModeSelectionPage.xaml
    /// </summary>
    public partial class ModeSelectionPage : Page
    {
        public ModeSelectionPage()
        {
            InitializeComponent();
            checkBoxMusic.IsChecked = GameSettings.GetInstance().BackgroundMusic;
            checkBoxSound.IsChecked = GameSettings.GetInstance().GameplaySounds;
        }

        private void buttonOnePlayer_Click(object sender, RoutedEventArgs e)
        {
            ShipPlacementPage shipPlacementPage = new ShipPlacementPage();
            NavigationService.Navigate(shipPlacementPage);
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            StartingPage startingPage = new StartingPage();
            NavigationService.Navigate(startingPage);
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
