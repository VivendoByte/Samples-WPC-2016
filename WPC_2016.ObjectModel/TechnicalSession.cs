using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC_2016.ObjectModel
{
    public class TechnicalSession : ObservableObject
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Speaker { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }

        private bool favorites;
        public bool Favorites
        {
            get { return favorites; }
            set { favorites = value;
                base.RaisePropertyChanged(nameof(Favorites));
            }
        }

        public static List<TechnicalSession> Load()
        {
            List<TechnicalSession> sessions = new List<TechnicalSession>();

            #region 29 novembre
            sessions.Add(new TechnicalSession()
            {
                Code = "WPC008",
                Title = "WPC008 - Progettare una UI per Microservices",
                Speaker = "Mauro Servienti",
                StartTime = new DateTime(2016, 11, 29, 15, 45, 00)
            });

            sessions.Add(new TechnicalSession()
            {
                Code = "WPC016",
                Title = "WPC016 - Dall'idea alla pubblicazione con TFS2015 / VSTS",
                Speaker = "Gian Maria Ricci",
                StartTime = new DateTime(2016, 11, 29, 19, 00, 00)
            });
            #endregion

            #region 30 novembre
            sessions.Add(new TechnicalSession()
            {
                Code = "WPC027",
                Title = "WPC027 - Universal Windows Platform sul desktop: sfruttiamolo al massimo",
                Speaker = "Igor Damiani",
                StartTime = new DateTime(2016, 11, 30, 12, 15, 00)
            });

            sessions.Add(new TechnicalSession()
            {
                Code = "WPC038",
                Title = "WPC038 - Migrare una soluzione ASP.NET 4 verso ASP.NET Core",
                Speaker = "Andrea Saltarello",
                StartTime = new DateTime(2016, 11, 30, 15, 15, 00)
            });

            sessions.Add(new TechnicalSession()
            {
                Code = "WPC041",
                Title = "WPC041 - Creare contenuti olografici con Unity3D",
                Speaker = "Clemente Giorio ",
                StartTime = new DateTime(2016, 11, 30, 17, 00, 00)
            });
            #endregion

            #region 01 dicembre
            sessions.Add(new TechnicalSession()
            {
                Code = "WPC057",
                Title = "WPC057 - Introduzione a PowerApps e Microsoft Flow",
                Speaker = "Fabio Franzini",
                StartTime = new DateTime(2016, 12, 01, 10, 45, 00)
            });

            sessions.Add(new TechnicalSession()
            {
                Code = "WPC073",
                Title = "WPC073 - .NET Core e Visual Studio 2017 in azione: codice, codice, codice",
                Speaker = "Raffaele Rialdi",
                StartTime = new DateTime(2016, 12, 01, 16, 00, 00)
            });
            #endregion

            return sessions;
        }
     }
}