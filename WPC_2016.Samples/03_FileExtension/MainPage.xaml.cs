using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WPC_2016.Samples.Sample03
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IReadOnlyList<IStorageItem> files;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (string.IsNullOrEmpty(e.Parameter.ToString())) return;

            files = e.Parameter as IReadOnlyList<IStorageItem>;

            if (files.Any())
            {
                var file = files.FirstOrDefault() as StorageFile;
                this.showFileDetails(file);
            }
        }

        private void Border_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;

            if (e.DragUIOverride != null)
            {
                e.DragUIOverride.Caption = "apri file";
                e.DragUIOverride.IsContentVisible = true;
            }
        }

        private async void Border_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();

                if (items.Count > 0)
                {
                    StorageFile file = items.FirstOrDefault() as StorageFile;
                    this.showFileDetails(file);
                }
            }
        }

        private async void showFileDetails(StorageFile file)
        {
            this.filename.Text = file.Name;
            this.fullPath.Text = file.Path;
            this.dateCreated.Text = file.DateCreated.ToString();

            var props = await file.GetBasicPropertiesAsync();
            ulong sizeBytes = props.Size;
            this.size.Text = sizeBytes.ToString() + " bytes";

            if (sizeBytes > 0)
            {
                var content = await FileIO.ReadTextAsync(file);
                this.content.Text = content;
            }
        }
    }
}