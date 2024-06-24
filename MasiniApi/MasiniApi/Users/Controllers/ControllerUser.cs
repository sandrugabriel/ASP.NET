using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MasiniApi.Models;
using MasiniApi.Users.Controllers.interfaces;
using MasiniApi.Users.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RegisterRequest = MasiniApi.Users.Dto.RegisterRequest;

namespace MasiniApi.Users.Controllers;

public class ControllerUser(UserManager<User> userManager , SignInManager<User> signInManager, IConfiguration configuration) : ControllerAPIUser
{
    public override Task<ActionResult<List<UserResponse>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public override Task<ActionResult<UserResponse>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public override async Task<ActionResult<User>> Register(RegisterRequest request)
    {
        var random = new Random();
        var age = random.Next(12, 100);
        var name = "name" + random.Next(1, 10000);
        var email = $"test{random.Next(1, 10000)}@gmail.com";
        var username = "user"+ random.Next(1, 10000);

        var user = new User
        {
            UserName = username,
            Email = email,
            Name = name,
            Age = age,
            
        };

        var result = await userManager.CreateAsync(user, "@Test1234");
        if (result.Succeeded)
        {
            var token = GenerateToken();
            return Ok(new {Token = token});
        }

        return BadRequest(result.Errors);
    }

    public override async Task<ActionResult<User>> Login(LoginRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
        {
            var token = GenerateToken();
            return Ok(new {Token = token});
        }

        return Unauthorized();
    }

    private string GenerateToken()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}