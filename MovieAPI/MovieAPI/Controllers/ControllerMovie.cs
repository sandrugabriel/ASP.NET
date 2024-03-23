using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MovieAPI.Models;
using MovieAPI.Repository.interfaces;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1/movie")]
    public class ControllerMovie : ControllerBase
    {

        private readonly ILogger<ControllerMovie> _logger;

        private IRepository _repository;

        public ControllerMovie(ILogger<ControllerMovie> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }
        
    }
}
