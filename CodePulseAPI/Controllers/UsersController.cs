using Azure;
using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;
using CodePulseAPI.Repositories.Implementation;
using CodePulseAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace CodePulseAPI.Controllers;

//https://localhost:7292/api/categories
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(request.Password);
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(bytes);
            StringBuilder hashBuilder = new StringBuilder();
            foreach (var b in result)
            {
                hashBuilder.Append(b.ToString("x2"));
            }

            var user = new User()
            {
                NameOrEmail = request.NameOrEmail,
                Password = hashBuilder.ToString()
            };

            

            user = await _usersRepository.CreateAsync(user);

            return Ok(request);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Erro ao criar usuário: {ex.Message}");
            return StatusCode(500, "Erro ao processar a solicitação.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(Guid id,[FromBody] CreateUserRequestDto request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(request.Password);
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(bytes);
            StringBuilder hashBuilder = new StringBuilder();
            foreach (var b in result)
            {
                hashBuilder.Append(b.ToString("x2"));
            }

            var user = new User()
            {
                NameOrEmail = request.NameOrEmail,
                Password = hashBuilder.ToString()
            };



            user = await _usersRepository.UpdateAsync(id,user);

            return Ok(request);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Erro ao criar usuário: {ex.Message}");
            return StatusCode(500, "Erro ao processar a solicitação.");
        }
    }

    [HttpPost]
    [Route("Authentication")]
    public async Task<IActionResult> AuthUser(CreateUserRequestDto request)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(request.Password);
        HashAlgorithm sha = SHA256.Create();
        byte[] result = sha.ComputeHash(bytes);
        StringBuilder hashBuilder = new StringBuilder();
        foreach (var b in result)
        {
            hashBuilder.Append(b.ToString("x2"));
        }

        var user = new User()
        {
            NameOrEmail = request.NameOrEmail,
            Password = hashBuilder.ToString()
        };

        var passwordCorrect = await _usersRepository.AuthUser(user);

        if (passwordCorrect)
        {
            return Ok("Senha Correta.");
        }
        else
        {
            return Unauthorized("Senha Errada.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _usersRepository.GetAllAsync();

        return Ok(users);
    }

    // Delete: {apibaseurl}/api/Eventos/{id}
    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> DeleteUserById([FromRoute] Guid id)
    {
        var evento = await _usersRepository.DeleteByIdAsync(id);
        return Ok(evento);
    }
}
