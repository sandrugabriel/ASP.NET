using System.Net;
using System.Text;
using MasiniApi.Dto;
using Newtonsoft.Json;
using Test.Car.Infrastucture;

namespace Test.Car.IntegrationTests
{
    public class CarIntegrationTest : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;

        public CarIntegrationTest(ApiWebApplicationFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Post_Create_ValidData_CreatedStatusCode()
        {
            var request = "/api/v1/car/createcar";
            var car = new CreateCarRequest(){Marca = "test",AnulFacricatiei = 2000,Culoare = "test",Model = "test1"};

            var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(request, content);
            
            Assert.Equal(HttpStatusCode.Created,response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MasiniApi.Cars.Models.Car>(responseString);
            
            Assert.NotNull(result);
            Assert.Equal(car.Culoare,result.Culoare);
            Assert.Equal(car.AnulFacricatiei,result.Year);
            Assert.Equal(car.Marca,result.Marca);

        }

        [Fact]
        public async Task Post_Create_InvalidYear_AcceptedCode()
        {
            
        }

    }
}
