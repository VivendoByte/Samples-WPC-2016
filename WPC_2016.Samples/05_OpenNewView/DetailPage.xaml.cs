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
using WPC_2016.ObjectModel;

namespace WPC_2016.Samples.Sample05
{
    public sealed partial class DetailPage : Page
    {
        public TechnicalSession Session { get; private set; }

        public DetailPage(TechnicalSession session)
        {
            this.Session = session;
            this.InitializeComponent();
            this.Title.Text = this.Session.Title;
        }
    }
}