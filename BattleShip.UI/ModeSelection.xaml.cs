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
    /// Логика взаимодействия для ModeSelection.xaml
    /// </summary>
    public partial class ModeSelection : Window
    {
        public ModeSelection()
        {
            InitializeComponent();
        }

        private void button1Player_Click(object sender, RoutedEventArgs e)
        {
            OnePlayer OnePlayer = new OnePlayer();
            OnePlayer.ShowDialog();
            
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
        }
    }
}
