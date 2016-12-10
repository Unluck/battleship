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
using BattleShip.Logic;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для OnePlayer.xaml
    /// </summary>
    public partial class OnePlayer : Window
    {
        Field kek = new Field();
        public OnePlayer()
        {
            InitializeComponent();
            
        }
    }
}
