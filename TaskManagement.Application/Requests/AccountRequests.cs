using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Requests
{
    public record LoginRequest(string Username, string Password) : IRequest<Result<LoginResponseDto?>>;
}
