using FlowForge.Application.Common.Interfaces;
using FlowForge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowForge.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
        public DbSet<User> Users => Set<User>();
        public DbSet<Workflow> Workflows => Set<Workflow>();
        public DbSet<WorkflowTrigger> WorkflowTriggers => Set<WorkflowTrigger>();
        public DbSet<WorkflowAction> WorkflowActions => Set<WorkflowAction>();
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    => await base.SaveChangesAsync(cancellationToken);
    }
}
