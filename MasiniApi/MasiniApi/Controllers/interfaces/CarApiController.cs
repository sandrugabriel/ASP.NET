using MasiniApi.Dto;
using MasiniApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasiniApi.Controllers.interfaces
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class CarApiController : ControllerBase
    {

        [HttpGet("/all")]
        [ProducesResponseType(statusCode: 200, type: typeof(IEnumerable<Masini>))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<IEnumerable<Masini>>> GetCars();

        [HttpGet("/find")]
        [ProducesResponseType(statusCode: 200, type: typeof(Masini))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Masini>> GetByNameModel([FromQuery] string marca, [FromQuery] string model);

        [HttpGet("/allyears")]
        [ProducesResponseType(statusCode: 200, type: typeof(List<int>))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<List<int>>> GetAllYears();

        [HttpGet("/findById")]
        [ProducesResponseType(statusCode: 200, type: typeof(Masini))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Masini>> GetById([FromQuery] int id);

        [HttpPost("/createCar")]
        [ProducesResponseType(statusCode: 201, type: typeof(Masini))]
        [ProducesResponseType(statusCode: 400, type: typeof(string))]
        public abstract Task<ActionResult<Masini>> CreateCar([FromBody]CreateCarRequest request);

        [HttpPut("/updateCar")]
        [ProducesResponseType(statusCode:200,type: typeof(Masini))]
        [ProducesResponseType(statusCode:400, type: typeof(string))]
        public abstract Task<ActionResult<Masini>> UpdateCar([FromQuery]int id,[FromBody]UpdateCarRequest request);

        [HttpDelete("/deleteCar")]
        [ProducesResponseType(statusCode:200, type: typeof(Masini))]
        [ProducesResponseType(statusCode:404,type: typeof(string))]
        public abstract Task<ActionResult<Masini>> DeleteCar([FromQuery]int id);


    }
}
