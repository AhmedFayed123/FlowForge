using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Workflows.Queries.GetWorkflowById
{
    public record GetWorkflowByIdQuery(Guid WorkflowId, Guid UserId) : IRequest<WorkflowDto?>;

    public record WorkflowDto(
        Guid Id,
        string Name,
        string? Description,
        bool IsActive,
        DateTime CreatedAt
    );
}
