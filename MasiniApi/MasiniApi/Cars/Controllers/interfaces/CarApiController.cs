using MasiniApi.Cars.Dto;
using MasiniApi.Cars.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasiniApi.Cars.Controllers.interfaces
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public abstract class CarApiController : ControllerBase
    {

        [HttpGet("all")]
        [ProducesResponseType(statusCode: 200, type: typeof(IEnumerable<Car>))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<IEnumerable<Car>>> GetCars();

        [HttpGet("find")]
        [ProducesResponseType(statusCode: 200, type: typeof(Car))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Car>> GetByNameModel([FromQuery] string marca, [FromQuery] string model);

        [HttpGet("allyears")]
        [ProducesResponseType(statusCode: 200, type: typeof(List<int>))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<List<int>>> GetAllYears();

        [HttpGet("findById")]
        [ProducesResponseType(statusCode: 200, type: typeof(Car))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Car>> GetById([FromQuery] int id);

        [HttpPost("createCar")]
        [ProducesResponseType(statusCode: 201, type: typeof(Car))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Car>> CreateCar([FromBody] CreateCarRequest request);

        [HttpPut("updateCar")]
        [ProducesResponseType(statusCode: 200, type: typeof(Car))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Car>> UpdateCar([FromQuery] int id, [FromBody] UpdateCarRequest request);

        [HttpDelete("deleteCar")]
        [ProducesResponseType(statusCode: 200, type: typeof(Car))]
        [ProducesResponseType(statusCode: 404, type: typeof(string))]
        public abstract Task<ActionResult<Car>> DeleteCar([FromQuery] int id);


    }
}
