using BattleShip.Data;
using BattleShip.Logic;
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
        ShipPlacement shipPlacement = new ShipPlacement();
        Repository repo = Repository.GetInstance();
        ComputerLogic computerLogic = new ComputerLogic();

        public ShipPlacementPage()
        {
            InitializeComponent();
            textBoxUserName.Text = GameSettings.GetInstance().UserName;
            labelHint.Content = repo.LabelContent[0];
            UpdateLabelShips();
        }

        private void canvasField_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(canvasField);
            int x = (int)(position.X / (canvasField.ActualWidth / 10));
            int y = (int)(position.Y / (canvasField.ActualHeight / 10));
            Location p = new Location(x, y);

            int result = shipPlacement.CheckPosition(0, x, y);
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
            var result = shipPlacement.PlaceShip(0);
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

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (shipPlacement.StartGame() == false)
            {
                labelHint.Content = repo.LabelContent[9];
                return;
            }

            GameSettings.GetInstance().UserName = textBoxUserName.Text;
            OnePlayerPage onePlayerPage = new OnePlayerPage();
            NavigationService.Navigate(onePlayerPage);
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            shipPlacement.Clear(0);
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
            if (repo.Ships.Count != 0 || repo.Clicks.Count != 0)
            {
                labelHint.Content = repo.LabelContent[11];
                return;
            }

            computerLogic.RandomPlaceShip(repo.Ships);
            foreach (var ship in repo.Ships)
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
    }
}
