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
    public class NutritionApi3Controller : ApiController
    {
        IFoodRepository repository;

        public NutritionApi3Controller()
        {
            repository = EFFoodRepository.getRepository();
        }

        public IEnumerable<FoodWeights> GetAllFoodWeights()
        {
            return repository.FoodWeights;
        }

        public IEnumerable<FoodWeights> GetFoodWeight(int foodCode)
        {
            return repository.FoodWeights.Where(x => x.FoodCode == foodCode);
        }

        public FoodWeights GetFoodWeight(int foodCode, int portionCode)
        {
            return repository.FoodWeights.Where(x => x.FoodCode == foodCode && x.PortionCode == portionCode).FirstOrDefault();
        }
    }
}
