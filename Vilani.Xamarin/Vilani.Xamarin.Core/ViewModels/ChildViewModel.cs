using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Vilani.Xamarin.Core.Comman;

namespace Vilani.Xamarin.Core.ViewModels
{
    public class ChildViewModel : TabsBaseViewModel
    {
        public ChildViewModel(string name = "default")
        {
            Name = name;

        }

        public ICommand GoToChildCommand => new MvxCommand(() =>
        {
            TabChangeds(Tabs.Orders);
        });
    }
}