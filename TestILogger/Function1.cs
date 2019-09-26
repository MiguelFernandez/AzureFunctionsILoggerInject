using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace TestILogger
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly ISomeService _otherClass;

        public Function1(ILogger<Function1> logger, ISomeService otherClass)
        {
            _logger = logger;
            _otherClass = otherClass;
        }
        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            

            _otherClass.DoSomething();

            return (ActionResult)new OkObjectResult($"ok");
        }
    }
}
