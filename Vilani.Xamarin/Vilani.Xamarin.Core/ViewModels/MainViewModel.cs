using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using Vilani.Xamarin.Core.Comman;

namespace Vilani.Xamarin.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public delegate void ChangeTab(object sender, NavigationEventArgs tab);
        public event ChangeTab TabChanged;

        private List<TabsBaseViewModel> _myViewModels;
        public List<TabsBaseViewModel> MyViewModels
        {
            get { return _myViewModels; }
            set
            {
                _myViewModels = value;
                RaisePropertyChanged(() => MyViewModels);
            }
        }
      
        public SharedDataViewModel SharedData { get; set; }
        public MainViewModel()
        {
            InitTabsViewModel();
            SharedData = new SharedDataViewModel();
        
        }

        private void InitTabsViewModel()
        {
            MyViewModels = new List<TabsBaseViewModel>()
            {
                new TablesViewModel("Tables"),
                new MenuViewModel("Menu"),
                new ChildViewModel("Orders")
            };
            MyViewModels[0].TabChanged += MainViewModel_TabChanged;
            MyViewModels[1].TabChanged += MainViewModel_TabChanged;
            MyViewModels[2].TabChanged += MainViewModel_TabChanged;
        }

        private void MainViewModel_TabChanged(object sender, NavigationEventArgs tabData)
        {
            TabChanged(this, tabData);
           
        }


    }
}