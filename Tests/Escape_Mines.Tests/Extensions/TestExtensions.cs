using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Escape_Mines.Tests.Extensions
{
    public static class TestExtensions
    {
        public static T ShouldEqual<T>(this T actual, object expected)
        {
            Assert.AreEqual(expected, actual);
            return actual;
        }

        public static T ShouldBeEqualObj<T>(this T actual, object expected)
        {
            Assert.AreEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(expected));
            return actual;
        }
        public static T ShouldNotBeEqualObj<T>(this T actual, object expected)
        {
            Assert.AreNotEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(expected));
            return actual;
        }
        public static T ShouldNotEqual<T>(this T actual, object expected)
        {
            Assert.AreNotEqual(expected, actual);
            return actual;
        }
    }
}
