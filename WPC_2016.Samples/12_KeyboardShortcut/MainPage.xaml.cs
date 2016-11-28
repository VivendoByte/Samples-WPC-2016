using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WPC_2016.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WPC_2016.Samples.Sample12
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.loadItems();
        }

        private void loadItems()
        {
            var items = TechnicalSession.Load();
            this.sessionList.ItemsSource = items;
        }

        private void sessionList_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailPage), e.ClickedItem);
        }

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            VirtualKey k = e.Key;

            int index = (int)k - 49;
            bool ctrlStatus = Window.Current.CoreWindow.GetKeyState(VirtualKey.LeftControl) == CoreVirtualKeyStates.Down;
            bool altStatus = Window.Current.CoreWindow.GetKeyState(VirtualKey.Menu) == CoreVirtualKeyStates.Down;

            if (altStatus == true && e.Key == VirtualKey.T)
            {
                this.sessionList.ItemsSource = null;
                return;
            }

            if (altStatus == true && (e.Key == VirtualKey.R || e.Key == VirtualKey.F5))
            {
                this.loadItems();
                return;
            }

            if (index >= 0 && index < this.sessionList.Items.Count)
            {
                if (ctrlStatus == false)
                {
                    this.sessionList.SelectedIndex = index;
                }
                else
                {
                    this.Frame.Navigate(typeof(DetailPage), this.sessionList.Items[index]);
                }
            }
        }
    }
}