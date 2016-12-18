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
    /// Логика взаимодействия для TwoPlayersPage.xaml
    /// </summary>
    public partial class TwoPlayersPage : Page
    {
        StartingPage startingPage = new StartingPage();
        Repository repo = Repository.GetInstance();
        List<Ship>[] ships = new List<Ship>[2] { Repository.GetInstance().Ships, Repository.GetInstance().EnemyShips };
        GameResultWindow gameWinOne = new GameResultWindow(true, 1);
        GameResultWindow gameWinTwo = new GameResultWindow(true, 2);
        bool gameOver = new bool();
        bool player = new bool();
        int[,] shotsOne = new int[10, 10];
        int[,] shotsTwo = new int[10, 10];

        public TwoPlayersPage()
        {
            InitializeComponent();
            labelHint.Content = "Player 1 turn to shoot. Click on enemy field";
        }

        private void DisplayShip(Canvas canvas, int x, int y)
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
            canvas.Children.Add(rc);
        }

        public void DisplayShot(Canvas canvas, int x, int y)
        {
            for (int i = 0; i < 2; i++)
            {
                Line ln = new Line();
                ln.Stroke = Brushes.Black;

                if (i == 0)
                {
                    ln.X1 = x * 30;
                    ln.X2 = x * 30 + 30;
                    ln.Y1 = y * 30;
                    ln.Y2 = y * 30 + 30;
                }
                if (i == 1)
                {
                    ln.X1 = x * 30 + 30;
                    ln.X2 = x * 30;
                    ln.Y1 = y * 30;
                    ln.Y2 = y * 30 + 30;
                }
                ln.StrokeThickness = 2;
                canvas.Children.Add(ln);
            }
        }

        public void DisplayMiss(Canvas canvas, int x, int y)
        {
            Ellipse el = new Ellipse();
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(192, 192, 192);
            el.Fill = scb;
            el.Width = 15;
            el.Height = 15;
            Thickness margin = el.Margin;
            margin.Top = y * 30 + 7.5;
            margin.Left = x * 30 + 7.5;
            el.Margin = margin;
            canvas.Children.Add(el);
        }

        private void canvasPlayerOne_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (gameOver == true || player == false)
                return;

            Point position = e.GetPosition(canvasPlayerOne);
            int x = (int)(position.X / (canvasPlayerOne.ActualWidth / 10));
            int y = (int)(position.Y / (canvasPlayerOne.ActualHeight / 10));
            Location p = new Location(x, y);
            Events ev = new Events();
            if (shotsOne[x, y] == 1)
                return;

            var shotStatus = ev.Shot(p, ships[0]);
            shotsOne[x, y] = 1;

            if (shotStatus == Events.shotStatus.hit)
            {
                labelHint.Content = "Hit! Shoot again.";
                DisplayShot(canvasPlayerOne, x, y);
                return;
            }

            else if (shotStatus == Events.shotStatus.kill)
            {
                labelHint.Content = "Kill! Shoot again.";
                DisplayShot(canvasPlayerOne, x, y);

                if (ships[0].Count == 0)
                {
                    var dialogResult = gameWinTwo.ShowDialog();

                    if (dialogResult == false)
                        NavigationService.Navigate(startingPage);

                    else if (dialogResult == true)
                    {
                        gameOver = true;
                        buttonMainMenu.Visibility = Visibility.Visible;
                        buttonQuit.Visibility = Visibility.Visible;

                        foreach (var ship in ships[1])
                            foreach (var location in ship.ShipLoc)
                                DisplayShip(canvasPlayerTwo, location.x, location.y);
                    }
                }

                return;
            }

            else
            {
                labelHint.Content = "Player 2 missed. Turn comes to Player 1.";
                DisplayMiss(canvasPlayerOne, x, y);
                player = false;
            }
        }

        private void canvasPlayerTwo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (gameOver == true || player == true)
                return;

            Point position = e.GetPosition(canvasPlayerTwo);
            int x = (int)(position.X / (canvasPlayerTwo.ActualWidth / 10));
            int y = (int)(position.Y / (canvasPlayerTwo.ActualHeight / 10));
            Location p = new Location(x, y);
            Events ev = new Events();
            if (shotsTwo[x, y] == 1)
                return;

            var shotStatus = ev.Shot(p, ships[1]);
            shotsTwo[x, y] = 1;

            if (shotStatus == Events.shotStatus.hit)
            {
                labelHint.Content = "Hit! Shoot again.";
                DisplayShot(canvasPlayerTwo, x, y);
                return;
            }

            else if (shotStatus == Events.shotStatus.kill)
            {
                labelHint.Content = "Kill! Shoot again.";
                DisplayShot(canvasPlayerTwo, x, y);

                if (ships[1].Count == 0)
                {
                    var dialogResult = gameWinOne.ShowDialog();

                    if (dialogResult == false)
                        NavigationService.Navigate(startingPage);

                    else if (dialogResult == true)
                    {
                        gameOver = true;
                        buttonMainMenu.Visibility = Visibility.Visible;
                        buttonQuit.Visibility = Visibility.Visible;

                        foreach (var ship in ships[0])
                            foreach (var location in ship.ShipLoc)
                                DisplayShip(canvasPlayerOne, location.x, location.y);
                    }
                }
                return;
            }
            else
            {
                labelHint.Content = "Player 1 missed. Turn comes to Player 2.";
                DisplayMiss(canvasPlayerTwo, x, y);
                player = true;
            }
        }

        private void buttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            ShipPlacement shipPlacement = new ShipPlacement();
            shipPlacement.Clear(0);
            NavigationService.Navigate(startingPage);
        }

        private void buttonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
