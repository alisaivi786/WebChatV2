using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebChat.Application.Contracts.Presistence.IRepositories.Mongo;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Domain.Entities;

namespace WebChat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IMongoUserRepository UserRepository) : ControllerBase
{
    private readonly IMongoUserRepository UserRepository = UserRepository;

    [HttpPost("CreateUser")]
    public async Task<IActionResult> PostData()
    {

        UserEntity userEntity = new () { Name = "ALI RAZA MUSHTAQ"};
        var response = await UserRepository.InsertMongoAsync(userEntity);

        return Ok(response);
    }
}

