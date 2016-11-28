using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace WPC_2016.Samples.Sample11
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var view = Windows.UI.ViewManagement.UIViewSettings.GetForCurrentView();
            var ui = view.UserInteractionMode;

            if (ui == Windows.UI.ViewManagement.UserInteractionMode.Touch)
            {
                this.currentUI.Text = "Tablet Mode!";
                VisualStateManager.GoToState(this, "tablet", true);
            }
            else
            {
                this.currentUI.Text = string.Empty;
                VisualStateManager.GoToState(this, "standard", true);
            }
        }
    }
}