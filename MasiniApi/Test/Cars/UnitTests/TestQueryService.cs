using MasiniApi.Cars.Repository.Interfaces;
using MasiniApi.Cars.Service;
using MasiniApi.Cars.Service.interfaces;
using MasiniApi.System.Constants;
using MasiniApi.System.Exceptions;
using Moq;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using Test.Cars.Helpers;


namespace Test.Cars.UnitTests
{
    public class TestQueryService
    {
        private readonly Mock<ICarRepository> _mock;
        private readonly ICarQueryService _carQueryService;

        public TestQueryService()
        {
            _mock = new Mock<ICarRepository>();
            _carQueryService = new CarQueryService(_mock.Object);

        }

        [Fact]
        public async Task GetAllCars_ThrowItemsDoNoeExistException()
        {
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<MasiniApi.Cars.Models.Car>());

            var exception = await Assert.ThrowsAsync<ItemsDoNotExists>(() => _carQueryService.GetAllAsync());

            Assert.Equal(Constants.NO_CAR_EXIST,exception.Message);
        }

        [Fact]
        public async Task GetAllCars_ReturnAllCars()
        {
            var cars = TestCarFactory.CreateCars(5);
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(cars);


            var result = await _carQueryService.GetAllAsync();

            Assert.NotNull(result);
            Assert.Contains(cars[1],result);

        }

        [Fact]
        public async Task GetById_ItemDoesNotExist()
        {
            _mock.Setup(repo =>repo.GetByIdAsync(50)).ReturnsAsync((MasiniApi.Cars.Models.Car)null);

            var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(() => _carQueryService.GetByIdAsync(50));

            Assert.Equal(Constants.CAR_DOES_NOT_EXIST, exception.Message);
        }

        [Fact]
        public async Task GetById_ReturnCar()
        {
            var car = TestCarFactory.CreateCar(12);

            _mock.Setup(repo => repo.GetByIdAsync(12)).ReturnsAsync(car);

            var result = await _carQueryService.GetByIdAsync(12);

            Assert.NotNull(result);
            Assert.Equal(car,result);

        }

        [Fact]
        public async Task GetByName_ItemDoesNotExist()
        {
            _mock.Setup(repo=>repo.GetByNameAsync("1","2")).ReturnsAsync((MasiniApi.Cars.Models.Car)null);
            var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(() => _carQueryService.GetByNameAsync("1","2"));

            Assert.Equal(Constants.CAR_DOES_NOT_EXIST,exception.Message);
        }

        [Fact]
        public async Task GetByName_ReturnCar()
        {
            var car = TestCarFactory.CreateCar(50);
            _mock.Setup(repo=>repo.GetByNameAsync("test50","50")).ReturnsAsync(car);
            var result = await _carQueryService.GetByNameAsync("test50","50");

            Assert.NotNull(result);
            Assert.Equal(car, result);

        }

        [Fact]
        public async Task GetAllYears_ItemsDoNotExist()
        {
            _mock.Setup(repo => repo.GetAllYear()).ReturnsAsync(new List<int>());
            var exception = await Assert.ThrowsAsync<ItemsDoNotExists>(() => _carQueryService.GetAllYear());

            Assert.Equal(Constants.NO_CAR_EXIST,exception.Message);
        }

        [Fact]
        public async Task GetAllYears_ReturnListINT()
        {
            var cars = TestCarFactory.CreateYearsCar(5);
            _mock.Setup(repo=>repo.GetAllYear()).ReturnsAsync(cars);
            var result = await _carQueryService.GetAllYear();

            Assert.NotNull(result);
            Assert.Equal(cars, result);

        }

    }
}