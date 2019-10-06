using GotWiki;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GotWiki.Services
{
    class DataStore : IDataStore
    {
        HttpClient client;

        public DataStore(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<T>> GetItemsAsync<T>(string path)
        {
            if (IsConnected)
            {
                var json = await client.GetStringAsync(path);
                return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<T>>(json));
            }
            return default;
        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>(string path, int page = 1, int pageSize = 10)
        {
            if (IsConnected)
            {
                var json = await client.GetStringAsync($"{path}?{nameof(page)}={page}&{nameof(pageSize)}={pageSize}");
                return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<T>>(json));
            }
            return default;
        }

        public async Task<T> GetItemAsync<T>(string path)
        {
            if (path != null && IsConnected)
            {
                var json = await client.GetStringAsync($"{path}");
                return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
            }
            return default(T);
        }

    }
}
