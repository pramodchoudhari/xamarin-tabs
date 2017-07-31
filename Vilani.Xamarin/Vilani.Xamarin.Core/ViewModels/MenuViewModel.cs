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
                menus = value;
                RaisePropertyChanged(() => Menus);
                
            }
        }

        private ObservableCollection<MenuVM> selectedMenu;
        public ObservableCollection<MenuVM> SelectedMenu
        {
            get
            {
                return selectedMenu;
            }
            set
            {
                selectedMenu = value;
                RaisePropertyChanged(() => SelectedMenu);
                RaisePropertyChanged(() => MenuLength);
            }
        }

        
        public int MenuLength
        {
            get
            {
                return SelectedMenu.Count;
            }

        }

        public MenuViewModel(string name = "default")
        {
            Name = name;
            OrderInfo.Instance.eventHanlder.GetEvent<Notifications>().Subscribe(OnReceivedNotification);
            SelectedMenu = new ObservableCollection<MenuVM>();
            Task.Run(() => LoadTables());
        }

        public async void LoadTables()
        {
            Menus = new ObservableCollection<MenuVM>(await new MenuService().GetMenus());
            foreach (var menu in Menus)
            {
                menu.onMenuAdded += Menu_onMenuAdded;
                menu.onMenuRemoved += Menu_onMenuRemoved;
            }

        }

        private void Menu_onMenuRemoved(object sender, MenuVM menu)
        {
            SelectedMenu.Remove(menu);
            RaisePropertyChanged(() => MenuLength);
        }

        private void Menu_onMenuAdded(object sender, MenuVM menu)
        {
            SelectedMenu.Add(menu);
            RaisePropertyChanged(() => MenuLength);
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