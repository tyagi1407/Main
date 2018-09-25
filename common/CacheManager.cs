using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;


namespace Common
{
    public static class CacheManager
    {
        public static ICacheManager objCacheManager = CacheFactory.GetCacheManager();

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="o">Item to be cached</param>
        /// <param name="key">Name of item</param>
        public static void Add<T>(string key,T o )
        {
            //Adding  cache expiration policy 
            int cacheExpireTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["CacheExpireTimeOut"]);
            AbsoluteTime absolute = new AbsoluteTime(TimeSpan.FromMinutes(cacheExpireTimeOut));

            objCacheManager.Add(key, o, CacheItemPriority.Normal, null, absolute);
        }


        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="o">Item to be cached</param>
        /// <param name="key">Name of item</param>
        public static void Add<T>(string key, T o, double cacheExpireTimeOutinMinutes)
        {
            AbsoluteTime absolute = new AbsoluteTime(TimeSpan.FromMinutes(cacheExpireTimeOutinMinutes));

            objCacheManager.Add(key, o, CacheItemPriority.Normal, null, absolute);
        }


        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public static void Clear(string key)
        {
            objCacheManager.Remove(key);
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return objCacheManager[key] != null;
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <param name="value">Cached value. Default(T) if 
        /// item doesn't exist.</param>
        /// <returns>Cached item as type</returns>
        public static bool Get<T>(string key, out T value)
        {

            try
            {
                if (!Exists(key))
                {
                    value = default(T);
                    return false;
                }

                value = (T)objCacheManager[key];
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }
    }
}
