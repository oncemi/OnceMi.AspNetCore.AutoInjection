using Microsoft.Extensions.Logging;
using OnceMi.AspNetCore.AutoInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Service
{
    [AutoInjection]
    public class TestServiceA
    {
        private readonly ILogger<TestServiceA> _logger;

        public TestServiceA(ILogger<TestServiceA> logger)
        {
            _logger = logger;
        }

        public void Test()
        {
            _logger.LogInformation($"This is {this.GetType().Name} inject by AutoInjection.");
        }
    }
}
