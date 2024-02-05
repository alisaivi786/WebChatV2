namespace WebChat.Common.Dto.ResponseDtos.Users;

public record AddUserDto
{
    public string? Name { get; init; }
    public string? PhoneNumber { get; init; }
}
