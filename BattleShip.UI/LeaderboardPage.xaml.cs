using BattleShip.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для LeaderboardPage.xaml
    /// </summary>
    public partial class LeaderboardPage : Page
    {
        public LeaderboardPage()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            StartingPage startingPage = new StartingPage();
            NavigationService.Navigate(startingPage);
        }
    }
}
