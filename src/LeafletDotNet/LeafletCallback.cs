using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeafletDotNet
{
    public abstract class LeafletCallback : LeafletObject
    {
        internal abstract void Invoke(JsonElement element);
    }

    public class LeafletCallback<T> : LeafletCallback
        where T: LeafletEvent
    {
        private readonly Action<T> _action;

        public LeafletCallback(Action<T> action)
        {
            _action = action;
        }

        internal override void Invoke(JsonElement @event)
        {
            var e = JsonSerializer.Deserialize<T>(@event.ToString(), _options);
            _action.Invoke(e);
        }

        private static JsonSerializerOptions _options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            Converters = { new LeafletClassConverter() }
        };

        private class LeafletClassConverter : JsonConverter<LeafletClass>
        {
            public override LeafletClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (Guid.TryParse(reader.GetString(), out var id))
                {
                    return GetOrNull(id) as LeafletClass;
                }
                return null;
            }
            public override void Write(Utf8JsonWriter writer, LeafletClass value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
