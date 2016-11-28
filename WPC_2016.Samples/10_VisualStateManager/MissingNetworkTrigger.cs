using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace WPC_2016.Samples.Sample10
{
    class MissingNetworkTrigger : StateTriggerBase
    {
        private bool connected;
        public bool Connected
        {
            get { return this.connected; }
            set
            {
                this.connected = value;

                if (NetworkInformation.GetInternetConnectionProfile() != null)
                {
                    SetActive(value);
                }
                else
                {
                    SetActive(!value);
                }
            }
        }


        public MissingNetworkTrigger()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
            this.NetworkInformation_NetworkStatusChanged(this);
        }

        private async void NetworkInformation_NetworkStatusChanged(object sender)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (NetworkInformation.GetInternetConnectionProfile() != null)
                {
                    SetActive(this.Connected);
                }
                else
                {
                    SetActive(!this.Connected);
                }
            });

        }

        private bool IsInternet()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            bool internet = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
            return internet;
        }
    }
}