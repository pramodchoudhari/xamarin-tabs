using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilani.Xamarin.Core.Comman;
using Vilani.Xamarin.Core.Model;

namespace Vilani.Xamarin.Core.ViewModels
{
    public class TabsBaseViewModel : MvxViewModel
    {
        private TableVM _selectedTable;
        public TableVM SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                _selectedTable = value;
                RaisePropertyChanged(() => SelectedTable);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public delegate void NavigateToTab(object sender, NavigationEventArgs tab);
        public event NavigateToTab TabChanged;

        internal void TabChangeds(NavigationEventArgs tab)
        {
            TabChanged(this, tab);
        }

        public void PublishTabSelected(TableVM table)
        {
            var navObject = new NavigationArgs { Sender = Tabs.Tables, Destination = Tabs.Menu, Data = table };
            OrderInfo.Instance.eventHanlder.GetEvent<Notifications>().Publish(navObject);
            TabChangeds(new NavigationEventArgs(this, navObject));
        }
    }
}
