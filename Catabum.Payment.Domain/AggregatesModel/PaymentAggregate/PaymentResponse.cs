
using System;
using System.Collections.Generic;
using FluentValidation;
using Catabum.Payment.Domain.SeedWork;

namespace Catabum.Payment.Domain.AggregatesModel.PaymentAggregate
{
    public class PaymentResponse : Entity
    {
    }

    public class PaymentResponseValidator : AbstractValidator<PaymentResponse>
    {
        public PaymentResponseValidator()
        {
        }
    }
}
