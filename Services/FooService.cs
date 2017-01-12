using System;

using CoreConsoleDI.Domain.Configuration;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreConsoleDI.Services
{
    public interface IFooService
    {
        void DoSomeWork();
    }

    public class FooService : IFooService
    {
        private readonly FooConfiguration _config;
        private readonly ILogger<FooService> _logger;

        public FooService(IOptions<FooConfiguration> configOptions, ILogger<FooService> logger)
        {
            _config = configOptions.Value;
            _logger = logger;
        }

        public void DoSomeWork()
        {
            _logger.LogInformation("DoSomeWork");

            _logger.LogInformation($"Foo:SomeString = {_config.SomeString}");
        }
    }
}
