using MasiniApi.Models;
using MasiniApi.Users.Dto;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RegisterRequest = MasiniApi.Users.Dto.RegisterRequest;

namespace MasiniApi.Users.Controllers.interfaces;

[ApiController]
[Route("api/v1/[controller]/")]
public abstract class ControllerAPIUser : ControllerBase
{

    [HttpGet("All")]
    [ProducesResponseType(statusCode: 200, type: typeof(List<UserResponse>))]
    [ProducesResponseType(statusCode: 400, type: typeof(string))]
    public abstract Task<ActionResult<List<UserResponse>>> GetAll();

    [HttpGet("FindById/{id}")]
    [ProducesResponseType(statusCode: 200, type: typeof(UserResponse))]
    [ProducesResponseType(statusCode: 400, type: typeof(string))]
    public abstract Task<ActionResult<UserResponse>> GetById([FromRoute]int id);

    [HttpPost("Register")]
    [ProducesResponseType(statusCode: 200, type: typeof(UserResponse))]
    [ProducesResponseType(statusCode: 400, type: typeof(string))]
    public abstract Task<ActionResult<User>> Register([FromBody]RegisterRequest request);
    
    [HttpPost("Login")]
    [ProducesResponseType(statusCode: 200, type: typeof(UserResponse))]
    [ProducesResponseType(statusCode: 400, type: typeof(string))]
    public abstract Task<ActionResult<User>> Login([FromBody]LoginRequest request);

    
}