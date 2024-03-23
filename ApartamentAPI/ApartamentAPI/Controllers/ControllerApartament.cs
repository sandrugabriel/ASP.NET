using ApartamentAPI.Models;
using ApartamentAPI.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApartamentAPI.Controllers
{
    [ApiController]
    [Route("api/v1/apartament")]
    public class ControllerApartament : ControllerBase
    {

        private readonly ILogger<ControllerApartament> _logger;

        private IRepository _repository;

        public ControllerApartament(ILogger<ControllerApartament> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Apartament>>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

    }
}
