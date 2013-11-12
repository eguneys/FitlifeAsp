
using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Fitlife.Domain.Helpers
{
    public static class FpedBuilder
    {

        public static List<FPED> GetFPEDs(string filename)
        {

            StreamReader reader = new FileInfo(filename).OpenText();

            List<List<string>> result = new List<List<string>>();

            string[] lineArray;
            string line;

            List<FPED> resultArray = new List<FPED>();
            int count = 0;
            while ((line = reader.ReadLine()) != null)
            {
                count++;
                lineArray = line.Split(';');

                FPED fped = new FPED()
                {

                     FoodCode = int.Parse(lineArray[0].Trim('~')),
                     ModCode = int.Parse(lineArray[1].Trim('~')),
                     Description = lineArray[2].Trim('~'),
 F_CITMLB = (lineArray[3]),
 F_OTHER  = (lineArray[4]),
 F_JUICE  = (lineArray[5]),
 F_TOTAL  = (lineArray[6]),
 V_DRKGR  = (lineArray[7]),
 V_REDOR_TOATO = (lineArray[8]),
 V_REDOR_OTHER  =(lineArray[9]),
 V_REDOR_TOTAL  =(lineArray[10]),
 V_STARCHY_POTATO =(lineArray[11]),
 V_STARCHY_OTHER  =(lineArray[12]),
 V_STARCHY_TOTAL  =(lineArray[13]),
 V_OTHER = (lineArray[14]),
 V_TOTAL = (lineArray[15]),
 V_LEGUMES = (lineArray[16]),
 G_WHOLE  = (lineArray[17]),
 G_REFINED =(lineArray[18]),
 G_TOTAL = (lineArray[19]),
 PF_MEAT = (lineArray[20]),
 PF_CUREDMEAT =(lineArray[21]),
 PF_ORGAN  =(lineArray[22]),
 PF_POULT  =(lineArray[23]),
 PF_SEAFD_HI =(lineArray[24]),
 PF_SEAFD_LOW  =(lineArray[25]),
 PF_MPS_TOTAL  = (lineArray[26]),
 PF_EGGS  = (lineArray[27]),
 PF_SOY  = (lineArray[28]),
 PF_NUTSDS  =(lineArray[29]),
 PF_LEGUMES =(lineArray[30]),
 PF_TOTAL  = (lineArray[31]),
 D_MILK  = (lineArray[32]),
 D_YOGURT =(lineArray[33]),
 D_CHEESE =(lineArray[34]),
 D_TOTAL  =(lineArray[35]),
 OILS  = (lineArray[36]),
 SOLID_FATS =(lineArray[37]),
 ADD_SUGARS =(lineArray[38]),
 A_DRINKS  = (lineArray[39])

                };
                //if (count == 7240) throw new ArgumentException(fped.FoodCode + "");
                resultArray.Add(fped);
            }
            return resultArray;
        }


        
        public static void buildFPEDs(string basePath)
        {
            var bulkCopyThis = GetFPEDs(basePath + "fpeddata.txt");
            
            string connectionString = GetConnectionString();

            var bulkCopy = new SqlBulkCopy(connectionString);

            bulkCopy.DestinationTableName = "FPEDs";

            bulkCopy.WriteToServer(bulkCopyThis.AsDataReader());

        }
        
        private static string GetConnectionString()
        {
            //return "Data Source=CASPER;Initial Catalog=Fitlife.Domain.Concrete.EFDBContext;Integrated Security=True;User ID=eguneys;Password=ipek214";
            return "Data Source=eguneys.db.12106637.hostedresource.com;Initial Catalog=eguneys;User Id=eguneys;Password=cotton412@COM";
        }
    }
}
