using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Vilani.Xamarin.Core.Comman;
using Vilani.Xamarin.Core.Model;
using System.Collections.ObjectModel;
using Vilani.Xamarin.Core.Service;
using System.Threading.Tasks;

namespace Vilani.Xamarin.Core.ViewModels
{
    public class MenuViewModel : TabsBaseViewModel
    {
        private ObservableCollection<MenuVM> menus;
        public ObservableCollection<MenuVM> Menus
        {
            get
            {
                return menus;
            }
            set
            {
                menus= value;
                RaisePropertyChanged(() => Menus);
                RaisePropertyChanged(() => MenuLength);
            }
        }

        private int menuLength;
        public int MenuLength
        {
            get
            {
                return Menus.Count;
            }
            
        }

        public MenuViewModel(string name = "default")
        {
            Name = name;
            OrderInfo.Instance.eventHanlder.GetEvent<Notifications>().Subscribe(OnReceivedNotification);
            Task.Run(() => LoadTables());
        }

        public async void LoadTables()
        {
            Menus = new ObservableCollection<MenuVM>(await new MenuService().GetMenus());
            //foreach (var table in MenuVM)
            //{
            //    table.onTableSelected += Table_onTableSelected;
            //}

        }
        public void OnReceivedNotification(NavigationArgs notificationArgs)
        {
            SelectedTable = notificationArgs.Data as TableVM;
            Name = SelectedTable.Name;
        }
        public ICommand GoToChildCommand => new MvxCommand(() =>
        {
            TabChangeds(new NavigationEventArgs() { Data = new NavigationArgs { Destination = Tabs.Tables } });
        });
    }
}