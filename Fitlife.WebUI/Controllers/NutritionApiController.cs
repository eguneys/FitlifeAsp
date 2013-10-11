using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fitlife.WebUI.Controllers
{
    public class NutritionApiController : ApiController
    {
        public IEnumerable<string> GetAllFoods()
        {
            return new List<string>()
            {
                "Hello", "World"
            };
        }
        

        public IEnumerable<string> GetFood(string name)
        {
            return new List<string>()
            {
                "Hello", "World", name
            };
        }
    }
}
