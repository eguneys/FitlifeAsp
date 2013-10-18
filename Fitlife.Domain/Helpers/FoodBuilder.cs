using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitlife.Domain.Entities;
using System.IO;
using Fitlife.Domain.Concrete;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Fitlife.Domain.Helpers
{
    public class FoodBuilder
    {
        public static Dictionary<string, List<int>> RequiredFieldMap = new Dictionary<string, List<int>>()
        {
            {"FNDDSNutVal.txt", new List<int>() {0, 1, 4}},
            {"FoodWeights.txt", new List<int>() {0, 3, 6}},
            {"NutDesc.txt", new List<int>() { 0, 1, 2, 3}},
            {"FoodPortionDesc.txt", new List<int>() {0, 3}},
            {"MainFoodDesc.txt", new List<int>() {0, 3}},
        };


        public static List<List<string>> GetLines(string filename, List<int> requiredFields)
        {

            StreamReader reader = new FileInfo(filename).OpenText();

            List<List<string>> result = new List<List<string>>();

            string[] lineArray;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                List<string> resultArray = new List<string>();
                lineArray = line.Split('^');
                requiredFields.ForEach(x => {
               //     if (lineArray.Length < x) { throw new ArgumentException(line + ""); }
                    resultArray.Add(lineArray[x].Trim('~')); });
                result.Add(resultArray);
            }
            return result;
        }


        public static void buildFoodWeights(string basePath)
        {
            // TODO BULK LOad this
            var bulkCopyThis = new List<FoodWeights>();
            List<List<string>> foodweights = GetLines(basePath + "FoodWeights.txt", RequiredFieldMap["FoodWeights.txt"]);
            int counter = 0;
            foodweights.ForEach(line =>
            {
                FoodWeights newVal = new FoodWeights()
                {
                    FoodCode = int.Parse(line[0]),
                    PortionCode = int.Parse(line[1]),
                    PortionWeight = decimal.Parse(line[2])
                };
//                context.FoodWeights.Add(newVal);

                //if (++counter == 10000)
                //{
                //    counter = 0;
                //    context.SaveChanges();
                //}

                bulkCopyThis.Add(newVal);
            });

            
            string connectionString = GetConnectionString();

            var bulkCopy = new SqlBulkCopy(connectionString);

            bulkCopy.DestinationTableName = "FoodWeights";

            bulkCopy.WriteToServer(bulkCopyThis.AsDataReader());

        }

        public static void buildMainFoods(string basePath)
        {
            List<List<string>> MainFoodDesc = GetLines(basePath + "MainFoodDesc.txt", RequiredFieldMap["MainFoodDesc.txt"]);
            List<MainFoodDes> bulkCopyThis = new List<MainFoodDes>();

            MainFoodDesc.ForEach(line =>
            {
                MainFoodDes newVal = new MainFoodDes()
                {
                    FoodCode = int.Parse(line[0]),
                    Description = line[1]
                };


//                context.MainFoodDes.Add(newVal);
                bulkCopyThis.Add(newVal);
            });



            
            string connectionString = GetConnectionString();

            var bulkCopy = new SqlBulkCopy(connectionString);

            bulkCopy.DestinationTableName = "MainFoodDes";

            bulkCopy.WriteToServer(bulkCopyThis.AsDataReader());
        }

        public static void buildFood(EFDBContext context)
        {
            string basePath = "C:/Users/matizmabel/Documents/Visual Studio 2012/Projects/FitlifeAsp/Fitlife.WebUI/App_Data/";

            buildFoodWeights(basePath);
            
            /*******************************************************/
            /*******************************************************/
            /*******************************************************/


            List<List<string>> nutdescs = GetLines(basePath + "NutDesc.txt", RequiredFieldMap["NutDesc.txt"]);

            nutdescs.ForEach(line =>
            {
                NutrDesc newVal = new NutrDesc()
                {
                    NutrientCode = int.Parse(line[0]),
                    Description = line[1],
                    Tagname = line[2],
                    Unit = line[3]
                };
                Console.WriteLine("Adding NutrDesc " + newVal);
                context.NutrDesc.Add(newVal);
            });

            context.SaveChanges();


            /*******************************************************/
            /*******************************************************/
            /*******************************************************/

            List<List<string>> foodPortionDesc = GetLines(basePath + "FoodPortionDesc.txt", RequiredFieldMap["FoodPortionDesc.txt"]);

            foodPortionDesc.ForEach(line =>
            {
                PortionDescriptions newVal = new PortionDescriptions()
                {
                    PortionCode = int.Parse(line[0]),
                    Description = line[1]
                };
                context.PortionDescriptions.Add(newVal);
            });


            context.SaveChanges();




            /*******************************************************/
            /*******************************************************/
            /*******************************************************/

            buildMainFoods(basePath);


            /*******************************************************/
            /*******************************************************/
            /*******************************************************/

            var bulkCopyThis = new List<FNDDSNutVal>();

            List<List<string>> fnddsNutvals = GetLines(basePath + "FNDDSNutVal.txt", RequiredFieldMap["FNDDSNutVal.txt"]);

            fnddsNutvals.ForEach(line =>
            {
                FNDDSNutVal newVal = new FNDDSNutVal()
                {
                    FoodCode = int.Parse(line[0]),
                    NutrientCode = int.Parse(line[1]),
                    NutrientValue = decimal.Parse(line[2])
                };
            //    context.FNDDSNutVals.Add(newVal);
                bulkCopyThis.Add(newVal);
            });

            string connectionString = GetConnectionString();

            var bulkCopy = new SqlBulkCopy(connectionString);

            bulkCopy.DestinationTableName = "FNDDSNutVals";

            bulkCopy.WriteToServer(bulkCopyThis.AsDataReader());

//            context.SaveChanges();
        }

        private static string GetConnectionString()
        {
            return "Data Source=CASPER;Initial Catalog=Fitlife.Domain.Concrete.EFDBContext;Integrated Security=True;User ID=eguneys;Password=ipek214";
        }
    }
}
