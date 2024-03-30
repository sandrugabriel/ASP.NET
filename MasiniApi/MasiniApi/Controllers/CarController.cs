using MasiniApi.Controllers.interfaces;
using MasiniApi.Dto;
using MasiniApi.Exceptions;
using MasiniApi.Models;
using MasiniApi.Service.interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MasiniApi.Controllers
{

    public class CarController : CarApiController
    {

        private ICarQueryService _carQueryService;
        private ICarCommandService _carCommandService;

        public CarController(ICarQueryService carQueryService, ICarCommandService carCommandService)
        {
            _carQueryService = carQueryService;
            _carCommandService = carCommandService;
        }

        public override async Task<ActionResult<IEnumerable<Masini>>> GetCars()
        {
            try
            {
                IEnumerable<Masini> cars = await _carQueryService.GetAllAsync();

                return Ok(cars);

            }
            catch (ItemsDoNotExists ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<List<int>>> GetAllYears()
        {
            try
            {
               var years = await _carQueryService.GetAllYear();

                return Ok(years);

            }
            catch (ItemsDoNotExists ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Masini>> GetById([FromQuery] int id)
        {
            try
            {
                Masini car = await _carQueryService.GetByIdAsync(id);
                return Ok(car);
            }catch(ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Masini>> GetByNameModel([FromQuery] string marca, [FromQuery] string model)
        {
            try
            {
                var car = await _carQueryService.GetByNameAsync(marca,model);
                return Ok(car);
            }
            catch(ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Masini>> CreateCar([FromBody] CreateCarRequest request)
        {
            try
            {
                var car = await _carCommandService.CreateCar(request);

                return Ok(car);
            }
            catch (InvalidMarca ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidModel ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ItemAlreadyExists ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<Masini>> UpdateCar([FromQuery] int id, [FromBody] UpdateCarRequest request)
        {
            try
            {
                var car = await _carCommandService.UpdateCar(id,request);

                return Ok(car);
            }
            catch (InvalidMarca ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidModel ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Masini>> DeleteCar([FromQuery] int id)
        {
            try
            {
                var car = await _carCommandService.DeleteCar(id);

                return Ok(car);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }









        /* private readonly ILogger<CarController> _logger;
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

         [HttpPost("/createcar")]
         public async Task<ActionResult<Masini>> CreateCar([FromBody] CreateCarRequest request)
         {
             var car = await _carRepository.CreateCar(request);
             return Ok(car);

         }

         [HttpPut("/updatecar")]
         public async Task<ActionResult<Masini>> UpdateCar([FromQuery]int id, [FromBody]UpdateCarRequest request)
         {
             var car = await _carRepository.UpdateCar(id, request);
             return Ok(car);
         }

         [HttpDelete("/deletecarById")]
         public async Task<ActionResult<Masini>> DeleteCarById([FromQuery]int id)
         {
             var car = await _carRepository.DeleteCarById(id);
             return Ok(car);
         }*/

    }
}
