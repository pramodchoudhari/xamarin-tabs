using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilani.Xamarin.Core.Comman;

namespace Vilani.Xamarin.Core.ViewModels
{
    public class TabsBaseViewModel : MvxViewModel
    {
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
    }
}
