using BattleShip.Data;
using BattleShip.Logic;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для OnePlayerPage.xaml
    /// </summary>
    public partial class OnePlayerPage : Page
    {
        StartingPage startingPage = new StartingPage();
        GameResultWindow gameWin = new GameResultWindow(true, 0);
        GameResultWindow gameLose = new GameResultWindow(false, 0);
        Repository repo = Repository.GetInstance();
        List<Ship> ranShip = new List<Ship>();
        ComputerLogic cl = new ComputerLogic();
        LeaderBoard lb = new LeaderBoard();
        int[,] shots = new int[10, 10];
        bool gameOver = new bool();

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

        public OnePlayerPage()
        {
            InitializeComponent();
            cl.RandomPlaceShip(repo.EnemyShips);
            UpdateLabelShips();

            foreach (var ship in repo.Ships)
                foreach (var location in ship.ShipLoc)
                    DisplayShip(canvasPlayerField, location.x, location.y);
            cl.UserShip();


        }

        private void canvasEnemyField_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (gameOver == true)
                return;

            Point position = e.GetPosition(canvasEnemyField);
            int x = (int)(position.X / (canvasEnemyField.ActualWidth / 10));
            int y = (int)(position.Y / (canvasEnemyField.ActualHeight / 10));
            Location p = new Location(x, y);
            Events ev = new Events();
            if (shots[x, y] == 1)
                return;

            var shotStatus = ev.Shot(p, repo.EnemyShips);
            shots[x, y] = 1;

            if (shotStatus == Events.shotStatus.hit)
            {
                DisplayShot(canvasEnemyField, x, y);
                return;
            }

            else if (shotStatus == Events.shotStatus.kill)
            {
                DisplayShot(canvasEnemyField, x, y);
                UpdateLabelShips();
                if (repo.EnemyShips.Count == 0)
                {
                    int score = 10000 * repo.Ships.Count;
                    string name = GameSettings.GetInstance().UserName;
                    string result = string.Format("{0} {1}\n", score.ToString(), name);
                    lb.UpLoadBoard(result);
                    var dialogResult = gameWin.ShowDialog();

                    if (dialogResult == false)
                        NavigationService.Navigate(startingPage); return;
                }
                return;
            }

            else DisplayMiss(canvasEnemyField, x, y);

            int[,] status = null;
            int ch = 0;
            foreach (var s in repo.Ships)
            {
                if (s.Hits > 0)
                {
                    status = cl.FinishedOffShip(s);
                    ch++;
                }
                if (ch > 0) goto next;
            }
            status = cl.ComputerActionFirstShot();
            next:
            for (int i = 0; i < status.GetLength(0); i++)
            {
                for (int j = 0; j < status.GetLength(1); j++)
                {
                    if (status[i, j] == 3) DisplayShot(canvasPlayerField, i, j);
                    if (status[i, j] == 2) DisplayMiss(canvasPlayerField, i, j);
                }
            }



            if (repo.Ships.Count == 0)
            {
 
                var dialogResult = gameLose.ShowDialog();

                if (dialogResult == false)
                    NavigationService.Navigate(startingPage);

                if (dialogResult == true)
                {
                    gameOver = true;
                    buttonMainMenu.Visibility = Visibility.Visible;
                    buttonQuit.Visibility = Visibility.Visible;

                    foreach (var ship in repo.EnemyShips)
                        foreach (var location in ship.ShipLoc)
                            DisplayShip(canvasEnemyField, location.x, location.y);
                }
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

        public void UpdateLabelShips()
        {
            repo.Cells = new int[4] { 0, 0, 0, 0 };

            foreach (var ship in repo.EnemyShips)
                repo.Cells[ship.Lifes - 1]++;

            labelShips.Content = string.Format("Enemy ships:\n4 cells: {0}\n3 cells: {1}\n2 cells: {2}\n1 cell: {3}",
                repo.Cells[3], repo.Cells[2], repo.Cells[1], repo.Cells[0]);
        }
    }
}