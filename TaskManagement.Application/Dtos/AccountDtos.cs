using TaskManagement.Application.Enums;

namespace TaskManagement.Application.Dtos
{
    public record LoginResponseDto(string Name, string Surname, RoleType Role);
}
