using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WPC_2016.Samples.Sample13
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DatabaseContext ctx;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.path.Text = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            loadRecords();
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            ctx.Speakers.Add(new Speaker() { Name = "Gabriele", Surname = "Gaggi", Province = "Sondrio", Technologies = "ASP.NET", BirthDate = new DateTime(1972, 07, 31) });
            ctx.Speakers.Add(new Speaker() { Name = "Liborio Igor", Surname = "Damiani", Province = "Lodi", Technologies = "UWP", BirthDate = new DateTime(1976, 02, 28) });
            ctx.Speakers.Add(new Speaker() { Name = "Del Sole", Surname = "Alessandro", Province = "Roma", Technologies = "WPF", BirthDate = new DateTime(1977, 05, 10) });

            await ctx.SaveChangesAsync();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            try
            {
                ctx = new DatabaseContext();
                this.speakersList.ItemsSource = ctx.Speakers;
            }
            catch (Exception) { }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var modified = ctx.ChangeTracker.Entries<Speaker>();
            int records = await ctx.SaveChangesAsync();
        }
    }
}