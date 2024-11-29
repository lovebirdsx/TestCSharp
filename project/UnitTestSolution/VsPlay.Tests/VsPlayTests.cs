using Xunit;
using Newtonsoft.Json;

namespace VsPlay.Tests
{
    public class VsPlayTests
    {
        [Fact]
        public void TestTypeMapping()
        {
            var typeA = TypeMapping.GetType(nameof(SampleEntity));
            Assert.Equal(typeof(SampleEntity), typeA);

            var typeB = TypeMapping.GetType(nameof(SampleQuest));
            Assert.Equal(typeof(SampleQuest), typeB);

            var typeUnknown = TypeMapping.GetType("Unknown");
            Assert.Equal(typeof(Base), typeUnknown);
        }

        [Fact]
        public void TestNormalParser()
        {
            var json = "{\"Type\":0,\"AValue\":10}";
            var obj = JsonConvert.DeserializeObject<SampleEntity>(json);
            Assert.IsType<SampleEntity>(obj);
            Assert.Equal(10, obj.AValue);
        }

        [Fact]
        public void TestBaseConverterDeserialization()
        {
            var json = "{\"Type\":\"SampleEntity\",\"AValue\":10}";
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new BaseConverter());

            var obj = JsonConvert.DeserializeObject<Base>(json, settings);
            Assert.IsType<SampleEntity>(obj);
            Assert.Equal(10, ((SampleEntity)obj).AValue);

            json = "{\"Type\":\"SampleQuest\",\"BValue\":\"B\"}";
            obj = JsonConvert.DeserializeObject<Base>(json, settings);
            Assert.IsType<SampleQuest>(obj);
            Assert.Equal("B", ((SampleQuest)obj).BValue);
        }

        [Fact]
        public void TestPartialDeserialization()
        {
            var json = "{\"Type\":\"SampleEntity\"}";
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new BaseConverter());

            var obj = JsonConvert.DeserializeObject<Base>(json, settings);
            Assert.IsType<SampleEntity>(obj);
            Assert.Equal(1, ((SampleEntity)obj).AValue);
        }

        [Fact]
        public void TestNullableDeserialization()
        {
            var json = "{\"Type\":\"SampleEntity\",\"NullableValue\":null}";
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new BaseConverter());

            var obj = JsonConvert.DeserializeObject<Base>(json, settings);
            Assert.IsType<SampleEntity>(obj);
            Assert.Null(((SampleEntity)obj).NullableValue);

            json = "{\"Type\":\"SampleEntity\",\"NullableValue\":10}";
            obj = JsonConvert.DeserializeObject<Base>(json, settings);
            Assert.IsType<SampleEntity>(obj);
            Assert.Equal(10, ((SampleEntity)obj).NullableValue);
        }
    }
}
