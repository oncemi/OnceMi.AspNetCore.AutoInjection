using Microsoft.Extensions.Logging;
using OnceMi.AspNetCore.AutoInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Service
{
    [AutoInjection(typeof(ITestService), InjectionType.Singleton)]
    public class TestServiceC : ITestService
    {
        private readonly ILogger<TestServiceC> _logger;

        public TestServiceC(ILogger<TestServiceC> logger)
        {
            _logger = logger;
        }

        public void Test()
        {
            _logger.LogInformation($"This is {this.GetType().Name} inject by AutoInjection.");
        }
    }
}
