using BattleShip.Data;
using BattleShip.Logic;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для GameResultWindow.xaml
    /// </summary>
    public partial class GameResultWindow : Window
    {
        ShipPlacement shipPlacement = new ShipPlacement();

        public GameResultWindow(bool win)
        {
            InitializeComponent();

            if (win == true) 
            {
                Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/BattleShip.Data;component/Images/GameWonBG.jpg")));
                labelresult.Content = "YOU WON!";
                labelresult.Margin = new Thickness(215, 50, 0, 0);
                labelresult.Foreground = Brushes.LimeGreen;
            }
            
            else
            {
                Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/BattleShip.Data;component/Images/GameLostBG.jpg")));
                labelresult.Content = "YOU LOST!";
                labelresult.Margin = new Thickness(214, 50, 0, 0);
                labelresult.Foreground = Brushes.Red;
                buttonShowShips.Visibility = Visibility.Visible;
            }
        }

        private void buttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            shipPlacement.Clear();
            Repository.GetInstance().EnemyShips.Clear();
            DialogResult = false;
            Close();
        }

        private void buttonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonShowShips_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
