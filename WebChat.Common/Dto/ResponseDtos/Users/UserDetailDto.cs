namespace WebChat.Common.Dto.ResponseDtos.Users;

public record UserDetailDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? PhoneNumber { get; init; }
}
