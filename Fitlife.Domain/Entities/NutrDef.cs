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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        public int PortionID { get; set; }
        public int PortionCode { get; set; }
        public string Description { get; set; }
    }

    public class NutrDesc {
        [Key]
        public int NutrientID { get; set; }

        public int NutrientCode { get; set; }
        public string Description { get;set; }
        public string Tagname { get; set; }
        public string Unit { get; set; }
    }

    //public class FPED
    //{
    //    [Key]
    //    public int FPEDID { get; set; }

    //    public int FoodCode { get; set; }
    //    public int ModCode { get; set; }
    //    public string Description { get; set; }
    //    public string[] FoodGroups { get; set; }
    //}

    public class Food
    {
        public MainFoodDes MainFood { get; set; }
        public List<FoodWeights> Weights { get; set; }
        public List<PortionDescriptions> Portions { get; set; }

        public List<FNDDSNutVal> NutVals { get; set; }
    }
}
