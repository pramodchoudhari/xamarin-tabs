using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilani.Xamarin.Core.Model;

namespace Vilani.Xamarin.Core.Service
{
    public interface IMenuService
    {
        Task<IList<MenuVM>> GetMenus();
    }
}
