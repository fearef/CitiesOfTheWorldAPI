using CitiesOfTheWorldAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesOfTheWorldAPI.DataLayer
{
    public class DataHandler
    {
       
        public static CityResponse PopulationQuery(CityRequest cityRequest,CityResponse cityResponse=null)
        {
          cityResponse ??= new CityResponse();
          if(DataTable.Count==0)
            {
                ParseCSV(Properties.Resources.populations);
            }
            var propertiesNames = cityRequest.GetType().GetProperties().Select(x => x.Name);
            
                var cityData = DataTable.Where(x => x[GetIndexFromPropertyName("City")] == cityRequest.CityName);
                if(cityRequest.Year!=-1)
                {
                  cityResponse.Population=int.Parse(cityData.First(x => x[GetIndexFromPropertyName("Year")] == cityRequest.Year.ToString())[GetIndexFromPropertyName("Value")]);
                }
                else
                {
                  cityResponse.Population = int.Parse(cityData.OrderByDescending(x => x[GetIndexFromPropertyName("Year")]).First()[GetIndexFromPropertyName("Value")]);
                }
                   
            
            return cityResponse;
        }

        private static void ParseCSV(string csv)
        {
            DataTable = csv.Split("\n").Select(x => x.Split(",")).ToList();
        }

        private static  List<string[]> DataTable=new List<string[]>();


        //returns -1 if no property exists
        private static int GetIndexFromPropertyName(string rowName)
        {
            return DataTable[0].ToList().IndexOf(rowName);
        }

        enum TableTypes {Populations, CitiesGeonames, GeonamesCoordinates }
    }
}
