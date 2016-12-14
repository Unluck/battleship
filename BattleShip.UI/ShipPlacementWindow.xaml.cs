using BattleShip.Data;
using BattleShip.Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для ShipPlacementWindow.xaml
    /// </summary>
    public partial class ShipPlacementWindow : Window
    {
        List<Location> click = new List<Location>();
        List<Location> allClicks = new List<Location>();
        //public Events ev = new Events();
        public List<Ship> ownShip = new List<Ship>();
        int[,] field = new int[12, 12];
        int[] cells = new int[4] { 4, 3, 2, 1};

        public ShipPlacementWindow()
        {
            InitializeComponent();
            checkBoxMusic.IsChecked = GameSettings.GetInstance().BackgroundMusic;
            checkBoxSound.IsChecked = GameSettings.GetInstance().GameplaySounds;
            textBoxUserName.Text = GameSettings.GetInstance().UserName;
            labelHelp.Content = "Help: Place one ship of any type\nby clicking on cells.";
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

            if (ownShip.Count != 0)
                foreach (var ship in ownShip)
                    foreach (var location in ship.ShipLoc)                 
                        if (location.x == x && location.y == y)
                        {
                            labelHelp.Content = "Help: Cell already exists.";
                            return;
                        }

            foreach (var click in click)
                if(click.x == x && click.y == y)
                {
                    labelHelp.Content = "Help: Cell already exists.";
                    return;
                }

            if (field[x + 1, y + 1] == 4)
            {
                labelHelp.Content = "Help: You cannot place ship near\nexisting one.";
                return;
            }

            if (click.Count > 0)
            {
                if (click.Count >= 2)
                {
                    if (field[click[1].x, click[1].y] == 1 && click[1].y != y)
                    {
                        labelHelp.Content = "Help: Cells of one ship must be\nnear each other as single line.\nUse \"Add ship\" to place current\nship firstly.";
                        return;
                    }

                    if (field[click[1].x, click[1].y] == 2 && click[1].x != x)
                    {
                        labelHelp.Content = "Help: Cells of one ship must be\nnear each other as single line.\nUse \"Add ship\" to place current\nship firstly.";
                        return;
                    }
                }
            }

            if (click.Count != 0 && field[x + 1, y + 1] != 1 && field[x + 1, y + 1] != 2)
            {
                labelHelp.Content = "Help: Cells of one ship must be\nnear each other as single line.\nUse \"Add ship\" to place current\nship firstly.";
                return;
            }

            if (click.Count == 4)
            {
                labelHelp.Content = "Help: Maximum size of a ship is 4 cells.\nUse \"Add ship\" to place current ship firstly.";
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
            click.Add(p);
            allClicks.Add(p);
            labelHelp.Content = "Help: Cell added.";
        }

        private void buttonPlace_Click(object sender, RoutedEventArgs e)
        {
            var location = new Location[click.Count];

            if (click.Count == 0)
            {
                labelHelp.Content = "Help: Place ship firstly.";
                return;
            }            

            if (cells[click.Count - 1] == 0)
            {
                int count = allClicks.Count;
                labelHelp.Content = "Help: You do not have any\nships of this type left.";
                for (int i = count; i > count - click.Count; i--)
                {
                    canvasField.Children.RemoveAt(i - 1);
                    allClicks.RemoveAt(i - 1);
                }
                click.Clear();
                for (int i = 0; i < 12; i++)
                    for (int j = 0; j < 12; j++)
                        if (field[i, j] != 4)
                            field[i, j] = 0;
                return;
            }

            for (int i = 0; i < click.Count; i++)
            {
                location[i] = click[i];
                shipPlaced(location[i]);
            }

            ownShip.Add(new Ship(click.Count, 0, location));
            cells[click.Count - 1] -= 1;

            click.Clear();
            labelHelp.Content = "Help: Ship added.";
            labelShips.Content = string.Format("4 cells: {0}\n3 cells: {1}\n2 cells: {2}\n1 cell: {3}", cells[3], cells[2], cells[1], cells[0]);
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
                if (cells[i] != 0)
                {
                    labelHelp.Content = "Help: Place all ships firstly.";
                    return;
                }

            GameSettings.GetInstance().UserName = textBoxUserName.Text;
            OnePlayerWindow OnePlayerWindow = new OnePlayerWindow();
            OnePlayerWindow.Show();
            Close();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    field[i, j] = 0;

            cells = new int[4] { 4, 3, 2, 1 };
            canvasField.Children.Clear();
            click.Clear();
            allClicks.Clear();
            ownShip.Clear();
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
