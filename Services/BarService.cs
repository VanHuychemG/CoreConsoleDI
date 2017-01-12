using CoreConsoleDI.Domain.Configuration;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreConsoleDI.Services
{
    public interface IBarService
    {
        void DoSomeOtherWork();
    }

    public class BarService : IBarService
    {
        private readonly BarConfiguration _config;
        private readonly ILogger<BarService> _logger;

        public BarService(IOptions<BarConfiguration> configOptions, ILogger<BarService> logger)
        {
            _config = configOptions.Value;
            _logger = logger;
        }

        public void DoSomeOtherWork()
        {
            _logger.LogInformation("DoSomeOtherWork");

            _logger.LogInformation($"Bar:SomeInteger = {_config.SomeInteger}");
            _logger.LogInformation($"Bar:SomeArrayOfStrings = {string.Join(",", _config.SomeArrayOfStrings)}");
        }
    }
}
