using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Catabum.Payment.Domain.SeedWork;

namespace Catabum.Payment.Infrastructure.Extensions
{
    /// <summary>
    /// Used to publish all events stored in the entity's domain event list
    /// </summary>
    /// <source>Microsoft</source>
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, PaymentsContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
