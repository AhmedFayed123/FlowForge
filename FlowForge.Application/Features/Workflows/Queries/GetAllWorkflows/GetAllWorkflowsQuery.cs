using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Workflows.Queries.GetAllWorkflows
{
    public record GetAllWorkflowsQuery(Guid UserId) : IRequest<List<WorkflowListItemDto>>;

    public record WorkflowListItemDto(
        Guid Id,
        string Name,
        bool IsActive,
        DateTime CreatedAt
    );
}
