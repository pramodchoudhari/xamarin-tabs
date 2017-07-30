using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using Vilani.Xamarin.Core.ViewModels;

namespace Vilani.Xamarin.Droid.Views.Fragments
{

    [Register("sampletabs.droid.views.fragments.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>
    {
        public MenuFragment()
        {
            this.RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_menu, null);
        }
    }

}