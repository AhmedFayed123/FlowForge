using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Domain.Entities
{
    public class WorkflowTrigger
    {
        public Guid Id { get; set; }
        public Guid WorkflowId { get; set; }
        public TriggerType Type { get; set; }
        public string Configuration { get; set; } = string.Empty; 

        public Workflow Workflow { get; set; } = null!;
    }
    public enum TriggerType
    {
        Webhook,
        Schedule
    }
}
