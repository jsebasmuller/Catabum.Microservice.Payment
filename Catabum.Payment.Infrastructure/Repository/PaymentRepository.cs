using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Catabum.Payment.Domain.AggregatesModel.IntegrationAggregate;
using Catabum.Payment.Domain.AggregatesModel.PaymentAggregate;
using Catabum.Payment.Domain.SeedWork;
using Catabum.Payment.Infrastructure.Models;
using Serilog;

namespace Catabum.Payment.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IConfigurationEndpoints _configurationEndpoints;
        public static ICollection<string> Audience = null;

        private readonly NotificationActivateConfig _activateConfig;

        private PaymentsContext _context;
        public IUnitOfWork UnitOfWork => _context;

        private readonly ILogger _logger = Log.ForContext<PaymentRepository>();
        private readonly string _connectionString;


        public PaymentRepository(PaymentsContext paymentsContext,
                IConfigurationEndpoints endpointConfig,
                IConfiguration configuration,
                IOptions<NotificationActivateConfig> attemptsSettings
                )
        {
            _context = paymentsContext;
            _configurationEndpoints = endpointConfig;
            _activateConfig = attemptsSettings.Value;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }        
    }
}