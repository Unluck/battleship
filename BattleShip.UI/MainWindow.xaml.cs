using BattleShip.Data;
using BattleShip.UI.Properties;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBoxUserName.Text = Settings.GetInstance().UserName;
            //MusicSettings.BackgroundMusic();
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            ModeSelectionWindow ModeSelectionWindow = new ModeSelectionWindow();
            ModeSelectionWindow.ShowDialog();
            Settings.GetInstance().UserName = textBoxUserName.Text;
        }
    }
}
