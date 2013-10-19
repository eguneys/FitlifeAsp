using Fitlife.Domain.Abstract;
using Fitlife.Domain.Concrete;
using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fitlife.WebUI.Controllers
{
    public class NutritionApi4Controller : ApiController
    {
          IFoodRepository repository;

        public NutritionApi4Controller()
        {
            repository = EFFoodRepository.getRepository();
        }

        public IEnumerable<FPED> GetAllFPEDs()
        {
            return repository.FPEDs;
        }

        public FPED GetFPED(int foodCode)
        {
            return repository.FPEDs.First(x => x.FoodCode == foodCode);
        }
    }
}
