using BookAPI.Models;
using BookAPI.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/v1/book")]
    public class ControllerBook : ControllerBase
    {

        private readonly ILogger<ControllerBook> _logger;

        private IRepositoryBook _repository;

        public ControllerBook(ILogger<ControllerBook> logger, IRepositoryBook repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }



    }
}
