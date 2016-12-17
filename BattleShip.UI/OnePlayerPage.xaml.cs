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
        Repository repo = Repository.GetInstance();
        List<Ship> ranShip = new List<Ship>();
        ComputerLogic cl = new ComputerLogic();
        private void DisplayShip(int x, int y)
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
            canvasPlayerField.Children.Add(rc);
        }
        public void DisplayShot(int x, int y)
        {
            for (int i = 0; i < 2; i++)
            {
                Line ln = new Line();
                ln.Stroke = System.Windows.Media.Brushes.Black;
                ln.X1 = x * 30;
                ln.X2 = x * 30 + 30;
                ln.Y1 = y * 30;
                ln.Y2 = y * 30 + 30;
                if(i==0)
                    ln.HorizontalAlignment = HorizontalAlignment.Left;
                if (i == 1)
                    ln.HorizontalAlignment = HorizontalAlignment.Right;
                ln.StrokeThickness = 2;
                canvasPlayerField.Children.Add(ln);
            }
            
            /*Line ln = new Line();
            ln.Stroke = System.Windows.Media.Brushes.Black;
            ln.X1 = x * 30;
            ln.X2 = x * 30 + 30;
            ln.Y1 = y * 30;
            ln.Y2 = y * 30 + 30;
            ln.HorizontalAlignment = HorizontalAlignment.Right;
            ln.StrokeThickness = 2;
            canvasPlayerField.Children.Add(ln);*/

        }
        public void DisplayMiss(int x,int y)
        {
            Ellipse el = new Ellipse();
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(192, 192, 192);
            el.Fill = scb;
            el.Width = 15;
            el.Height = 15;
            Thickness margin = el.Margin;
            margin.Top = y * 30 +7.5;
            margin.Left = x * 30+7.5;
            el.Margin = margin;
            canvasPlayerField.Children.Add(el);
        }
        public OnePlayerPage()
        {
            InitializeComponent();
            checkBoxMusic.IsChecked = GameSettings.GetInstance().BackgroundMusic;
            checkBoxSound.IsChecked = GameSettings.GetInstance().GameplaySounds;
            

            cl.RandomPlaceShip(repo.EnemyShips);
            foreach (var ship in repo.Ships)
                foreach (var location in ship.ShipLoc)
                    DisplayShip(location.x, location.y);

            foreach (var s1 in repo.EnemyShips)
                foreach (var s2 in s1.ShipLoc)
                {
                    Rectangle rc = new Rectangle();
                    SolidColorBrush scb = new SolidColorBrush();
                    scb.Color = Color.FromRgb(255, 000, 255);
                    rc.Fill = scb;
                    rc.Width = 30;
                    rc.Height = 30;
                    Thickness margin = rc.Margin;
                    margin.Top = s2.y * 30;
                    margin.Left = s2.x * 30;
                    rc.Margin = margin;
                    canvasEnemyField.Children.Add(rc);
                }
        }

        private void canvasEnemyField_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /*Point position = e.GetPosition(canvasEnemyField);
            int x = (int)(position.X / (canvasEnemyField.ActualWidth / 10));
            int y = (int)(position.Y / (canvasEnemyField.ActualHeight / 10));
            Location p = new Location(x, y);
            Events ev = new Events();
            var shotStatus = ev.Shot(p);

            labelStatus.Content = shotStatus;
            var status=cl.ComputerActionFirstShot(repo.Ships);
            if (status.Item2 == false)
                DisplayMiss(status.Item1.x,status.Item1.y);
            if (status.Item2 == true)
                DisplayShot(status.Item1.x, status.Item1.y);*/
            
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
