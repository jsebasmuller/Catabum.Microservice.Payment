using System.Collections;
using System.Collections.Generic;
using Catabum.Payment.Domain.AggregatesModel.PaymentAggregate;
using FluentValidation;
using MediatR;

namespace Catabum.Payment.Api.Application.Queries.Payment
{
    public class PaymentQuery : IRequest<IEnumerable<PaymentResponse>>
    {        public class PaymentQueryValidator : AbstractValidator<PaymentQuery>
        {
            public PaymentQueryValidator()
            {
            }
        }
    }
}