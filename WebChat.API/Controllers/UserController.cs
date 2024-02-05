using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebChat.Application.Contracts.Presistence.IRepositories.Mongo;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Domain.Entities;
using WebChat.Hubs;
using WebChat.RabbitMQ;

namespace WebChat.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
   
}

