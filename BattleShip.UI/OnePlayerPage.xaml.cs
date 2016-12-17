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
                
                if(i==0)
                    ln.X1 = x * 30;
                    ln.X2 = x * 30 + 30;
                    ln.Y1 = y * 30;
                    ln.Y2 = y * 30 + 30;
                    //ln.HorizontalAlignment = HorizontalAlignment.Left;
                if (i == 1)
                    ln.X1 = x * 30+30;
                    ln.X2 = x * 30 ;
                    ln.Y1 = y * 30;
                    ln.Y2 = y * 30+30;
                    //ln.HorizontalAlignment = HorizontalAlignment.Right;
                ln.StrokeThickness = 2;
                canvasPlayerField.Children.Add(ln);
            }
           
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
            cl.UserShip();

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
            Point position = e.GetPosition(canvasEnemyField);
            int x = (int)(position.X / (canvasEnemyField.ActualWidth / 10));
            int y = (int)(position.Y / (canvasEnemyField.ActualHeight / 10));
            Location p = new Location(x, y);
            Events ev = new Events();
            var shotStatus = ev.Shot(p,repo.EnemyShips);
            labelStatus.Content = shotStatus;

            int[,] status=null;
            int ch = 0;
            foreach (var s in repo.Ships)
            {
                if(s.Hits>0)
                {
                    status = cl.FinishedOffShip(s);
                    ch++;
                }
                if (ch > 0) goto next;
            }
            status=cl.ComputerActionFirstShot();
            next:
            for (int i = 0; i < status.GetLength(0); i++)
            {
                for (int j = 0; j < status.GetLength(1); j++)
                {
                    if(status[i,j]==3) DisplayShot(i, j);
                    if (status[i, j] == 2) DisplayMiss(i, j);
                }
            }
            
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
