using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using Catabum.Payment.Api.Application.Commands.Payment;
using Catabum.Payment.Api.Application.Queries.Payment;
using Catabum.Payment.Api.Constants;
using Catabum.Payment.Domain.AggregatesModel.PaymentAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catabum.Payment.Api.Controllers.v1
{
    [ApiController()]
    [Route(PaymentConstants.ContextPath + "payment")]
    [ApiVersion("1.0")]
    public class FaqsController : Controller
    {
        private readonly IMediator _mediator;

        public FaqsController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}