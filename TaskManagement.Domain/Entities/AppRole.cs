namespace TaskManagement.Domain.Entities
{
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; } = null!;

        #region NavigationProperties
        public List<AppUser>? Users { get; set; }

        #endregion
    }
}
