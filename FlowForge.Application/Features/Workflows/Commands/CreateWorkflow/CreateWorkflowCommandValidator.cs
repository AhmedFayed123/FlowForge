using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Features.Workflows.Commands.CreateWorkflow
{
    public class CreateWorkflowCommandValidator : AbstractValidator<CreateWorkflowCommand>
    {
        public CreateWorkflowCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم الـ Workflow مطلوب")
                .MaximumLength(100).WithMessage("الاسم أطول من اللازم (100 حرف كحد أقصى)");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("الوصف أطول من اللازم (500 حرف كحد أقصى)");
        }
    }
}
