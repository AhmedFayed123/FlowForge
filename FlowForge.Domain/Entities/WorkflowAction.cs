using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Domain.Entities
{
    public class WorkflowAction
    {
        public Guid Id { get; set; }
        public Guid WorkflowId { get; set; }
        public int Order { get; set; }
        public ActionType Type { get; set; }
        public string Configuration { get; set; } = string.Empty; // JSON

        public Workflow Workflow { get; set; } = null!;
    }
    public enum ActionType
    {
        CallApi,
        SaveToDb,
        SendEmail
    }
}
