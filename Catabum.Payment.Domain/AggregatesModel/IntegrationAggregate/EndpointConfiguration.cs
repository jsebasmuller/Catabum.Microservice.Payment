using System.Collections.Generic;

namespace Catabum.Payment.Domain.AggregatesModel.IntegrationAggregate
{
    public class EndpointConfiguration : IConfigurationEndpoints
    {
        private Dictionary<string,EndpointSettings> Dictionary { get; set; }

        public EndpointConfiguration()
        {
            Dictionary = new Dictionary<string, EndpointSettings>();
        }

        public void AddConfiguration(EndpointSettings settings)
        {
            Dictionary.Add(settings.Name,settings);
        }

        public EndpointSettings GetConfiguration(string name)
        {
            return Dictionary[name];
        }
    }
}