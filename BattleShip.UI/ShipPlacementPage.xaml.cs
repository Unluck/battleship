using BattleShip.Data;
using BattleShip.Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для ShipPlacementPage.xaml
    /// </summary>
    public partial class ShipPlacementPage : Page
    {
        List<Location> clicks = new List<Location>();
        List<Location> clicksExtended = new List<Location>();
        public List<Ship> ships = new List<Ship>();
        int[,] field = new int[12, 12];
        int[] cells = new int[4] { 4, 3, 2, 1 };

        public ShipPlacementPage()
        {
            InitializeComponent();
            checkBoxMusic.IsChecked = GameSettings.GetInstance().BackgroundMusic;
            checkBoxSound.IsChecked = GameSettings.GetInstance().GameplaySounds;
            textBoxUserName.Text = GameSettings.GetInstance().UserName;
            labelHint.Content = "Hint: Place one ship of any type\nby clicking on cells.";
            labelShips.Content = string.Format("4 cells: {0}\n3 cells: {1}\n2 cells: {2}\n1 cell: {3}", cells[3], cells[2], cells[1], cells[0]);
        }

        private void canvasField_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(canvasField);
            int x = (int)(position.X / (canvasField.ActualWidth / 10));
            int y = (int)(position.Y / (canvasField.ActualHeight / 10));
            Location p = new Location(x, y);
            Rectangle rc = new Rectangle();
            SolidColorBrush scb = new SolidColorBrush();

            if (ships.Count != 0)
                foreach (var ship in ships)
                    foreach (var location in ship.ShipLoc)
                        if (location.x == x && location.y == y)
                        {
                            labelHint.Content = "Hint: Cell already exists.";
                            return;
                        }

            foreach (var click in clicks)
                if (click.x == x && click.y == y)
                {
                    labelHint.Content = "Hint: Cell already exists.";
                    return;
                }

            if (field[x + 1, y + 1] == 4)
            {
                labelHint.Content = "Hint: You cannot place ship near\nexisting one.";
                return;
            }

            if (clicks.Count >= 2)
            {
                if (field[clicks[1].x, clicks[1].y] == 1 && clicks[1].y != y)
                {
                    labelHint.Content = "Hint: Cells of one ship must be\nnear each other as single line.\nUse \"Add ship\" to place current\nship firstly.";
                    return;
                }

                if (field[clicks[1].x, clicks[1].y] == 2 && clicks[1].x != x)
                {
                    labelHint.Content = "Hint: Cells of one ship must be\nnear each other as single line.\nUse \"Add ship\" to place current\nship firstly.";
                    return;
                }
            }

            if (clicks.Count != 0 && field[x + 1, y + 1] != 1 && field[x + 1, y + 1] != 2)
            {
                labelHint.Content = "Hint: Cells of one ship must be\nnear each other as single line.\nUse \"Add ship\" to place current\nship firstly.";
                return;
            }

            if (clicks.Count == 4)
            {
                labelHint.Content = "Hint: Maximum size of a ship is 4 cells.\nUse \"Add ship\" to place current ship firstly.";
                return;
            }

            scb.Color = Color.FromRgb(0, 191, 255);
            rc.Fill = scb;
            rc.Width = 30;
            rc.Height = 30;
            Thickness margin = rc.Margin;
            margin.Top = p.y * 30;
            margin.Left = p.x * 30;
            rc.Margin = margin;
            canvasField.Children.Add(rc);
            fieldPlacement(x, y);
            clicks.Add(p);
            clicksExtended.Add(p);
            labelHint.Content = "Hint: Cell added.";
        }

        private void buttonPlace_Click(object sender, RoutedEventArgs e)
        {
            var location = new Location[clicks.Count];

            if (clicks.Count == 0)
            {
                labelHint.Content = "Hint: Place ship firstly.";
                return;
            }

            if (cells[clicks.Count - 1] == 0)
            {
                int count = clicksExtended.Count;
                labelHint.Content = "Hint: You do not have any\nships of this type left.";
                for (int i = count; i > count - clicks.Count; i--)
                {
                    canvasField.Children.RemoveAt(i - 1);
                    clicksExtended.RemoveAt(i - 1);
                }

                clicks.Clear();
                for (int i = 0; i < 12; i++)
                    for (int j = 0; j < 12; j++)
                        if (field[i, j] != 4)
                            field[i, j] = 0;
                return;
            }

            for (int i = 0; i < clicks.Count; i++)
            {
                location[i] = clicks[i];
                shipPlaced(location[i]);
            }

            ships.Add(new Ship(clicks.Count, 0, location));
            cells[clicks.Count - 1] -= 1;

            clicks.Clear();
            labelHint.Content = "Hint: Ship added.";
            labelShips.Content = string.Format("4 cells: {0}\n3 cells: {1}\n2 cells: {2}\n1 cell: {3}", cells[3], cells[2], cells[1], cells[0]);
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
                if (cells[i] != 0)
                {
                    labelHint.Content = "Hint: Place all ships firstly.";
                    return;
                }

            GameSettings.GetInstance().UserName = textBoxUserName.Text;

            OnePlayerPage onePlayerPage = new OnePlayerPage(ships);
            NavigationService.Navigate(onePlayerPage);
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    field[i, j] = 0;

            cells = new int[4] { 4, 3, 2, 1 };
            canvasField.Children.Clear();
            clicks.Clear();
            clicksExtended.Clear();
            ships.Clear();
        }

        public void fieldPlacement(int x, int y)
        {
            x = x + 1;
            y = y + 1;

            if (field[x - 1, y - 1] != 3 && field[x - 1, y - 1] != 4)
                field[x - 1, y - 1] = 3;
            if (field[x - 1, y] != 3 && field[x - 1, y] != 4)
                field[x - 1, y] = 1;
            if (field[x - 1, y + 1] != 3 && field[x - 1, y + 1] != 4)
                field[x - 1, y + 1] = 3;
            if (field[x, y - 1] != 3 && field[x, y - 1] != 4)
                field[x, y - 1] = 2;
            if (field[x, y] != 3 && field[x, y] != 4)
                field[x, y] = 5;
            if (field[x, y + 1] != 3 && field[x, y + 1] != 4)
                field[x, y + 1] = 2;
            if (field[x + 1, y - 1] != 3 && field[x + 1, y - 1] != 4)
                field[x + 1, y - 1] = 3;
            if (field[x + 1, y] != 3 && field[x + 1, y] != 4)
                field[x + 1, y] = 1;
            if (field[x + 1, y + 1] != 3 && field[x + 1, y + 1] != 4)
                field[x + 1, y + 1] = 3;
        }

        public void shipPlaced(Location location)
        {
            int x = location.x + 1;
            int y = location.y + 1;

            field[x - 1, y - 1] = 4;
            field[x - 1, y] = 4;
            field[x - 1, y + 1] = 4;
            field[x, y - 1] = 4;
            field[x, y] = 4;
            field[x, y + 1] = 4;
            field[x + 1, y - 1] = 4;
            field[x + 1, y] = 4;
            field[x + 1, y + 1] = 4;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            ModeSelectionPage modeSelectionPage = new ModeSelectionPage();
            NavigationService.Navigate(modeSelectionPage);
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
