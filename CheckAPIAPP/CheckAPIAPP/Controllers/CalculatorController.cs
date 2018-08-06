using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckAPIAPP.Controllers
{
    public class CalculatorController : ApiController
    {
        // GET api/values/5  
        [HttpGet]
        [System.Web.Http.Route("Api/Add")]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [HttpGet]
        [System.Web.Http.Route("Api/Sub")]
        public int Sub(int a, int b)
        {
            return a - b;
        }


        [HttpGet]
        [System.Web.Http.Route("Api/Mul")]
        public int Mul(int a, int b)
        {
            return a * b;
        }

        [HttpGet]
        [System.Web.Http.Route("Api/Div")]
        public int Div(int a, int b)
        {
            return a / b;
        }

    }
}
