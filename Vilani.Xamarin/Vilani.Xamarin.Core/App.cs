using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using Vilani.Xamarin.Core.ViewModels;

namespace Vilani.Xamarin.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            this.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            this.RegisterAppStart<MainViewModel>();
        }
    }
}