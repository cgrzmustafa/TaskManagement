using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Enums;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.Account
{
    public class TaskReportRequestHandler : IRequestHandler<MemberListRequest, Result<List<MemberListDto>>>
    {
        private readonly IUserRepository userRepository;

        public TaskReportRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Result<List<MemberListDto>>> Handle(MemberListRequest request, CancellationToken cancellationToken)
        {
            var result = await this.userRepository.GetAllByFilterAsync(x => x.AppRoleId == (int)RoleType.Member, false);
            return new Result<List<MemberListDto>>(result.ToMap(), true, null, null);
        }
    }
}
