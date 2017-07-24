using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using Vilani.Xamarin.Core.Comman;

namespace Vilani.Xamarin.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public delegate void ChangeTab(Tabs tab);
        public event ChangeTab TabChanged;

        public MainViewModel()
        {
            MyViewModels = new List<TabsBaseViewModel>()
                {
                new TablesViewModel("Tables"),
                new ChildViewModel("Menu"),
                new ChildViewModel("Orders")
            };
            MyViewModels[0].TabChanged += MainViewModel_TabChanged;
            MyViewModels[1].TabChanged += MainViewModel_TabChanged;
            MyViewModels[2].TabChanged += MainViewModel_TabChanged;
        }

        private void MainViewModel_TabChanged(Comman.Tabs tab)
        {
            TabChanged(tab);
        }

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
    }
}