using MasiniApi.Cars.Dto;
using MasiniApi.Cars.Repository.Interfaces;
using MasiniApi.Cars.Service;
using MasiniApi.Cars.Service.interfaces;
using MasiniApi.System.Constants;
using MasiniApi.System.Exceptions;
using Moq;
using NuGet.Frameworks;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Cars.Helpers;

namespace Test.Cars.UnitTests
{
    public class TestCommandService
    {

        private readonly Mock<ICarRepository> _mock;
        private readonly ICarCommandService _commandService;

        public TestCommandService()
        {
            _mock = new Mock<ICarRepository>();
            _commandService = new CarCommandService(_mock.Object);
        }

        [Fact]
        public async Task CreateCar_InvalidBrand()
        {
            var createRequest = new CreateCarRequest
            {
                Brand = "",
                Model = "23",
                Year = 1999,
                Color = "alb"
            };

            _mock.Setup(repo=>repo.CreateCar(createRequest)).ReturnsAsync((MasiniApi.Cars.Models.Car)null);
            Exception exception = await Assert.ThrowsAsync<InvalidMarca>(() => _commandService.CreateCar(createRequest));

            Assert.Equal(Constants.INVALID_MARCA,exception.Message);
        }

        [Fact]
        public async Task CreateCar_InvalidModel()
        {
            var createRequest = new CreateCarRequest
            {
                Brand = "23",
                Model = "",
                Year = 2000,
                Color = "alb"
            };

            _mock.Setup(repo => repo.CreateCar(createRequest)).ReturnsAsync((MasiniApi.Cars.Models.Car)null);
            var exception = await Assert.ThrowsAsync<InvalidModel>(() => _commandService.CreateCar(createRequest));

            Assert.Equal(Constants.INVALID_MODEL,exception.Message);

        }

        [Fact]
        public async Task CreateCar_ReturnCar()
        {
            var createRequest = new CreateCarRequest
            {
                Brand = "dfs",
                Model = "sdf",
                Year = 2000,
                Color = "alb"
            };

            var car = TestCarFactory.CreateCar(50);
            car.Brand = createRequest.Brand;

            _mock.Setup(repo=>repo.CreateCar(It.IsAny<CreateCarRequest>())).ReturnsAsync(car);

            var result = await _commandService.CreateCar(createRequest);

            Assert.NotNull(result);
            Assert.Equal(result.Brand,createRequest.Brand);
        }

        [Fact]
        public async Task Update_ItemDoesNotExist()
        {
            var updateRequest = new UpdateCarRequest
            {
                Brand = "asd"
            };

            _mock.Setup(repo=>repo.GetByIdAsync(50)).ReturnsAsync((MasiniApi.Cars.Models.Car)null);

            var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(() => _commandService.UpdateCar(50,updateRequest));

            Assert.Equal(Constants.CAR_DOES_NOT_EXIST,exception.Message);
        }

        [Fact]
        public async Task Update_InvalidBrand()
        {
            var updateRequest = new UpdateCarRequest
            {
                Brand = "",
                Model = "32"
            };
            var car = TestCarFactory.CreateCar(1);
            car.Brand = updateRequest.Brand;
            _mock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(car);

            var exception = await Assert.ThrowsAsync<InvalidMarca>(() => _commandService.UpdateCar(1,updateRequest));

            Assert.Equal(Constants.INVALID_MARCA,exception.Message);
        }

        [Fact]
        public async Task Update_InvalidModel()
        {
            var updateRequest = new UpdateCarRequest
            {
                Model = ""
            };

            var car = TestCarFactory.CreateCar(1);
            car.Model = updateRequest.Model;
            _mock.Setup(repo=>repo.GetByIdAsync(1)).ReturnsAsync(car);

            var exception = await Assert.ThrowsAsync<InvalidModel>(() => _commandService.UpdateCar(1, updateRequest));

            Assert.Equal(Constants.INVALID_MODEL,exception.Message);
        }

        [Fact]
        public async Task Update_ValidData_ReturnCar()
        {
            var updateREquest = new UpdateCarRequest
            {
                Model = "2"
            };

            var car = TestCarFactory.CreateCar(1);
            car.Model = updateREquest.Model;

            _mock.Setup(repo=>repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(car);
            _mock.Setup(repo => repo.UpdateCar(It.IsAny<int>(),It.IsAny<UpdateCarRequest>())).ReturnsAsync(car);

            var result = await _commandService.UpdateCar(1, updateREquest);

            Assert.NotNull(result);
            Assert.Equal(car,result);

        }

        [Fact]
        public async Task Delete_ItemDoesNotExist()
        {
            _mock.Setup(repo=>repo.DeleteCarById(It.IsAny<int>())).ReturnsAsync((MasiniApi.Cars.Models.Car)null);

            var exception = await Assert.ThrowsAnyAsync<ItemDoesNotExist>(() => _commandService.DeleteCar(1));

            Assert.Equal(exception.Message,Constants.CAR_DOES_NOT_EXIST);

        }

        [Fact]
        public async Task Delete_ValidData()
        {
            var car = TestCarFactory.CreateCar(1);

            _mock.Setup(repo=>repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(car);

            var restul = await _commandService.DeleteCar(1);

            Assert.NotNull(restul);
            Assert.Equal(car,restul);
        }

    }
}
