using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestILogger
{
    public class SomeService : ISomeService
    {
        private readonly ILogger _logger;
        public SomeService(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        public void DoSomething()
        {
            _logger.LogInformation("this is a standalone class named OtherClass");
        }
    }
}
