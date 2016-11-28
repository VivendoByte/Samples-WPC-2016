using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WPC_2016.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WPC_2016.Samples.Sample01
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<TechnicalSession> sessions;

        public MainPage()
        {
            this.InitializeComponent();
            this.sessions = new ObservableCollection<TechnicalSession>(TechnicalSession.Load());
            this.sessionList.ItemsSource = this.sessions;
        }

        private void Grid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var fe = sender as FrameworkElement;
            var menu = Flyout.GetAttachedFlyout(fe);
            menu.ShowAt(fe);
        }

        #region Function menus
        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            Control ctl = sender as Control;
            TechnicalSession ts = ctl.Tag as TechnicalSession;
            this.sessions.Remove(ts);
        }

        private void CloneItem_Click(object sender, RoutedEventArgs e)
        {
            Control ctl = sender as Control;
            TechnicalSession ts = ctl.Tag as TechnicalSession;

            TechnicalSession newTs = new TechnicalSession();
            newTs.Code = ts.Code;
            newTs.Duration = ts.Duration;
            newTs.Favorites = ts.Favorites;
            newTs.Speaker = ts.Speaker;
            newTs.StartTime = ts.StartTime;
            newTs.Title = ts.Title;

            this.sessions.Add(newTs);
        }

        private async void ShowTime_Click(object sender, RoutedEventArgs e)
        {
            Control ctl = sender as Control;
            TechnicalSession ts = ctl.Tag as TechnicalSession;

            string output = "La sessione comincia in questo momento:\r\n" + ts.StartTime.ToString();
            MessageDialog dlg = new MessageDialog(output);
            await dlg.ShowAsync();
        }
        #endregion
    }
}