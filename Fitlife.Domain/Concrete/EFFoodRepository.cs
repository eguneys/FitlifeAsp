using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitlife.Domain.Abstract;
using Fitlife.Domain.Entities;

namespace Fitlife.Domain.Concrete
{
    public class EFFoodRepository : IFoodRepository
    {
        private EFDBContext context = new EFDBContext();

        private static EFFoodRepository repo = new EFFoodRepository();
        public static EFFoodRepository getRepository() { return repo; }

        public IQueryable<Entities.MainFoodDes> Foods
        {
            get { return context.MainFoodDes; }
        }

        public IQueryable<Entities.NutrDesc> NutrDescs
        {
            get { return context.NutrDesc; }
        }

        public IQueryable<Entities.PortionDescriptions> PortionDescriptions
        {
            get { return context.PortionDescriptions; }
        }

        public IQueryable<Entities.FoodWeights> FoodWeights
        {
            get { return context.FoodWeights; }
        }

        public IQueryable<Entities.FNDDSNutVal> NutVals
        {
            get { return context.FNDDSNutVals; }
        }

        public IQueryable<Entities.FPED> FPEDs
        {
            get { return context.FPEDs; }
        }

        public Food GetFood(int foodCode)
        {
            var food = new Food() {
                MainFood = Foods.First(x => x.FoodCode == foodCode),
                Weights =   FoodWeights
                .Where(x => x.FoodCode == foodCode).ToList(),
                Portions = FoodWeights.Where(x=> x.FoodCode == foodCode).Join(PortionDescriptions, x => x.PortionCode, y=> y.PortionCode, (w, p) => p).ToList(), 
                NutVals = NutVals.Where(x => x.FoodCode == foodCode).ToList()
            };

            return food;
        }
    }
}
