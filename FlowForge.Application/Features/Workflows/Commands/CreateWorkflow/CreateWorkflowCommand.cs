using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Workflows.Commands.CreateWorkflow
{
    public record CreateWorkflowCommand(
        Guid UserId,
        string Name,
        string? Description
    ) : IRequest<CreateWorkflowResult>;
    public record CreateWorkflowResult(Guid WorkflowId, string Name, bool IsActive, DateTime CreatedAt);
}
