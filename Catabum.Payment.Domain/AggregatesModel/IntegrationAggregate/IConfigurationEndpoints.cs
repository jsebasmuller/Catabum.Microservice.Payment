namespace Catabum.Payment.Domain.AggregatesModel.IntegrationAggregate
{
    public interface IConfigurationEndpoints
    {
        public void AddConfiguration(EndpointSettings settings);
        public EndpointSettings GetConfiguration(string name);
    }
}