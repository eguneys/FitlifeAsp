using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitlife.Domain.Entities
{
    public class MainFoodDes
    {
        [Key]
        public int FoodCode { get; set; }
        public string Description { get; set; }
    }

    public class FNDDSNutVal
    {
        [Key, Column(Order = 0)]
        public int FoodCode { get; set; }

        [Key, Column(Order = 1)]
        public int NutrientCode { get; set; }
        public decimal NutrientValue { get; set; }
    }

    public class FoodWeights
    {
        [Key]
        public int FoodWeightsID { get; set; }
        public int FoodCode { get; set; }
        public int PortionCode { get; set; }
        public decimal PortionWeight { get; set; }
    }

    public class PortionDescriptions
    {
        [Key]
        public int PortionCode { get; set; }
        public string Description { get; set; }
    }

    public class NutrDesc {
        [Key]
        public int NutrientCode { get; set; }
        public string Description { get;set; }
        public string Tagname { get; set; }
        public string Unit { get; set; }
    }
}
