using FluentValidation;
using MediatR;
using Catabum.Payment.Infrastructure.Extensions;
using Catabum.Payment.Domain.AggregatesModel.PaymentAggregate;

namespace Catabum.Payment.Api.Application.Commands.Payment
{
    public class PaymentCommand : IRequest<PaymentResponse>
    {

        public PaymentCommand()
        {
            
        }

        public class PaymentCommandValidator : AbstractValidator<PaymentCommand>
        {
            public PaymentCommandValidator()
            {
            }
        }
    }

}