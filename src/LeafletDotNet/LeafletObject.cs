using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public abstract class LeafletObject : IAsyncDisposable
    {
        private static ConcurrentDictionary<Guid, WeakReference<LeafletObject>> _objects = new();

        public static LeafletObject GetOrNull(Guid id)
        {
            if (_objects.TryGetValue(id, out var value) && value.TryGetTarget(out var target))
            {
                return target;
            }

            return null;
        }

        protected LeafletObject()
        {
            Id = Guid.NewGuid();
            _objects.TryAdd(Id, new WeakReference<LeafletObject>(this));
        }

        ~LeafletObject()
        {
            _ = DisposeAsync(false);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (disposing)
            {
            }
            _objects.TryRemove(Id, out _);
            await Leaflet.Dispose(this);
        }

        internal Guid Id { get; }
        internal Leaflet Leaflet { get; set; }
    }
}
