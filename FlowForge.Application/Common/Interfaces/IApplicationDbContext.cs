using FlowForge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Workflow> Workflows { get; }
        DbSet<WorkflowTrigger> WorkflowTriggers { get; }
        DbSet<WorkflowAction> WorkflowActions { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
