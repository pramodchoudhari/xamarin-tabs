using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Vilani.Xamarin.Core.Model;

namespace Vilani.Xamarin.Core.Service
{
    public class MenuService : IMenuService
    {
        HttpClient CreateClient()
        {
            return new HttpClient();
        }
        public async Task<IList<MenuVM>> GetMenus()
        {
            try
            {
                var client = CreateClient();
                if (client.DefaultRequestHeaders.CacheControl == null)
                    client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();

                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders.IfModifiedSince = DateTime.UtcNow;
                client.DefaultRequestHeaders.CacheControl.NoStore = true;
                client.Timeout = new TimeSpan(0, 0, 30);
                var request = "http://192.168.43.185/api/api/menus/1";
                var response = await client.GetStringAsync(request);
                return await DeserializeObjectAsync<List<MenuVM>>(response);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public Task<T> DeserializeObjectAsync<T>(string value)
        {
            return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(value));
        }


    }
}
