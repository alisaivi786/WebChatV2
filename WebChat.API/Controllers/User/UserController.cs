namespace WebChat.API.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

}

