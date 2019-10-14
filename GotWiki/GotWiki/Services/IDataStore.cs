using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GotWiki.Services
{
    public interface IDataStore
    {
        Task<T> GetItemAsync<T>(string path);
        Task<IEnumerable<T>> GetItemsAsync<T>(string path, int page = 1, int pageSize = 10);
        Task<IEnumerable<T>> GetItemsAsync<T>(string path);
    }
}
