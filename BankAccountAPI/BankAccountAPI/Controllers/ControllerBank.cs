using BankAccountAPI.Models;
using BankAccountAPI.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BankAccountAPI.Controllers
{
    [ApiController]
    [Route("api/v1/bankAccounts")]
    public class ControllerBank : ControllerBase
    {

        private readonly ILogger<ControllerBank> _logger;

        private IRepository _repository;

        public ControllerBank(ILogger<ControllerBank> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

    }
}
