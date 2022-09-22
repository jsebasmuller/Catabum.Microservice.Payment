using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catabum.Payment.Domain.AggregatesModel.PaymentAggregate
{
    public interface IPaymentFinder
    {
        Task<List<PaymentResponse>> FindAll();
    }
}
