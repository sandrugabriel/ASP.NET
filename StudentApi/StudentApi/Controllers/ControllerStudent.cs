using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Repository.interfaces;

namespace StudentApi.Controllers
{

    [ApiController]
    [Route("api/v1/students")]
    public class ControllerStudent : ControllerBase
    {

        private readonly ILogger<ControllerStudent> _logger;

        private IRepositoryStudent _Repository;

        public ControllerStudent(ILogger<ControllerStudent> logger, IRepositoryStudent Repository)
        {
            _logger = logger;
            _Repository = Repository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var products = await _Repository.GetAllAsync();
            return Ok(products);
        }



    }
}
