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
        public void LoggerTest1()
        {

            _logger.LogInformation($"Sum func.");
            var arr = Enumerable.Range(0, 1000).ToArray();
            var sum = 0;

            try
            {
                for (int counter = 0; counter < arr.Length; counter++)
                {
                    _logger.LogTrace($"Item with Index = {counter},");
                    var element = arr[counter];

                    if (element % 2 == 0)
                    {
                        _logger.LogDebug($"Sum for counter = {counter} and item = {element}");
                    }

                }
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, "Error function.");
            }

            var alt = arr.Sum() + 1;
            if (alt != sum)
            {
                _logger.LogWarning($"Calculated incorrect");
            }
            _logger.LogInformation($"Sum function complete.");
        }

    }

}
