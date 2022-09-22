using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Catabum.Payment.Domain.AggregatesModel.PaymentAggregate;

namespace Catabum.Payment.Api.Application.Commands.Payment
{
    public class PaymentCommandHandler : IRequestHandler<PaymentCommand, PaymentResponse>
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        
        public async Task<PaymentResponse> Handle(PaymentCommand command, CancellationToken cancellationToken)
        {
            var paymentModel = new Domain.AggregatesModel.PaymentAggregate.Payment();
            return null;
        }
    }

}