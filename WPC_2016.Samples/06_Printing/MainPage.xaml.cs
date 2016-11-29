using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Printing;
using System;
using Windows.Graphics.Printing;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.Collections.Generic;
using WPC_2016.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WPC_2016.Samples.Sample06
{
    public sealed partial class MainPage : Page
    {
        private PrintManager printMan;
        private PrintDocument printDoc;
        private IPrintDocumentSource printDocSource;
        private List<UIElement> pages;

        public MainPage()
        {
            this.InitializeComponent();
            this.sessionList.ItemsSource = TechnicalSession.Load();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Chiedo all'OS se c'è possibilità di stampare
            this.InvokePrintingButton.IsEnabled = PrintManager.IsSupported();

            printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested += PrintTaskRequested;

            // Preparo l'oggetto PrintDocument
            printDoc = new PrintDocument();
            printDocSource = printDoc.DocumentSource;
            printDoc.Paginate += Paginate;
            printDoc.GetPreviewPage += GetPreviewPage;
            printDoc.AddPages += AddPages;
        }

        private async void InvokePrintingButton_Click(object sender, RoutedEventArgs e)
        {
            // Preparo le pagine da stampare
            pages = new List<UIElement>();
            // 1° pagina : Copertina
            pages.Add(new CoverPage());
            // 2° pagina : mando in output la ListView
            pages.Add(this.sessionList);

            await PrintManager.ShowPrintUIAsync();
        }

        private void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            var printTask = args.Request.CreatePrintTask("uwp_print", PrintTaskSourceRequested);
        }

        private void PrintTaskSourceRequested(PrintTaskSourceRequestedArgs args)
        {
            args.SetSource(printDocSource);
        }

        private void Paginate(object sender, PaginateEventArgs e)
        {
            printDoc.SetPreviewPageCount(this.pages.Count, PreviewPageCountType.Final);
        }

        // Richiede la preview di una specifica pagina
        private void GetPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            printDoc.SetPreviewPage(e.PageNumber, pages[e.PageNumber - 1]);
        }

        private void AddPages(object sender, AddPagesEventArgs e)
        {
            foreach(UIElement ui in this.pages)
            {
                printDoc.AddPage(ui);
            }

            // Indicate that all of the print pages have been provided
            printDoc.AddPagesComplete();
        }
    }
}