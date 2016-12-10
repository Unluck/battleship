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
        Events ev = new Events();

        public ShipPlacementWindow()
        {
            InitializeComponent();
        }

        private void canvasField_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(canvasField);
            Location p = new Location((int)(position.X / (canvasField.ActualWidth / 10)), (int)(position.Y / (canvasField.ActualHeight / 10)));
            click.Add(p);
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var location = new Location[click.Count];
            for (int i = 0; i < click.Count; i++)
            {
                location[i] = click[i];
            }
             ev.ship.Add(new Ship(click.Count, 0, location));
            click.Clear();
            
        }
    }
}
