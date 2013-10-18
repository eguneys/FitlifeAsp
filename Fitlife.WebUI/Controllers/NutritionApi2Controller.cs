using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Fitlife.Domain.Entities;
using Fitlife.Domain.Concrete;
using Fitlife.Domain.Abstract;

namespace Fitlife.WebUI.Controllers
{
    public class NutritionApi2Controller : ApiController
    {
        IFoodRepository repository;

        public NutritionApi2Controller()
        {
            repository = EFFoodRepository.getRepository();
        }

        public IEnumerable<NutrDesc> GetAllNutrDescs()
        {
            return repository.NutrDescs;
        }

        public IEnumerable<FNDDSNutVal> GetNutrDescs(int foodCode)
        {
            return repository.NutVals.Where(x => x.FoodCode == foodCode);
        }

    }
}