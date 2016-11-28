using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC_2016.Samples.Sample10
{
    class ControlPanelItem : DomainObject
    {
        private string icon;
        public string Icon
        {
            get { return icon; }
            set { icon = value; this.RaisePropertyChanged("Icon"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; this.RaisePropertyChanged("Name"); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; this.RaisePropertyChanged("Description"); }
        }

        public ControlPanelItem(string icon)
        {
            int value = System.Int32.Parse(icon, System.Globalization.NumberStyles.HexNumber);
            this.Icon = System.Convert.ToChar(value).ToString();
        }
    }
}