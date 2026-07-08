namespace TaskManagement.Domain.Entities
{
    public class Priority : BaseEntity
    {
        public string Definiton { get; set; } = null!;

        #region NavigationProperties
        public List<AppTask>? Tasks { get; set; }
        #endregion
    }
}
