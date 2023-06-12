using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class LoggerTests : TestBase
    {
        ILogger<LoggerTests> _logger;

        public LoggerTests() {
        _logger = ResolveService<ILogger<LoggerTests>>();
        }

        [TestMethod]
        public void LogMessageTest()
        {
            _logger.LogInformation("Testing log message.");


            _logger.LogTrace("This is a trace message.");
            _logger.LogDebug("This is a debug message.");
            _logger.LogInformation("This is an information message.");
            _logger.LogWarning("This is a warning message.");
            _logger.LogError("This is an error message.");
            _logger.LogCritical("This is a critical message.");

        }


    }

}
