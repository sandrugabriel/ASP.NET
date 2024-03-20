using Microsoft.AspNetCore.Mvc;
using ProduseApi.Models;
using ProduseApi.Repository.Interfaces;

namespace ProduseApi.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController:ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        private IProdusRepository _produsRepository;

        public ProductController(ILogger<ProductController> logger,IProdusRepository productRepository)
        {
            _logger = logger;
            _produsRepository = productRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Produs>>> GetAll()
        {
            var products = await _produsRepository.GetAllAsync();
            return Ok(products);
        }
        


    }
}
