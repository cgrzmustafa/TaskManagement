namespace TaskManagement.Application.Dtos
{
    public record AppTaskListDto(int Id, string Title, string Description, string? PriorityDefinition, bool State, int? AppUserId, string? AppUserFullname, int PriorityId, string? Latitude, string? Longitude);

    public record AppTaskDto(List<PriorityListDto> Priorities, List<MemberListDto>? Employees = null);
}