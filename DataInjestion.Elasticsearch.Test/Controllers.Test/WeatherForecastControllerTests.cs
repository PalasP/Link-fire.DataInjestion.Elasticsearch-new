using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataInjestion.Elasticsearch.Test.Controllers.Test
{
    public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        HttpClient _client { get; }

        public WeatherForecastControllerTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Should_Retrieve_Forecast()
        {
            var response = await _client.GetAsync("/weatherforecast");
            //response.StatusCode.Should().Be(HttpStatusCode.OK);

            var forecast = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());
            //forecast.Should().HaveCount(5);
        }
    }
}
