using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using Vilani.Xamarin.Core.ViewModels;

using System.Collections.Generic;
using Vilani.Xamarin.Droid.Views.Fragments;
using Vilani.Xamarin.Droid.Common;

namespace Vilani.Xamarin.Droid.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainView : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        public TabHandler TabNavigationHandler { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.page_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            var tabLayout = FindViewById<TabLayout>(Resource.Id.main_tablayout);
            TabNavigationHandler = new TabHandler(tabLayout, ViewModel);

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.Title = "www.vilanimart.com";

            var viewPager = FindViewById<ViewPager>(Resource.Id.main_view_pager);
            var fragments = new List<MvxCachingFragmentStatePagerAdapter.FragmentInfo>();
            ViewModel.TabChanged += ViewModel_TabChanged;
            //foreach (var myViewModel in ViewModel.MyViewModels)
            
            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo(ViewModel.MyViewModels[0].Name, typeof(TableFragment), ViewModel.MyViewModels[0]));
            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo(ViewModel.MyViewModels[1].Name, typeof(MenuFragment), ViewModel.MyViewModels[1]));
            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo(ViewModel.MyViewModels[2].Name, typeof(ChildFragment), ViewModel.MyViewModels[2]));

            viewPager.Adapter = new MvxCachingFragmentStatePagerAdapter(this, SupportFragmentManager, fragments);

            //If you want to start at specific tab
            //viewPager.SetCurrentItem(ViewModel.CurrentPage, false);

            TabNavigationHandler.MainTabLayout.SetupWithViewPager(viewPager);
            
        }

        private void ViewModel_TabChanged(object sender, Vilani.Xamarin.Core.Comman.NavigationEventArgs navigationArgs)
        {
            TabNavigationHandler.HandleAction(sender, navigationArgs);
        }
    }
}