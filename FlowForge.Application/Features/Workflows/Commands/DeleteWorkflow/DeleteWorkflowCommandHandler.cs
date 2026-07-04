using FlowForge.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Workflows.Commands.DeleteWorkflow
{
    public class DeleteWorkflowCommandHandler : IRequestHandler<DeleteWorkflowCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteWorkflowCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteWorkflowCommand request, CancellationToken cancellationToken)
        {
            var workflow = await _context.Workflows
                .FirstOrDefaultAsync(w => w.Id == request.WorkflowId && w.UserId == request.UserId,
                    cancellationToken);

            if (workflow is null)
                return false;

            _context.Workflows.Remove(workflow);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
