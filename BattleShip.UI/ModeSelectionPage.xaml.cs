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
        }

        private void buttonOnePlayer_Click(object sender, RoutedEventArgs e)
        {
            ShipPlacementPage shipPlacementPage = new ShipPlacementPage();
            NavigationService.Navigate(shipPlacementPage);
        }

        private void buttonTwoPlayers_Click(object sender, RoutedEventArgs e)
        {
            TwoPlayersShipPlacementPage twoPlayersShipPlacementPage = new TwoPlayersShipPlacementPage(0);
            NavigationService.Navigate(twoPlayersShipPlacementPage);
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            StartingPage startingPage = new StartingPage();
            NavigationService.Navigate(startingPage);
        }
    }
}
