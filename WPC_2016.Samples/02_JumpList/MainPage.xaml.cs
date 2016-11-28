using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.StartScreen;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WPC_2016.ObjectModel;

namespace WPC_2016.Samples.Sample02
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.loadItems();
        }

        private void SetFavorites_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var session = (sender as Control).DataContext as TechnicalSession;

            if (session != null)
            {
                session.Favorites = true;
                this.addNewItem(session);
            }
        }

        private void UnsetFavorites_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var session = (sender as Control).DataContext as TechnicalSession;

            if (session != null)
            {
                session.Favorites = false;
                this.removeItem(session);
            }
        }

        private async void loadItems()
        {
            var items = TechnicalSession.Load();
            JumpList jumpList = await JumpList.LoadCurrentAsync();

            foreach (var item in jumpList.Items)
            {
                var session = items.FirstOrDefault(se => se.Code == item.Arguments);

                if (session != null)
                {
                    session.Favorites = true;
                }
            }

            this.sessionList.ItemsSource = items;
        }

        private async void addNewItem(TechnicalSession session)
        {
            JumpList jumpList = await JumpList.LoadCurrentAsync();
            JumpListItem item = JumpListItem.CreateWithArguments(session.Code, session.Title);
            item.Logo = new Uri("ms-appx:///Images/WpcLogo.png");
            jumpList.Items.Add(item);
            await jumpList.SaveAsync();
        }

        private async void removeItem(TechnicalSession session)
        {
            JumpList jumpList = await JumpList.LoadCurrentAsync();
            var item = jumpList.Items.FirstOrDefault(se => se.Arguments == session.Code);

            if (item != null)
            {
                jumpList.Items.Remove(item);
                await jumpList.SaveAsync();
            }
        }

        private async void ClearFavorites_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            JumpList jumpList = await JumpList.LoadCurrentAsync();
            jumpList.Items.Clear();
            await jumpList.SaveAsync();

            var list = this.sessionList.ItemsSource as List<TechnicalSession>;
            list.ForEach(i => i.Favorites = false);
        }
    }
}