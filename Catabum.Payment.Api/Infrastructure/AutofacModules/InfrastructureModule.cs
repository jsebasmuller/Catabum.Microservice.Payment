using Autofac;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Catabum.Payment.Domain.AggregatesModel;

using Catabum.Payment.Domain.AggregatesModel.PaymentAggregate;
using Catabum.Payment.Infrastructure.Models;
using Catabum.Payment.Infrastructure.Repository;
using Serilog;
using Serilog.Core;

namespace Catabum.Payment.Api.Infrastructure.AutofacModules
{
    /// <summary>
    /// Register all infrastructure related objects
    /// </summary>
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration _configuration; 
        
        public InfrastructureModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserContext>()
                .As<UserContext>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<PaymentRepository>()
                .As<IPaymentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserManager<ApplicationPayment>>()
                .As<UserManager<ApplicationPayment>>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<SignInManager<ApplicationPayment>>()
                .As<SignInManager<ApplicationPayment>>()
                .InstancePerLifetimeScope();
            
            builder.RegisterInstance(_configuration).As<IConfiguration>();
         
            builder.RegisterType<Logger>().As<ILogger>().InstancePerLifetimeScope();
        }
    }
}
