using BattleShip.Data;
using BattleShip.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для TwoPlayersShipPlacementPage.xaml
    /// </summary>
    public partial class TwoPlayersShipPlacementPage : Page
    {
        ShipPlacement shipPlacement = new ShipPlacement();
        Repository repo = Repository.GetInstance();
        ComputerLogic computerLogic = new ComputerLogic();
        int player = new int();
        List<Ship>[] ships = new List<Ship>[2] { Repository.GetInstance().Ships, Repository.GetInstance().EnemyShips };

        public TwoPlayersShipPlacementPage(int playercount)
        {
            InitializeComponent();
            checkBoxMusic.IsChecked = GameSettings.GetInstance().BackgroundMusic;
            checkBoxSound.IsChecked = GameSettings.GetInstance().GameplaySounds;

            if (playercount == 1)
            {
                labelPlayer.Content = "PLAYER 2";
                buttonBack.Visibility = Visibility.Hidden;
            }

            player = playercount;
        }

        private void canvasField_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(canvasField);
            int x = (int)(position.X / (canvasField.ActualWidth / 10));
            int y = (int)(position.Y / (canvasField.ActualHeight / 10));
            Location p = new Location(x, y);

            int result = shipPlacement.CheckPosition(player, x, y);
            if (result != 5)
            {
                labelHint.Content = repo.LabelContent[result];
                return;
            }

            DrawShip(x, y);
            shipPlacement.FieldPlacement(x, y);
            repo.Clicks.Add(p);
            repo.ClicksExtended.Add(p);
            labelHint.Content = repo.LabelContent[5];
        }

        private void buttonPlace_Click(object sender, RoutedEventArgs e)
        {
            var count = repo.ClicksExtended.Count;
            var result = shipPlacement.PlaceShip(player);
            if (result != 8)
            {
                labelHint.Content = repo.LabelContent[result];

                if (result == 7)
                {
                    for (int i = count; i > count - repo.Clicks.Count; i--)
                    {
                        canvasField.Children.RemoveAt(i - 1);
                        repo.ClicksExtended.RemoveAt(i - 1);
                    }

                    repo.Clicks.Clear();
                }

                return;
            }

            labelHint.Content = repo.LabelContent[8];
            UpdateLabelShips();
        }

        private void buttonReady_Click(object sender, RoutedEventArgs e)
        {
            if (player == 0)
            {
                shipPlacement.Clear(2);
                TwoPlayersShipPlacementPage twoPlayersShipPlacementPage = new TwoPlayersShipPlacementPage(1);
                NavigationService.Navigate(twoPlayersShipPlacementPage);
            }

            if(player == 1)
            {
                TwoPlayersPage twoPlayersPage = new TwoPlayersPage();
                NavigationService.Navigate(twoPlayersPage);
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            shipPlacement.Clear(player);
            canvasField.Children.Clear();
            labelHint.Content = repo.LabelContent[10];
            UpdateLabelShips();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            shipPlacement.Clear(0);
            ModeSelectionPage modeSelectionPage = new ModeSelectionPage();
            NavigationService.Navigate(modeSelectionPage);
        }

        private void buttonRandom_Click(object sender, RoutedEventArgs e)
        {
            if (ships[player].Count != 0 || repo.Clicks.Count != 0)
            {
                labelHint.Content = repo.LabelContent[11];
                return;
            }

            computerLogic.RandomPlaceShip(ships[player]);
            foreach (var ship in ships[player])
                foreach (var location in ship.ShipLoc)
                    DrawShip(location.x, location.y);
            labelHint.Content = repo.LabelContent[12];
            repo.Cells = new int[4] { 0, 0, 0, 0 };
            UpdateLabelShips();
        }

        private void DrawShip(int x, int y)
        {
            Rectangle rc = new Rectangle();
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(0, 191, 255);
            rc.Fill = scb;
            rc.Width = 30;
            rc.Height = 30;
            Thickness margin = rc.Margin;
            margin.Top = y * 30;
            margin.Left = x * 30;
            rc.Margin = margin;
            canvasField.Children.Add(rc);
        }

        public void UpdateLabelShips()
        {
            labelShips.Content = string.Format("4 cells: {0}\n3 cells: {1}\n2 cells: {2}\n1 cell: {3}",
                repo.Cells[3], repo.Cells[2], repo.Cells[1], repo.Cells[0]);
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
