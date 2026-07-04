using FlowForge.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Workflows.Queries.GetWorkflowById
{
    public class GetWorkflowByIdQueryHandler
        : IRequestHandler<GetWorkflowByIdQuery, WorkflowDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetWorkflowByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WorkflowDto?> Handle(
            GetWorkflowByIdQuery request, CancellationToken cancellationToken)
        {
            var workflow = await _context.Workflows
                .Where(w => w.Id == request.WorkflowId && w.UserId == request.UserId)
                .Select(w => new WorkflowDto(w.Id, w.Name, w.Description, w.IsActive, w.CreatedAt))
                .FirstOrDefaultAsync(cancellationToken);

            return workflow;
        }
    }
}
