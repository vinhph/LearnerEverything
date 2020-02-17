using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectedLearning
{
    public class RemoteCacheSynchronization : ISynchronizedObjectInstanceCache
    {
        private readonly IObjectInstanceCache _localCache;

        public RemoteCacheSynchronization(IObjectInstanceCache localCache)
        {
            this._localCache = localCache;
        }
        public void RemoveLocal(string key)
        {
            this._localCache.Remove(key);
        }
        public void Insert(string key, object value)
        {
            this._localCache.Insert(key, value);
        }

        public void Remove(string key)
        {
            this.RemoveLocal(key);
            this.RemoveRemote(key);
        }

        public void RemoveRemote(string key)
        {
            //this._eventService.Get(RemoteCacheSynchronization.RemoveFromCacheEventId).RaiseAsync(RemoteCacheSynchronization.LocalCacheManagerRaiserId, (object)key, EventRaiseOption.RaiseBroadcast);
        }
    }
}
