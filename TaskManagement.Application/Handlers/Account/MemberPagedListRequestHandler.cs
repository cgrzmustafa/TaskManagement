using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.Account
{
    public class MemberPagedListRequestHandler : IRequestHandler<MemberListPagedRequest, PagedResult<MemberListDto>>
    {
        private readonly IUserRepository repository;

        public MemberPagedListRequestHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PagedResult<MemberListDto>> Handle(MemberListPagedRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetAllAsync(request.ActivePage, request.S, 10);
            var mappedData = result.Data.Select(x => new MemberListDto(x.Id, x.Name, x.Surname, x.Username)).ToList();
            return new PagedResult<MemberListDto>(mappedData, request.ActivePage, result.PageSize, result.TotalPages);
        }
    }
}
