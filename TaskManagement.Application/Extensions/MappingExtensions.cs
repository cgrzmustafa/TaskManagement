using TaskManagement.Application.Enums;
using TaskManagement.Application.Requests;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Extensions
{
    public static class MappingExtensions
    {
        public static AppUser ToMap(this RegisterRequest request)
        {
            return new AppUser
            {
                AppRoleId = (int)RoleType.Member,
                Name = request.Name,
                Password = request.Password,
                Surname = request.Surname,
                Username = request.Username,
            };
        }

        public static Priority ToMap(this PriorityCreateRequest request)
        {
            return new Priority
            {
                Definiton = request.Definition,
            };
        }
    }
}
