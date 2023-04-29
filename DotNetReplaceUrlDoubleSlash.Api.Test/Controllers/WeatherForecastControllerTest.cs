using System.Net;
using System.Net.Http.Json;
using DotNetReplaceUrlDoubleSlash.Api.Test.Shared;
using NUnit.Framework;

namespace DotNetReplaceUrlDoubleSlash.Api.Test.Controllers
{
    internal class WeatherForecastControllerTest : IntegrationTestBase
    {
        private const string Url = "http://localhost/WeatherForecast/GetWeatherForecast";
        private const string UrlWithSlash = "http://localhost//WeatherForecast/GetWeatherForecast";
        private const string UrlWithSlashMultiple = "http://localhost//WeatherForecast//GetWeatherForecast";

        [Test]
        public async Task Get_正常系()
        {
            // Arrange・Act
            var response = await client.GetAsync(Url);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
            Assert.IsTrue(result?.Any());
        }

        [Test]
        public async Task Get_正常系_URLにスラッシュ有り()
        {
            // Arrange・Act
            var response = await client.GetAsync(UrlWithSlash);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
            Assert.IsTrue(result?.Any());
        }

        [Test]
        public async Task Get_正常系_URLにスラッシュ有り_複数個所()
        {
            // Arrange・Act
            var response = await client.GetAsync(UrlWithSlashMultiple);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
            Assert.IsTrue(result?.Any());
        }
    }
}
