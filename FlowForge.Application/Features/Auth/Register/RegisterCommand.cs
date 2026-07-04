using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Auth.Register
{
    public record RegisterCommand(string Email, string Password) : IRequest<RegisterResult>;

    public record RegisterResult(Guid UserId, string Email, string Token);
}