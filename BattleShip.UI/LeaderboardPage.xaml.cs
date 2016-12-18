using BattleShip.Data;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Linq;

namespace BattleShip.UI
{
    /// <summary>
    /// Логика взаимодействия для LeaderboardPage.xaml
    /// </summary>
    public partial class LeaderboardPage : Page
    {
        LeaderBoard lb = new LeaderBoard();
        public LeaderboardPage()
        {
            InitializeComponent();
            string[] result=lb.DownLoadBoard();
            var sortResult = from s in result
                             orderby s descending
                             select s;
            var sortListResult=sortResult.ToList();
            if(result.Length>0)
                lb1.Content = sortListResult[0];
            if (result.Length>1)
                lb2.Content = sortListResult[1];
            if (result.Length>2)
                lb3.Content = sortListResult[2];
            if (result.Length>3)
                lb4.Content = sortListResult[3];
            if (result.Length>4)
                lb5.Content = sortListResult[4];

        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            
            StartingPage startingPage = new StartingPage();
            NavigationService.Navigate(startingPage);
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
