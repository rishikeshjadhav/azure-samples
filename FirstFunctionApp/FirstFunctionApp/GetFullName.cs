
namespace FirstFunctionApp
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;

    public static class GetFullName
    {
        [FunctionName("GetFullName")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string firstName = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "firstname", true) == 0)
                .Value;

            string lastName = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "lastname", true) == 0)
                .Value;

            if (firstName == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                firstName = data?.name;
            }

            if (lastName == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                lastName = data?.name;
            }

            return (firstName == null || lastName == null)
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, "Hello " + string.Format("{0} {1}", firstName, lastName));
        }
    }
}
