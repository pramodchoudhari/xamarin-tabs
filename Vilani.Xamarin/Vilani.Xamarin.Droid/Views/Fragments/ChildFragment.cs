using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using Vilani.Xamarin.Core.ViewModels;

namespace Vilani.Xamarin.Droid.Views.Fragments
{
    [Register("sampletabs.droid.views.fragments.ChildFragment")]
    public class ChildFragment : MvxFragment<TabsBaseViewModel>
    {
        public ChildFragment()
        {
            this.RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_child, null);
        }
    }
}