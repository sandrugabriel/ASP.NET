﻿using MasiniApi.Cars.Controllers;
using MasiniApi.Cars.Controllers.interfaces;
using MasiniApi.Cars.Dto;
using MasiniApi.Cars.Service.interfaces;
using MasiniApi.System.Constants;
using MasiniApi.System.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Cars.Helpers;
using Xunit.Sdk;

namespace Test.Cars.UnitTests
{
    public class TestController
    {

        private readonly Mock<ICarCommandService> _mockCommandService;
        private readonly Mock<ICarQueryService> _mockQueryService;
        private readonly CarApiController carApiController;

        public TestController()
        {
            _mockCommandService = new Mock<ICarCommandService>();
            _mockQueryService = new Mock<ICarQueryService>();

            carApiController = new CarController(_mockQueryService.Object,_mockCommandService.Object);
        }

        [Fact]
        public async Task GetAll_ItemsDoNotExist()
        {
            _mockQueryService.Setup(repo=>repo.GetAllAsync()).ThrowsAsync(new ItemsDoNotExists(Constants.NO_CAR_EXIST));

            var restult = await carApiController.GetCars();

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(restult.Result);

            Assert.Equal(Constants.NO_CAR_EXIST,notFoundResult.Value);
            Assert.Equal(404,notFoundResult.StatusCode);

        }

        [Fact]
        public async Task GetAll_ValidData()
        {
            var cars = TestCarFactory.CreateCars(5);
            _mockQueryService.Setup(repo=>repo.GetAllAsync()).ReturnsAsync(cars);

            var result = await carApiController.GetCars();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var allCars = Assert.IsType<List<MasiniApi.Cars.Models.Car>>(okResult.Value);

            Assert.Equal(5,allCars.Count);
            Assert.Equal(200,okResult.StatusCode);

        }

        [Fact]
        public async Task Create_InvalidPrice()
        {

            var createRequest = new CreateCarRequest
            {
                Brand = "",
                Model="2",
                Year = 2000,
                Color = "Alb"
            };

            _mockCommandService.Setup(repo=>repo.CreateCar(It.IsAny<CreateCarRequest>())).
                ThrowsAsync(new InvalidMarca(Constants.INVALID_MARCA));

            var result = await carApiController.CreateCar(createRequest);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);

            Assert.Equal(400,badRequest.StatusCode);
            Assert.Equal(Constants.INVALID_MARCA, badRequest.Value);

        }

        [Fact]
        public async Task Create_ValidData()
        {
            var createRequest = new CreateCarRequest
            {
                Brand = "asd",
                Model = "2",
                Year = 2000,
                Color = "Alb"
            };

            var car = TestCarFactory.CreateCar(1);
            car.Brand = createRequest.Brand;
            car.Model = createRequest.Model;
            car.Year = createRequest.Year;
            car.Color = createRequest.Color;

            _mockCommandService.Setup(repo=>repo.CreateCar(It.IsAny<CreateCarRequest>())).ReturnsAsync(car);

            var result = await carApiController.CreateCar(createRequest);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.Equal(okResult.StatusCode,200);
            Assert.Equal(okResult.Value,car);

        }

        [Fact]
        public async Task Update_ItemDoesNotExist()
        {
            var update = new UpdateCarRequest
            {
                Brand = "test"
            };

            _mockCommandService.Setup(repo=>repo.UpdateCar(1,update)).ThrowsAsync(new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST));

            var result = await carApiController.UpdateCar(1, update);

            var ntFound = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal(ntFound.StatusCode,404);
            Assert.Equal(Constants.CAR_DOES_NOT_EXIST,ntFound.Value);

        }
        [Fact]
        public async Task Update_ValidData()
        {
            var update = new UpdateCarRequest
            {
                Brand = "test"
            };

            var car = TestCarFactory.CreateCar(1);

            _mockCommandService.Setup(repo=>repo.UpdateCar(It.IsAny<int>(),It.IsAny<UpdateCarRequest>())).ReturnsAsync(car);

            var result = await carApiController.UpdateCar(1,update);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.Equal(okResult.StatusCode,200);
            Assert.Equal(okResult.Value,car);
        
        }

        [Fact]
        public async Task Delete_ItemDoesNotExist()
        {
            _mockCommandService.Setup(repo=>repo.DeleteCar(1)).ThrowsAsync(new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST));

            var result = await carApiController.DeleteCar(1);

            var notFound = Assert.IsType<NotFoundObjectResult>(result.Result);

            Assert.Equal(notFound.StatusCode,404);
            Assert.Equal(notFound.Value,Constants.CAR_DOES_NOT_EXIST);

        }

        [Fact]
        public async Task Delete_ValidData()
        {

            var car = TestCarFactory.CreateCar(1);

            _mockCommandService.Setup(repo=>repo.DeleteCar(It.IsAny<int>())).ReturnsAsync(car);

            var result = await carApiController.DeleteCar(1);

            var okresult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.Equal(200,okresult.StatusCode);
            Assert.Equal(okresult.Value,car);

        }

    }
}
