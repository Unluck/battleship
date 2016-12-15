using System.Windows;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            StartingPage startingPage = new StartingPage();
            frameLayout.NavigationService.Navigate(startingPage);
        }
    }
}
