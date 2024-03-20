using MasiniApi.Models;
using MasiniApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MasiniApi.Controllers
{
    [ApiController]
    [Route("api/car/v1")]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private ICarRepository _carRepository;

        public CarController(ILogger<CarController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Masini>>> GetAll()
        {
            var cars = await _carRepository.GetAllAsync();
            return Ok(cars);
        }

    }
}
