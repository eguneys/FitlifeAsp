using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fitlife.Domain.Abstract;
using Fitlife.Domain.Entities;
using Fitlife.Domain.Concrete;

namespace Fitlife.WebUI.Controllers
{
    public class NutritionApiController : ApiController
    {
        IFoodRepository repository;

        public NutritionApiController()
        {
            repository = EFFoodRepository.getRepository();
        }

        public NutritionApiController(IFoodRepository repo)
        {
            repository = repo;
        }
        public IEnumerable<MainFoodDes> GetAllFoods()
        {
            return repository.Foods;
        }
        

        public IEnumerable<MainFoodDes> GetFood(string name)
        {
            return repository.Foods.Where(x => x.Description.Contains(name));
        }

        public Food GetFood(int foodCode)
        {
            return repository.GetFood(foodCode);
        }
    }
}
