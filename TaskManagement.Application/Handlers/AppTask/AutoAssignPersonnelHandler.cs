using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Enums;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagement.Application.Handlers.AppTask
{
    public class AutoAssignPersonnelHandler : IRequestHandler<AutoAssignPersonnelRequest, Result<MemberListDto>>
    {
        private readonly IUserRepository userRepository;
        private readonly IAppTaskRepository appTaskRepository;

        public AutoAssignPersonnelHandler(IUserRepository userRepository, IAppTaskRepository appTaskRepository)
        {
            this.userRepository = userRepository;
            this.appTaskRepository = appTaskRepository;
        }

        public async Task<Result<MemberListDto>> Handle(AutoAssignPersonnelRequest request, CancellationToken cancellationToken)
        {
            var allUsers = await this.userRepository.GetAllAsync(1, null, 100);
            var members = allUsers.Data?.Where(x => x.AppRoleId == (int)RoleType.Member).ToList();

            if (members == null || !members.Any())
            {
                return new Result<MemberListDto>(null, false, "Personel bulunamadı.", null);
            }

            var activeTasks = new List<Domain.Entities.AppTask>();

            for (int page = 1; page <= 5; page++)
            {
                var tasksPage = await this.appTaskRepository.GetAllAsync(page, null, 100);

                if (tasksPage.Data == null || !tasksPage.Data.Any())
                {
                    break;
                }

                var pageTasks = tasksPage.Data.Where(x => x.AppUserId != null).ToList();
                activeTasks.AddRange(pageTasks);
            }

            var userWorkloads = members.Select(m => new
            {
                Member = m,
                ActiveTaskCount = activeTasks.Count(t => t.AppUserId == m.Id) 
            }).ToList();

            var optimizedUser = userWorkloads.OrderBy(w => w.ActiveTaskCount).First().Member;

            var dto = new MemberListDto(optimizedUser.Id, optimizedUser.Name, optimizedUser.Surname, optimizedUser.Username);

            return new Result<MemberListDto>(dto, true, null, null);
        }
    }
}