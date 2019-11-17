using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsHack.Api.FireBase
{
    public class FireBaseUtility
    {
        private readonly FirebaseClient _client;

        public FireBaseUtility(string url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));
            _client = new FirebaseClient(url);
        }

        public async Task AddAsync<T>(string resourceName, T t)
        {
            await _client.Child(resourceName).PostAsync(t);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string resourceName)
        {
            return (await _client.Child(resourceName).OnceAsync<T>()).Select(i => i.Object);
        }

    }
}