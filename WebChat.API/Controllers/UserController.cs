using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebChat.Application.Contracts.Presistence.IRepositories.Mongo;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Common.Dto.ResponseDtos.Users;
using WebChat.Domain.Entities;
using WebChat.RabbitMQ;

namespace WebChat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUnitOfWork unitOfWork,IRabbitMQProducer RabbitMQProducer, IRabbitMQConsumer RabbitMQConsumer) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IRabbitMQProducer RabbitMQProducer  = RabbitMQProducer;
    private readonly IRabbitMQConsumer RabbitMQConsumer  = RabbitMQConsumer;


    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(AddUserDto request)
    {
        var response = await unitOfWork.UserRepository.AddUserAsync(request);
        return Ok(response);
    }

    [HttpPost("CreateBulkUsers")]
    public async Task<IActionResult> CreateBulkUser(List<AddUserDto> request)
    {
        var response = await unitOfWork.UserRepository.AddBulkUserAsync(request);
        return Ok(response);
    }

    [HttpPost("Test")]
    public async Task<IActionResult> Test()
    {
        RabbitMQProducer.PublishMessageToRabbitMQ("Hey Aymen");

        RabbitMQConsumer.StartConsuming();

        return Ok();
    }
}

