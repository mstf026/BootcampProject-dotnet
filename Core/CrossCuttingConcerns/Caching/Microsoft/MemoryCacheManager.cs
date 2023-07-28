using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern
        IMemoryCache _memoryCache;
        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (cacheEntriesCollectionDefinition != null)
            {

                // Populate the definition with your IMemoryCache instance.  
                // It needs to be cast as a dynamic, otherwise you can't
                // loop through it due to it being a collection of objects.
                var cacheEntriesCollection = cacheEntriesCollectionDefinition?.GetValue(_memoryCache) as dynamic;

                if (cacheEntriesCollection!=null)
                {
                    // Define a new list we'll be adding the cache entries too
                    List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

                    foreach (var cacheItem in cacheEntriesCollection)
                    {
                        // Get the "Value" from the key/value pair which contains the cache entry   
                        ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);

                        // Add the cache entry to the list
                        cacheCollectionValues.Add(cacheItemValue);
                    }


                    var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

                    foreach (var key in keysToRemove)
                    {
                        _memoryCache.Remove(key);
                    }
                }
            }
        }
    }
}
