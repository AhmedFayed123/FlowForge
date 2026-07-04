using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Domain.Entities
{
    public class Workflow
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;
        public ICollection<WorkflowTrigger> Triggers { get; set; } = new List<WorkflowTrigger>();
        public ICollection<WorkflowAction> Actions { get; set; } = new List<WorkflowAction>();
    }
}
