
using System;
using System.Collections.Generic;
using FluentValidation;
using Catabum.Payment.Domain.SeedWork;

namespace Catabum.Payment.Domain.AggregatesModel.PaymentAggregate
{
    public class Payment : Entity
    {
    }

    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
        }
    }
}
