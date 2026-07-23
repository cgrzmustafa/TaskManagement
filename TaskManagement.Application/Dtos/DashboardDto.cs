namespace TaskManagement.Application.Dtos
{
    public record DashboardDto(
        int TaskCount,
        int UserCount,
        int NotificationCount,
        List<ChartItemDto> TasksByStatus,
        List<ChartItemDto> TasksByPriority,
        List<ChartItemDto> TasksByUser
    );

    public record ChartItemDto(string Label, int Value);
}