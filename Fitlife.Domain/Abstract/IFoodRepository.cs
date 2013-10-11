using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitlife.Domain.Entities;

namespace Fitlife.Domain.Abstract
{
    public interface IFoodRepository
    {
        IQueryable<MainFoodDes> Foods { get; }
        IQueryable<NutrDesc> NutrDescs { get; }
        IQueryable<PortionDescriptions> PortionDescriptions { get; }
        IQueryable<FoodWeights> FoodWeights { get; }
        IQueryable<FNDDSNutVal> NutVals { get; }

        Food GetFood(int foodCode);
    }
}
