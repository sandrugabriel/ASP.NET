using MasiniApi.Models;
using MasiniApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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

        [HttpGet("/all")]
        public async Task<ActionResult<IEnumerable<Masini>>> GetAll()
        {
            var cars = await _carRepository.GetAllAsync();
            return Ok(cars);
        }
    
        //
        //EXISTA 2 METODE

        //1.PRIN ROUTE
        [HttpGet("/find/{name}/{model}")]
        public async Task<ActionResult<Masini>> GetByNameRoute([FromRoute]string name,[FromRoute] string model)
        {
            var car = await _carRepository.GetByNameAsync(name,model);
            return Ok(car);
        }

        //2.PRIN QUERY
        [HttpGet("/find")]
        public async Task<ActionResult<Masini>> GetByNameQuery([FromQuery] string name, [FromQuery] string model)
        {
            var car  = await _carRepository.GetByNameAsync(name, model);
            return Ok(car);
        }
        //

        [HttpGet("/allyears")]
        public async Task<ActionResult<List<Masini>>> GetAllYears()
        {
            var cars = await _carRepository.GetAllYear();
            return Ok(cars);
        }

        [HttpGet("/findById")]
        public async Task<ActionResult<Masini>> GetById([FromQuery] int id)
        {
            var car = await  _carRepository.GetByIdAsync(id);
            return Ok(car);
        }
    }
}
