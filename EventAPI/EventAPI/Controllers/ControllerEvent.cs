using EventAPI.Models;
using EventAPI.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("api/v1/event")]
    public class ControllerEvent : ControllerBase
    {

        private readonly ILogger<ControllerEvent> _logger;

        private IRepository _repository;

        public ControllerEvent(ILogger<ControllerEvent> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

    }
}
