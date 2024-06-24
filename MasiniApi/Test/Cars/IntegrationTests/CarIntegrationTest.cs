using System.Net;
using System.Text;
using MasiniApi.Cars.Dto;
using MasiniApi.Cars.Models;
using Newtonsoft.Json;
using Test.Cars.Helpers;
using Test.Cars.Infrastucture;

namespace Test.Cars.IntegrationTests
{
    public class CarIntegrationTest : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public CarIntegrationTest(ApiWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllCars_CarsFound_ReturnsOkStatusCode_ValidResponse()
        {
            var createCarRequest = TestCarFactory.CreateCar(1);
            var content = new StringContent(JsonConvert.SerializeObject(createCarRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/v1/Car/createCar", content);

            var response = await _client.GetAsync("/api/v1/Car/all");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetCarById_CarFound_ReturnsOkStatusCode()
        {
            var createCarRequest = new CreateCarRequest
            { Brand = "asd", Model = "ASasdadd", Color = "asd", Year = 2000 };
            var content = new StringContent(JsonConvert.SerializeObject(createCarRequest), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/v1/Car/createCar", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Car>(responseString);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(result.Brand, createCarRequest.Brand);
        }

        [Fact]
        public async Task GetCarById_CarNotFound_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/v1/Car/findById?id=9999");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Post_Create_ValidRequest_ReturnsCreatedStatusCode()
        {
            var request = "/api/v1/Car/createCar";
            var Car = new CreateCarRequest { Brand = "asd", Model = "ASasdadd", Color = "asd", Year = 2000 };
            var content = new StringContent(JsonConvert.SerializeObject(Car), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Car>(responseString);

            Assert.NotNull(result);
            Assert.Equal(Car.Brand, result.Brand);
        }

        [Fact]
        public async Task Put_Update_ValidRequest_ReturnsAcceptedStatusCode()
        {
            var request = "/api/v1/Car/createCar";
            var createCar = new CreateCarRequest { Brand = "asd", Model = "ASasdadd", Color = "asd", Year = 2000 };
            var content = new StringContent(JsonConvert.SerializeObject(createCar), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Car>(responseString);

            request = $"/api/v1/Car/updateCar?id={result.Id}";
            var updateCar = new UpdateCarRequest { Brand = "12test" };
            content = new StringContent(JsonConvert.SerializeObject(updateCar), Encoding.UTF8, "application/json");

            response = await _client.PutAsync(request, content);
            var responceStringUp = await response.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<Car>(responceStringUp);


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(result1.Brand, updateCar.Brand);
        }

        [Fact]
        public async Task Put_Update_InvalidCarName_ReturnsBadRequestStatusCode()
        {
            var request = "/api/v1/Car/createCar";
            var createCar = new CreateCarRequest { Brand = "asd", Model = "ASasdadd", Color = "asd", Year = 2000 };
            var content = new StringContent(JsonConvert.SerializeObject(createCar), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Car>(responseString);

            request = $"/api/v1/Car/updateCar?id={result.Id}";
            var updateCar = new UpdateCarRequest { Brand = "" };
            content = new StringContent(JsonConvert.SerializeObject(updateCar), Encoding.UTF8, "application/json");

            response = await _client.PutAsync(request, content);
            var responceStringUp = await response.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<Car>(responseString);


            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.NotEqual(result1.Brand, updateCar.Brand);
        }

        [Fact]
        public async Task Put_Update_CarDoesNotExist_ReturnsNotFoundStatusCode()
        {
            var request = "/api/v1/Car/updateCar";
            var updateCar = new UpdateCarRequest { Brand = "asd" };
            var content = new StringContent(JsonConvert.SerializeObject(updateCar), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(request, content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_Delete_CarExists_ReturnsDeletedCar()
        {
            var request = "/api/v1/Car/createCar";
            var createCar = new CreateCarRequest { Brand = "asd", Model = "ASasdadd", Color = "asd", Year = 2000 };
            var content = new StringContent(JsonConvert.SerializeObject(createCar), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(request, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Car>(responseString)!;

            request = $"/api/v1/Car/deleteCar?id={result.Id}";

            response = await _client.DeleteAsync(request);
            var responceString = await response.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<Car>(responseString);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(result1.Brand, createCar.Brand);
        }

        [Fact]
        public async Task Delete_Delete_CarDoesNotExist_ReturnsNotFoundStatusCode()
        {
            var request = "/api/v1/Car/deleteCar?id=7";

            var response = await _client.DeleteAsync(request);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
