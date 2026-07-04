using FlowForge.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Workflows.Queries.GetAllWorkflows
{
    public class GetAllWorkflowsQueryHandler
        : IRequestHandler<GetAllWorkflowsQuery, List<WorkflowListItemDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllWorkflowsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkflowListItemDto>> Handle(
            GetAllWorkflowsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Workflows
                .Where(w => w.UserId == request.UserId)
                .OrderByDescending(w => w.CreatedAt)
                .Select(w => new WorkflowListItemDto(w.Id, w.Name, w.IsActive, w.CreatedAt))
                .ToListAsync(cancellationToken);
        }
    }
}
