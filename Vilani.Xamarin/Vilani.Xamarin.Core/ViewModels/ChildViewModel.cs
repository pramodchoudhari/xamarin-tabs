using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Vilani.Xamarin.Core.Comman;
using Vilani.Xamarin.Core.Model;

namespace Vilani.Xamarin.Core.ViewModels
{
    public class ChildViewModel : TabsBaseViewModel
    {
        public ChildViewModel(string name = "default")
        {
            Name = name;
            OrderInfo.Instance.eventHanlder.GetEvent<Notifications>().Subscribe(OnReceivedNotification);
        }
        public void OnReceivedNotification(NavigationArgs notificationArgs)
        {
            SelectedTable = notificationArgs.Data as TableVM;
            Name = SelectedTable.Name;
        }
        public ICommand GoToChildCommand => new MvxCommand(() =>
        {
            TabChangeds(new NavigationEventArgs());
        });
    }
}