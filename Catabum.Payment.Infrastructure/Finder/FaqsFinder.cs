using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Catabum.Payment.Domain.AggregatesModel.PaymentAggregate;
using Catabum.Payment.Domain.AggregatesModel.IntegrationAggregate;
using Catabum.Payment.Domain.SeedWork;
using Catabum.Payment.Infrastructure.Models;
using Serilog;

namespace Catabum.Payment.Infrastructure.Finder
{
    public class PaymentFinder : IPaymentFinder
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
        private readonly ILogger _logger = Log.ForContext<PaymentFinder>();
        private readonly string _connectionString;
        private string emailUuid;

        public PaymentFinder(PaymentsContext paymentsContext,
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

        public async Task<List<PaymentResponse>> FindAll()
        {
            return new List<PaymentResponse>();
        }
    }
}
