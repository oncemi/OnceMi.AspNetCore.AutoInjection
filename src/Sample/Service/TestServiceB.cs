using Microsoft.Extensions.Logging;
using OnceMi.AspNetCore.AutoInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Service
{
    [AutoInjection(InjectionType.Singleton)]
    public class TestServiceB : ITestService
    {
        private readonly ILogger<TestServiceB> _logger;

        public TestServiceB(ILogger<TestServiceB> logger)
        {
            _logger = logger;
        }

        public void Test()
        {
            _logger.LogInformation($"This is {this.GetType().Name} inject by AutoInjection.");
        }
    }
}
