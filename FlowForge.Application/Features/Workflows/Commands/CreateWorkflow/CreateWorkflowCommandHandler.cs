using FlowForge.Application.Common.Interfaces;
using FlowForge.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Workflows.Commands.CreateWorkflow
{
    public class CreateWorkflowCommandHandler : IRequestHandler<CreateWorkflowCommand, CreateWorkflowResult>
    {
        private readonly IApplicationDbContext _context;

        public CreateWorkflowCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreateWorkflowResult> Handle(
        CreateWorkflowCommand request, CancellationToken cancellationToken)
        {
            var workflow = new Workflow
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Name = request.Name,
                Description = request.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Workflows.Add(workflow);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateWorkflowResult(
                workflow.Id, workflow.Name, workflow.IsActive, workflow.CreatedAt);
        }

    }
}
