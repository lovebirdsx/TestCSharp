using Xunit;
using Newtonsoft.Json;

namespace VsPlay.Tests
{
    public class VsPlayTests
    {
        [Fact]
        public void TestAClassInitialization()
        {
            var a = new A();
            Assert.Equal("A", a.Type);
            Assert.Equal(0, a.AValue);
        }

        [Fact]
        public void TestBClassInitialization()
        {
            var b = new B();
            Assert.Equal("B", b.Type);
            Assert.Equal("B", b.BValue);
        }

        [Fact]
        public void TestTypeMapping()
        {
            var typeA = TypeMapping.GetType("A");
            Assert.Equal(typeof(A), typeA);

            var typeB = TypeMapping.GetType("B");
            Assert.Equal(typeof(B), typeB);

            var typeUnknown = TypeMapping.GetType("Unknown");
            Assert.Equal(typeof(Base), typeUnknown);
        }

        [Fact]
        public void TestBaseConverterSerialization()
        {
            var a = new A();
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new BaseConverter());
            var json = JsonConvert.SerializeObject(a, settings);
            Assert.Contains("\"Type\":\"A\"", json);
        }

        [Fact]
        public void TestNormalParser()
        {
            var json = "{\"Type\":\"A\",\"AValue\":10}";
            var obj = JsonConvert.DeserializeObject<A>(json);
            Assert.IsType<A>(obj);
            Assert.Equal("A", obj.Type);
            Assert.Equal(10, ((A)obj).AValue);
        }

        [Fact]
        public void TestBaseConverterDeserialization()
        {
            var json = "{\"Type\":\"A\",\"AValue\":10}";
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new BaseConverter());

            var obj = JsonConvert.DeserializeObject<Base>(json, settings);
            Assert.IsType<A>(obj);
            Assert.Equal("A", obj.Type);
            Assert.Equal(10, ((A)obj).AValue);

            json = "{\"Type\":\"B\",\"BValue\":\"B\"}";
            obj = JsonConvert.DeserializeObject<Base>(json, settings);
            Assert.IsType<B>(obj);
            Assert.Equal("B", obj.Type);
            Assert.Equal("B", ((B)obj).BValue);
        }
    }
}
