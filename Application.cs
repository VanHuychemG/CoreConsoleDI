using CoreConsoleDI.Services;

using Microsoft.Extensions.Logging;

namespace CoreConsoleDI
{
    public class Application
    {
        private readonly IFooService _fooService;
        private readonly IBarService _barService;
        private readonly ILogger<Application> _logger;

        public Application(IFooService fooService, IBarService barService, ILogger<Application> logger)
        {
            _fooService = fooService;
            _barService = barService;
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("Application started.");

            _fooService.DoSomeWork();

            _barService.DoSomeOtherWork();

            _logger.LogInformation("Application ended.");
        }
    }
}
