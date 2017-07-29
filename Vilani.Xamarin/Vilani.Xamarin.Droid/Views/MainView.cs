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

namespace Vilani.Xamarin.Droid.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainView : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.page_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.Title = "www.vilanimart.com";

            var viewPager = FindViewById<ViewPager>(Resource.Id.main_view_pager);
            var fragments = new List<MvxCachingFragmentStatePagerAdapter.FragmentInfo>();
            ViewModel.TabChanged += ViewModel_TabChanged;
            //foreach (var myViewModel in ViewModel.MyViewModels)
            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo(ViewModel.MyViewModels[0].Name, typeof(TableFragment), ViewModel.MyViewModels[0]));
            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo(ViewModel.MyViewModels[1].Name, typeof(ChildFragment), ViewModel.MyViewModels[1]));
            fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo(ViewModel.MyViewModels[2].Name, typeof(ChildFragment), ViewModel.MyViewModels[2]));

            viewPager.Adapter = new MvxCachingFragmentStatePagerAdapter(this, SupportFragmentManager, fragments);

            //If you want to start at specific tab
            //viewPager.SetCurrentItem(ViewModel.CurrentPage, false);

            var tabLayout = FindViewById<TabLayout>(Resource.Id.main_tablayout);
            tabLayout.SetupWithViewPager(viewPager);

        }

        private void ViewModel_TabChanged(object sender, Core.Comman.Tabs tab)
        {
            TabLayout tabLayout = FindViewById<TabLayout>(Resource.Id.main_tablayout);
            TabLayout.Tab tabContent = tabLayout.GetTabAt((int)tab);
            tabContent.Select();
        }

      
    }
}