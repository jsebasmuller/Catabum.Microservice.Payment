using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Catabum.Payment.Domain.AggregatesModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Catabum.Payment.Domain.AggregatesModel.IntegrationAggregate;
using Catabum.Payment.Domain.AggregatesModel.PaymentAggregate;
using Catabum.Payment.Domain.Exception;
using Catabum.Payment.Domain.SeedWork;
using Catabum.Payment.Infrastructure.Models;
using Serilog;
using Newtonsoft.Json.Linq;

namespace Catabum.Payment.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly UserManager<ApplicationPayment> _userManager;
        private readonly SignInManager<ApplicationPayment> _signInManager;
        
        private readonly IConfigurationEndpoints _configurationEndpoints;

        private readonly IdentityServerTools _tools;

        public static Client Client = null;
        public static ICollection<string> Audience = null;

        private readonly NotificationActivateConfig _activateConfig;

        private PaymentsContext _context;
        public IUnitOfWork UnitOfWork => _context;

        private readonly ILogger _logger = Log.ForContext<PaymentRepository>();
        private readonly string _connectionString;

        private string emailUuid;


        public PaymentRepository(PaymentsContext paymentsContext,
                UserManager<ApplicationPayment> userManager,
                SignInManager<ApplicationPayment> signInManager,
                IConfigurationEndpoints endpointConfig,
                IConfiguration configuration,
                IOptions<NotificationActivateConfig> attemptsSettings
                )
        {
            _context = paymentsContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _configurationEndpoints = endpointConfig;
            _activateConfig = attemptsSettings.Value;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }        
    }
}