using MediatR;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Requests
{
    public record LoginRequest(string? Username, string? Password, bool RememberMe = false) : IRequest<Result<LoginResponseDto?>>;

    public record RegisterRequest(string? Username, string? Password, string? ConfirmPassword, string? Name, string? Surname) : IRequest<Result<NoData>>;
}
