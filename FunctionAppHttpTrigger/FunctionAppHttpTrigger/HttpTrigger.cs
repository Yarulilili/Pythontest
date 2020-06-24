using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionAppHttpTrigger
{
    public static class HttpTrigger
    {
        [FunctionName("HttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            // Retrieve the model id from the query string
            string username = req.Query["username"];

            // If the user specified a model id, find the details of the model of watch
            if (username != null)
            {
                // Use dummy data for this example
                dynamic userinfo = new { username = "Ariya", userage = 24, usergender = "female", usercountry = "Shanghai"};
                if (username == "Ariya")
                {
                    return (ActionResult)new OkObjectResult($"User Details: {userinfo.username}, {userinfo.userage}, {userinfo.usergender}, {userinfo.usercountry}");
                }
                else {
                    return new BadRequestObjectResult($"There is no infomation about {username}");
                }

            
            }
            return new BadRequestObjectResult("Please provide the name of user in the query string");

        }
    }
}
