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
using System.Windows.Shapes;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для ShipPlacementWindow.xaml
    /// </summary>
    public partial class ShipPlacementWindow : Window
    {
        List<Location> click = new List<Location>();
        //public Events ev = new Events();
        public List<Ship> ownShip = new List<Ship>();

        public ShipPlacementWindow()
        {
            InitializeComponent();
            checkBoxMusic.IsChecked = GameSettings.GetInstance().BackgroundMusic;
            checkBoxSound.IsChecked = GameSettings.GetInstance().GameplaySounds;
            textBoxUserName.Text = GameSettings.GetInstance().UserName;
        }

        private void canvasField_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(canvasField);
            Location p = new Location((int)(position.X / (canvasField.ActualWidth / 10)), (int)(position.Y / (canvasField.ActualHeight / 10)));
            Rectangle rc = new Rectangle();
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(100,120,100);
            rc.Fill = scb;
            rc.Width = 30;
            rc.Height = 30;
            Thickness margin = rc.Margin;
            margin.Top = p.y*30;
            margin.Left = p.x*30;
            rc.Margin = margin;
            canvasField.Children.Add(rc);
            click.Add(p);
            
        }

        private void buttonPlace_Click(object sender, RoutedEventArgs e)
        {
            var location = new Location[click.Count];
            for (int i = 0; i < click.Count; i++)
            {
                location[i] = click[i];
            }
            ownShip.Add(new Ship(click.Count, 0, location));
            click.Clear();
            
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            OnePlayerWindow OnePlayerWindow = new OnePlayerWindow();
            OnePlayerWindow.ShowDialog();
        }

        private void checkBoxSound_Click(object sender, RoutedEventArgs e)
        {
            GameSettings.GetInstance().GameplaySounds = checkBoxSound.IsChecked.Value;
        }

        private void checkBoxMusic_Click(object sender, RoutedEventArgs e)
        {
            GameSettings.GetInstance().BackgroundMusic = checkBoxMusic.IsChecked.Value;
        }

        private void textBoxUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            GameSettings.GetInstance().UserName = textBoxUserName.Text;
        }
    }
}
