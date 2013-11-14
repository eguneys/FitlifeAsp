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

        public IEnumerable<MainFoodDes> GetFood(string name, int pageNo, int pageLength = 20)
        {
            return repository.Foods.Where(x => x.Description.Contains(name)).OrderBy(x => x.Description.Length).Skip((pageNo - 1) * pageLength).Take(pageLength);
        }

        public IEnumerable<MainFoodDes> GetFood(string name, int group,  int pageNo, int pageLength = 20)
        {
            if (group == 0) return GetFood(name, pageNo, pageLength);
            int baseNumber =  10000000;

            int lowerBound = (group) * baseNumber;
            int upperBound = (group + 1) * baseNumber;

            return repository.Foods.Where(x => x.FoodCode >= lowerBound && x.FoodCode < upperBound &&  x.Description.Contains(name)).OrderBy(x => x.Description.Length).Skip((pageNo - 1) * pageLength).Take(pageLength);
        }

        public int GetFood(string name, string getpageno)
        {
            return repository.Foods.Count(x => x.Description.Contains(name));
        }

        public Food GetFood(int foodCode)
        {
            return repository.GetFood(foodCode);
        }
    }
}
