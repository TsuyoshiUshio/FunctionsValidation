
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ValidationFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var movie = JsonConvert.DeserializeObject<Movie>(requestBody);
            var result = movie.Validate();
            if (result.isValid)
            {
                return new OkObjectResult(("Model looks good!"));
            }
            else
            {
                return new BadRequestObjectResult($"Model is invalid: {string.Join(", ", result.validationResults.Select(s => s.ErrorMessage).ToArray())}");
            }

       }
    }
}
