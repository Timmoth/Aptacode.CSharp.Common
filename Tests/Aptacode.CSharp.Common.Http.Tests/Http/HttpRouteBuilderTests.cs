using Aptacode.CSharp.Common.Http.Tests.Http.TestData;
using Xunit;

namespace Aptacode.CSharp.Common.Http.Tests.Http
{
    public class HttpRouteBuilderTests
    {
        [Theory]
        [ClassData(typeof(HttpRouteBuilderBuildRouteTestData))]
        public void BuildRouteTests(ServerAddress serverAddress, object[] baseComponents, object[] extraComponents,
            string expectedAddress)
        {
            var sut = new HttpRouteBuilder(serverAddress, baseComponents);
            Assert.Equal(expectedAddress, sut.BuildRoute(extraComponents));
        }

        [Theory]
        [ClassData(typeof(HttpRouteBuilderToStringTestData))]
        public void ToStringTests(ServerAddress serverAddress, object[] baseComponents, string expectedAddress)
        {
            var sut = new HttpRouteBuilder(serverAddress, baseComponents);
            Assert.Equal(expectedAddress, sut.ToString());
        }
    }
}