using CitiesOfTheWorldAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesOfTheWorldAPI.DataLayer
{
    public class DataHandler
    {
       
        public CityResponse PopulationQuery(CityRequest cityRequest,CityResponse cityResponse=null)
        {
          cityResponse ??= new CityResponse();
          if(DataTable.Count==0)
            {
                ParseCSV(Properties.Resources.populations);
            }
            var propertiesNames = cityRequest.GetType().GetProperties().Select(x => x.Name);
            foreach (var name in propertiesNames)
            {
                //DataTable.Where(x=>x[GetIndexFromPropertyName(name)]== CityRequest.GetProperty(name).GetValue)
            }
            return new CityResponse();
        }

        private void ParseCSV(string csv)
        {
            DataTable = csv.Split("\n").Select(x => x.Split(",")).ToList();
        }

        private  List<string[]> DataTable=new List<string[]>();


        //returns -1 if no property exists
        private int GetIndexFromPropertyName(string rowName)
        {
            return DataTable[0].ToList().IndexOf(rowName);
        }

        enum TableTypes {Populations, CitiesGeonames, GeonamesCoordinates }
    }
}
