using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VsPlay
{
    public class BaseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Base);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            var type = jsonObject["Type"]?.ToString();
            if (type == null)
            {
                return null;
            }

            Type targetType = TypeMapping.GetType(type);
            var obj = Activator.CreateInstance(targetType)!;
            serializer.Populate(jsonObject.CreateReader(), obj);

            return obj;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}

