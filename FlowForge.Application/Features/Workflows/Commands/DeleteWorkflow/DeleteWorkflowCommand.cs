using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Workflows.Commands.DeleteWorkflow
{
    public record DeleteWorkflowCommand(Guid WorkflowId, Guid UserId) : IRequest<bool>;

}
