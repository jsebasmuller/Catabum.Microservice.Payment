using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Catabum.Payment.Domain.SeedWork;

namespace Catabum.Payment.Domain.AggregatesModel.PaymentAggregate
{
    public interface IPaymentRepository : IRepository<Payment>
    {
    }
}