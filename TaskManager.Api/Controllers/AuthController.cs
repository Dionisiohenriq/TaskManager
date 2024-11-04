using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TaskManager.Application.DTO;
using TaskManager.Application.Services.Interfaces;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IPersonService _personService;

    public AuthController(IConfiguration configuration, IPersonService personService)
    {
        _configuration = configuration;
        _personService = personService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] PersonDto personDto)
    {
        if (_personService.VerifyPersonExists(personDto.Email).Result)
        {
            return BadRequest("Email already exists");
        }

        var personAdded = _personService.AddPerson(personDto).Result;
        var token = GenerateJwtToken(personDto.Email);
        return Ok(new { message = $"Usuário cadastrado com sucesso!\n{personAdded}\nToken: {token}" });
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] AuthModel model)
    {
        var person = _personService.GetPersonByEmail(model.Email).Result;
        if (person.Password.Equals(model.Password))
        {
            var token = GenerateJwtToken(model.Email);
            return Ok(new { token });
        }

        return Unauthorized();
    }

    private string GenerateJwtToken(string username)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresInMinutes"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class AuthModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}