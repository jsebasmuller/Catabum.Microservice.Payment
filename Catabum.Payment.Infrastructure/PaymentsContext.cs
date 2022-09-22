using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Catabum.Payment.Domain.SeedWork;
using Catabum.Payment.Infrastructure.Models;

namespace Catabum.Payment.Infrastructure
{
    public class PaymentsContext : DbContext, IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        
        public PaymentsContext(DbContextOptions<PaymentsContext> options) : base(options)
        {
        }

        public DbSet<ApplicationPayment> ApplicationPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("catabum");
            builder.Entity<ApplicationPayment>();
            base.OnModelCreating(builder);
        }
        
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            _ = await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}