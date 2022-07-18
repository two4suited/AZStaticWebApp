using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Shared;

namespace StaticWebAppFunction
{
    public static class GetPeople
    {
        [FunctionName("GetPeople")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var people = new List<Person>
            {
                new Person { FirstName = "Brian", LastName = "Sheridan" },
                new Person { FirstName = "Heidi", LastName = "Sheridan" }
            };

            return new OkObjectResult(people);
        }
    }
}