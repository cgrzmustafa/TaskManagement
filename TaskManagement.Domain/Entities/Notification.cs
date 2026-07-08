namespace TaskManagement.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Description { get; set; } = null!;
        public bool State { get; set; }
        public int AppUserId { get; set; }

        #region NavigationProperties
        public AppUser? AppUser { get; set; }

        #endregion
    }
}
