using nanoFramework.TestFramework;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CCSWE.nanoFramework.Logging.UnitTests
{
    [TestClass]
    public class BootstrapperTests
    {
        [TestMethod]
        public void AddLogging_adds_DebugLogger()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var actual = serviceProvider.GetService(typeof(ILogger));

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(DebugLogger));
        }

        [TestMethod]
        public void AddLogging_adds_LoggerOptions()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(options => options.MinLogLevel = LogLevel.Information);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var actual = serviceProvider.GetService(typeof(LoggerOptions));

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(LoggerOptions));
            Assert.AreEqual(LogLevel.Information, ((LoggerOptions)actual).MinLogLevel);
        }
    }
}

