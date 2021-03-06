﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using Vilani.Xamarin.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;

namespace Vilani.Xamarin.Droid.Views.Fragments
{
    public class TableFragment : MvxFragment<TablesViewModel>
    {
        public TableFragment()
        {
            this.RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_table, null);
        }
    }
}