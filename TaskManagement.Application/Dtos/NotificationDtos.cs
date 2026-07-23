namespace TaskManagement.Application.Dtos
{
    public record NotificationListDto(int Id, string Description, bool State, int? AppUserId);
}
