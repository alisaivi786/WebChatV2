namespace WebChat.Common.Dto.ResponseDtos.Users;

public record UpdateUserDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? PhoneNumber { get; init; }
}
