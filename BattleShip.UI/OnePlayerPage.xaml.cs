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
    /// Логика взаимодействия для OnePlayerPage.xaml
    /// </summary>
    public partial class OnePlayerPage : Page
    {
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
            ownField.Children.Add(rc);
        }

        public OnePlayerPage(List<Ship> ships)
        {
            InitializeComponent();
            checkBoxMusic.IsChecked = GameSettings.GetInstance().BackgroundMusic;
            checkBoxSound.IsChecked = GameSettings.GetInstance().GameplaySounds;

            ComputerLogic cl = new ComputerLogic();
            cl.RandomPlaceShip();
            foreach (var ship in ships)
                foreach (var location in ship.ShipLoc)
                    DisplayShip(location.x, location.y);

            foreach (var s1 in cl.enemyShip)
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
                    enemyField.Children.Add(rc);
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
