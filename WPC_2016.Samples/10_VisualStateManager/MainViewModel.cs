using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC_2016.Samples.Sample10
{
    class MainViewModel : DomainObject
    {
        private ObservableCollection<ControlPanelItem> items;
        public ObservableCollection<ControlPanelItem> Items
        {
            get { return items; }
            set { items = value; }
        }

        public MainViewModel()
        {
            this.Items = new ObservableCollection<ControlPanelItem>();
            this.Items.Add(new ControlPanelItem("e2cb") { Name = "Sistema", Description = "Schermo, notifiche, app, alimentazione" });
            this.Items.Add(new ControlPanelItem("e090") { Name = "Dispositivi", Description = "Bluetooth, stampanti, mouse" });
            this.Items.Add(new ControlPanelItem("e12b") { Name = "Rete e Internet", Description = "Wi-Fi, modalità aereo, VPN" });
            this.Items.Add(new ControlPanelItem("e088") { Name = "Personalizzazione", Description = "Sfondo, schermata di blocco, colori" });
            this.Items.Add(new ControlPanelItem("e2af") { Name = "Account", Description = "Il tuo account, impostazioni di sincronizzazione" });
            this.Items.Add(new ControlPanelItem("e164") { Name = "Data/ora e lingua", Description = "Riconoscimento vocale, area geografica, data" });
            this.Items.Add(new ControlPanelItem("e07f") { Name = "Accessibilità", Description = "Assistente vocale, Lente d'ingrandimento, contrasto elevato" });
            this.Items.Add(new ControlPanelItem("e131") { Name = "Privacy", Description = "Posizione, fotocamera" });
            this.Items.Add(new ControlPanelItem("27f2") { Name = "Aggiornamento e sicurezza", Description = "Windows Update, ripristino, backup" });
        }
    }
}