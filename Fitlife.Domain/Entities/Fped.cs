using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Fitlife.Domain.Entities
{
    public class FPED
    {
        [Key]
        public int FPEDID { get; set; }

        public int FoodCode { get; set; }
        public int ModCode { get; set; }
        public string Description { get; set; }
        // food groups
        public string F_CITMLB { get; set; }
        public string F_OTHER { get; set; }
        public string F_JUICE { get; set; }
        public string F_TOTAL { get; set; }
        public string V_DRKGR { get; set; }
        public string V_REDOR_TOATO { get; set; }
        public string V_REDOR_OTHER { get; set; }
        public string V_REDOR_TOTAL { get; set; }
        public string V_STARCHY_POTATO { get; set; }
        public string V_STARCHY_OTHER { get; set; }
        public string V_STARCHY_TOTAL { get; set; }
        public string V_OTHER { get; set; }
        public string V_TOTAL { get; set; }
        public string V_LEGUMES { get; set; }
        public string G_WHOLE { get; set; }
        public string G_REFINED { get; set; }
        public string G_TOTAL { get; set; }
        public string PF_MEAT { get; set; }
        public string PF_CUREDMEAT { get; set; }
        public string PF_ORGAN { get; set; }
        public string PF_POULT { get; set; }
        public string PF_SEAFD_HI { get; set; }
        public string PF_SEAFD_LOW { get; set; }
        public string PF_MPS_TOTAL { get; set; }
        public string PF_EGGS { get; set; }
        public string PF_SOY { get; set; }
        public string PF_NUTSDS { get; set; }
        public string PF_LEGUMES { get; set; }
        public string PF_TOTAL { get; set; }
        public string D_MILK { get; set; }
        public string D_YOGURT { get; set; }
        public string D_CHEESE { get; set; }
        public string D_TOTAL { get; set; }
        public string OILS { get; set; }
        public string SOLID_FATS { get; set; }
        public string ADD_SUGARS { get; set; }
        public string A_DRINKS { get; set; }

}
}
