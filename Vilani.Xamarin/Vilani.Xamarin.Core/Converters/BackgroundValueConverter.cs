//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;

//using MvvmCross.Platform.Converters;
//using Android.Graphics.Drawables;
//using Android.Graphics;
//using MvvmCross.Plugins.Color;
//using MvvmCross.Platform.UI;

//namespace Vilani.Xamarin.Core.Converters
//{
//    public class TextColorValueConverter : MvxColorValueConverter
//    {
//        private static readonly MvxColor ErrorTextColor = new MvxColor(0xFF, 0x00, 0x00);
//        private static readonly MvxColor StandardTextColor = new MvxColor(0x0, 0x0, 0x0);

//        protected override MvxColor Convert(object value, object parameter, System.Globalization.CultureInfo culture)
//        {
//            return (bool)value ? ErrorTextColor : StandardTextColor;
//        }
//    }

//    public class StringLengthValueConverter : MvxValueConverter<string>
//    {
//        protected override object Convert(string value, Type targetType, object parameter, CultureInfo culture)
//        {
//            value = value ?? string.Empty;
//            return value.Length;
//        }
//    }
//    public class BackgroundColorValueConverter : MvxValueConverter<bool>
//    {
//        protected override object Convert(bool value, Type targetType, object parameter, CultureInfo culture)
//        {
//            return value ? new ColorDrawable(new Color(255, 255, 255)) : new ColorDrawable(new Color(255, 0, 0));
//        }
//    }

//    public class BackgroundValueConverter : MvxValueConverter<bool, ColorDrawable>
//    {
//        protected override ColorDrawable Convert(bool value, System.Type targetType, object parameter, CultureInfo culture)
//        {
//            return value ? new ColorDrawable(new Color(0, 0, 255)) : new ColorDrawable(new Color(255, 0, 0));
//        }
//    }

//    //public class AssetsPathConverter : IMvxValueConverter
//    //{
//    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//    //    {
//    //        return value.ToString().Replace("../Assets/", string.Empty);
//    //    }

//    //    #region Implementation of IMvxValueConverter

//    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//    //    {
//    //        return value;
//    //    }

//    //    #endregion
//    //}
//}