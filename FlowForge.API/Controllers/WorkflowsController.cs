using FlowForge.Application.Features.Workflows.Commands.CreateWorkflow;
using FlowForge.Application.Features.Workflows.Commands.DeleteWorkflow;
using FlowForge.Application.Features.Workflows.Queries.GetAllWorkflows;
using FlowForge.Application.Features.Workflows.Queries.GetWorkflowById;
using FlowForge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowForge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WorkflowsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkflowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private Guid GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                               ?? User.FindFirst("sub");
            return Guid.Parse(userIdClaim!.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkflowRequest request)
        {
            var command = new CreateWorkflowCommand(GetCurrentUserId(), request.Name, request.Description);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetWorkflowByIdQuery(id, GetCurrentUserId()));
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllWorkflowsQuery(GetCurrentUserId()));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteWorkflowCommand(id, GetCurrentUserId()));
            return success ? NoContent() : NotFound();
        }
    }

    public record CreateWorkflowRequest(string Name, string? Description);
}
