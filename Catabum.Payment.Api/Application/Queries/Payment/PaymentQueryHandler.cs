using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Catabum.Payment.Domain.AggregatesModel.PaymentAggregate;
using MediatR;

namespace Catabum.Payment.Api.Application.Queries.Payment
{
    public class ObligationQueyHandler : IRequestHandler<PaymentQuery, IEnumerable<PaymentResponse>>
    {
        private readonly IPaymentFinder _paymentFinder;

        public ObligationQueyHandler(IPaymentFinder paymentFinder)
        {
            _paymentFinder = paymentFinder;
        }

        public async Task<IEnumerable<PaymentResponse>> Handle(PaymentQuery request, CancellationToken cancellationToken)
        {
            return await _paymentFinder.FindAll();
        }
    }
}