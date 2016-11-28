using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WPC_2016.Samples.Sample04
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StorageLibrary musicLibrary;
        StorageLibrary picturesLibrary;
        StorageLibrary videoLibrary;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            loadFolders();
        }

        private async void loadFolders()
        {
            musicLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Music);
            this.musicLibraryFolders.ItemsSource = musicLibrary.Folders;

            picturesLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Pictures);
            this.picturesLibraryFolders.ItemsSource = picturesLibrary.Folders;

            videoLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
            this.videoLibraryFolders.ItemsSource = videoLibrary.Folders;
        }

        private async void RemoveMusicFolder_Click(object sender, RoutedEventArgs e)
        {
            Control ctl = sender as Control;
            StorageFolder folder = ctl.DataContext as StorageFolder;
            await this.musicLibrary.RequestRemoveFolderAsync(folder);
            loadFolders();
        }

        private async void RemovePictureFolder_Click(object sender, RoutedEventArgs e)
        {
            Control ctl = sender as Control;
            StorageFolder folder = ctl.DataContext as StorageFolder;
            await this.picturesLibrary.RequestRemoveFolderAsync(folder);
            loadFolders();
        }

        private async void RemoveVideoFolder_Click(object sender, RoutedEventArgs e)
        {
            Control ctl = sender as Control;
            StorageFolder folder = ctl.DataContext as StorageFolder;
            await this.videoLibrary.RequestRemoveFolderAsync(folder);
            loadFolders();
        }

        private async void AddMusicFolder_Click(object sender, RoutedEventArgs e)
        {
            await this.musicLibrary.RequestAddFolderAsync();
        }

        private async void AddPictureFolder_Click(object sender, RoutedEventArgs e)
        {
            await this.picturesLibrary.RequestAddFolderAsync();
        }

        private async void AddVideoFolder_Click(object sender, RoutedEventArgs e)
        {
            await this.videoLibrary.RequestAddFolderAsync();
        }
    }
}